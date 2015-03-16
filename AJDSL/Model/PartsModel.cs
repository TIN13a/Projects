﻿using System;
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
                var entries = from my_i in myPart select my_i;

                foreach (var i in entries) {
                    output += i.PartNumber + "\r\n";
                }
            }
            catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return output;
        }

        public void getPart() {
            
            try {
                Table<PartEntity> myParts = myDataBase.GetTable<PartEntity>();
                var entries = from my_i in myParts select my_i;
                
                foreach (var i in entries) {
                    
                }
            }
            catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            //return filled up part object
        }

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
        }

        [Table(Name = "PartMapping")]
        public class PartMap {
            [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true)]
            public int ID {
                get;
                set;
            }

            [Column]
            public string PartNumber;
        }
        #endregion
    }
}