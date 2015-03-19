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
        private void assemblePartsList() {
            // initialize Part.
            Part assembledPart = new Part(-1, "");
            updateTables();
            // get all Parts from DB and populate PartsList
            var parts = from part in PartsTable select part;
            foreach (var part in parts) {
                assembledPart.Id = part.ID;
                assembledPart.PartNumber = part.PartNumber;
                assembledPart.Mass = part.Mass;
                assembledPart.Weight = part.Weight;
                assembledPart.Length = part.Width;
                assembledPart.Height = part.Height;
                assembledPart.Description = part.Description;
                PartsList.Add(assembledPart);
            }
            //get parts relations
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
            // initialize Part
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
            //get relations of part


            return loadedPart;
        }


        // Write to DB
        // TODO DSL: only write fields which have changed. 
        // TODO DSL: take Part and decide if it's an update or insert operation.
        // TODO DSL: error handling
        public bool updatePart(Part part) {
            PartEntity writePart = new PartEntity();
            writePart.PartNumber = part.PartNumber;
            writePart.Mass = part.Mass;
            writePart.Weight = part.Weight;
            writePart.Length = part.Length;
            writePart.Width = part.Width;
            writePart.Height = part.Height;
            writePart.Description = part.Description;

            try {
                PartsTable.InsertOnSubmit(writePart);
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