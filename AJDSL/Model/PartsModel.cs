using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Windows.Forms;

namespace AJDSL {
    class PartsModel {
        /*
         * Get:
         *  - List<Part> getPartList()
         *  - Part getPart(string partNumber)
         * 
         * "Set":
         *  - bool savePart(Part part)
         * 
         */
        private Table<PartEntity> PartsTable;
        private Table<PartMap> PartsMappingTable;
        private List<Part> PartsList;

        static DataContext myDataBase;
        public PartsModel(string tDataSource, string tDatabaseName) {
            myDataBase = new DataContext("Data Source=" + tDataSource + "; Initial Catalog = " + tDatabaseName + "; Integrated Security = true");
        }

        public PartsModel(string tDataSource, string tDatabaseName, string tDatabaseUser, string tDatabasePassword) {
            myDataBase = new DataContext("Data Source=" + tDataSource + "; Initial Catalog = " + tDatabaseName + "; Uid = " + tDatabaseUser + "; Password = " + tDatabasePassword);
        }

        private void updateTables() {
            PartsTable = myDataBase.GetTable<PartEntity>();
            PartsMappingTable = myDataBase.GetTable<PartMap>();
        }

        // TODO DSL: error handling, check if ID and PartNumber have a value which makes sense.
        // TODO DSL: check for duplicates in List
        // TODO DSL: consolidate assemblePartsList() and getPart()
        public void assemblePartsList() {
            PartsList = new List<Part>();
            updateTables();
            // get all Parts from PartsTable and populate PartsList
            var parts = from part in PartsTable select part;
            foreach (var part in parts) {
                Part assembledPart = new Part();
                assembledPart.Id = part.ID;
                assembledPart.PartNumber = part.PartNumber;
                assembledPart.Mass = part.Mass;
                assembledPart.Weight = part.Weight;
                assembledPart.Length = part.Width;
                assembledPart.Height = part.Height;
                assembledPart.Description = part.Description;

                PartsList.Add(assembledPart);
            }
            // get relations of parts
            foreach (var part in PartsMappingTable) {
                // the partNumber is needed to find the parts in the PartsList, so skip entries without partNumber.
                //if (part.PartNumber == null || part.PartNumber == "") {
                //    continue;
                //}


                Part parent = PartsList.Find(x => x.Id == part.Parent_id );
                Part child = PartsList.Find(x => x.Id == part.Child_id);

                if (parent != null && child != null) {
                    parent.addChild(child);
                    child.addParent(parent);
                }
            }
        }

        public List<Part> getPartList() {
            List<Part> partsList = PartsList;
            return partsList;
        }

        // Returns: Part
        // If:      Part.Id = -1
        // AND:     Part.PartNumber = ""
        // something went wrong. 
        public Part getPart(string partNumber) {
            updateTables();
            Part loadedPart = new Part(-1, "");
            var parts = from field in PartsTable where field.PartNumber == partNumber select field;
            foreach (var field in parts) {
                loadedPart.Id = field.ID;
                loadedPart.PartNumber = field.PartNumber;
                loadedPart.Mass = field.Mass;
                loadedPart.Weight = field.Weight;
                loadedPart.Length = field.Length;
                loadedPart.Width = field.Width;
                loadedPart.Height = field.Height;
                loadedPart.Description = field.Description;
            }

            // get relation of part

            return loadedPart;
        }

        private Part getPartRelatives(Part part) {
            Part relative = new Part(-1, "");

            return relative;
        }


        // Write to DB
        // TODO DSL: only write fields which have changed. 
        // TODO DSL: take Part and decide if it's an update or insert operation.
        // TODO DSL: error handling
        public bool updatePart(Part savePart) {

            PartEntity writePart;

            //update or save new
            if (savePart.Id > -1) {
               writePart = (from part in PartsTable
                         where part.ID == savePart.Id
                         select part).FirstOrDefault();
            } else {
                writePart = new PartEntity();
            }
             
            writePart.PartNumber = savePart.PartNumber;
            writePart.Mass = savePart.Mass;
            writePart.Weight = savePart.Weight;
            writePart.Length = savePart.Length;
            writePart.Width = savePart.Width;
            writePart.Height = savePart.Height;
            writePart.Description = savePart.Description;

            //update relations
            var PartMaps = from rel in PartsMappingTable
                            where rel.Parent_id == savePart.Id || rel.Child_id == savePart.Id
                            select rel;

            //Delete old relations
            foreach (PartMap rel in PartMaps) {
                PartsMappingTable.DeleteOnSubmit(rel);
            }

            //Create new relations
            foreach (Part parent in savePart.Parents) {
                PartMap rel = new PartMap() { Parent_id = parent.Id, Child_id = savePart.Id };
                PartsMappingTable.InsertOnSubmit(rel);
            }
            foreach (Part child in savePart.Childs) {
                PartMap rel = new PartMap() { Parent_id = savePart.Id, Child_id = child.Id };
                PartsMappingTable.InsertOnSubmit(rel);
            }

            try {
                if(writePart.ID <= 0){
                    //insert if new
                    PartsTable.InsertOnSubmit(writePart);
                }
                 myDataBase.SubmitChanges();
                
            }
            catch (Exception ex) {
                return false;
            }
            return true;
        }

    }

    #region mapper classes
    [Table(Name = "Parts")]
    public class PartEntity {
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID {
            get;
            set;
        }

        [Column]
        public string PartNumber;
        public float Mass;
        public float Weight;
        public float Length;
        public float Width;
        public float Height;
        public string Description;
    }

    [Table(Name = "PartMapping")]
    public class PartMap {
        [Column(Name = "Parent_id", IsDbGenerated = false, IsPrimaryKey = true)]
        public int Parent_id {
            get;
            set;
        }

        [Column(Name = "Child_id", IsDbGenerated = false, IsPrimaryKey = true)]
        public int Child_id {
            get;
            set;
        }

        [Column]
        public string PartNumber;
    }
    #endregion
}