using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace AJDSL {
    class PartsModel {
        // typisierte Liste aller Parts zurückgeben

        static DataContext myDataBase;
        public PartsModel(string tDataSource, string tDatabaseName) {
            myDataBase = new DataContext("Data Source=" + tDataSource + "; Initial Catalog = " + tDatabaseName + "; Integrated Security = true");
        }

        public PartsModel(string tDataSource, string tDatabaseName, string tDatabaseUser, string tDatabasePassword) {
            myDataBase = new DataContext("Data Source=" + tDataSource + "; Initial Catalog = " + tDatabaseName + "; Uid = " + tDatabaseUser + "; Password = " + tDatabasePassword);
        }

        public string printPartNumbers() {
            string output = "";
            try {
                Table<PartEntity> myPart = myDataBase.GetTable<PartEntity>();
                var entries = from myField in myPart select myField;

                foreach (var field in entries) {
                    output += field.PartNumber + "\r\n";
                    output += field.Mass + "\r\n";
                    output += field.Weight + "\r\n";
                    output += field.Length + "\r\n";
                    output += field.Width + "\r\n";
                    output += field.Height + "\r\n";
                    output += field.Description + "\r\n";
                }
            }
            catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return output;
        }
                /*
        public Part getPart() {
            Part myPart;
            try {
                Table<PartEntity> myParts = myDataBase.GetTable<PartEntity>();
                var entries = from myField in myParts select myField;
                
                foreach (var field in entries) {
                    myPart = new Part(field.ID,field.PartNumber);
                    myPart.Mass = field.Mass;
                    myPart.Weight = field.Weight;
                    myPart.Length = field.Length;
                    myPart.Width = field.Width;
                    myPart.Height = field.Height;
                    myPart.Description = field.Description;
                }
            }
            catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return myPart;
        }            */

        // Write to DB
        private void sqlUpdate() {
            Table<PartEntity> myPart = myDataBase.GetTable<PartEntity>();
            PartEntity writeObject = new PartEntity();
            writeObject.PartNumber = "0020C106";
            myPart.InsertOnSubmit(writeObject);
            myDataBase.SubmitChanges();
        }

        //insert
        //delete
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