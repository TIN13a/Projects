using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Windows.Forms;

namespace TarMedApp {
    class Model {
        string dataSource = ""; // "(local)"
        string databaseName = ""; // "Hausarztsystem" || "Patientendatensystem"
        string databaseUser = "";
        string databasePassword = "";

        public Model(string tDataSource, string tDatabaseName) {
            dataSource = tDataSource;
            databaseName = tDatabaseName;
        }

        public Model(string tDataSource, string tDatabaseName, string tDatabaseUser, string tDatabasePassword) {
            dataSource = tDataSource;
            databaseName = tDatabaseName;
            databaseUser = tDatabaseUser;
            databasePassword = tDatabasePassword;
        }

        static DataContext myDataBase = new DataContext(@"Data Source=" + dataSource + "; Initial Catalog = " + dataBaseName + "; Integrated Security = true");

        // Read from DB
        private void sqlSelect() {
            try {
                Table<Patient> contentArtikel = myDataBase.GetTable<Patient>();
                Table<Arzt> contentKunde = myDataBase.GetTable<Arzt>();

                //Auswerten der typisierten Liste
                var einträge =
                                from my_i in contentArtikel
                                select my_i;

                //Ausgabe
                foreach (var i in einträge) {
                    //Form1.setTextBoxOutput(i.Name);
                }
            }
            catch (Exception ex) {
                //Schief gelaufen
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        // Write to DB

    }

    #region mapper classes
    [Table(Name = "Patient")]
    public class Patient {
        //Mapper auf Primary Key
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID {
            get;
            set;
        }

        //Mapper auf Feld Inhalt
        [Column]
        public string Name;
        public string Vorname;
    }

    [Table(Name = "Arzt")]
    public class Arzt {
        //Mapper auf Primary Key
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID {
            get;
            set;
        }

        //Mapper auf Feld Inhalt
        [Column]
        public string Name;
        public string Vorname;
    }
    #endregion
}
