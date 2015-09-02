using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//zusätzlicher Namespace
using System.Data.Linq;
using System.Data.Linq.Mapping;
using SA_DataWarehouse.Helper;
using SA_DataWarehouse.Model;
using System.Windows.Forms;

namespace SA_DataWarehouse {
    /// <summary>
    /// This class controls the businesslogic for the ETL-Application.
    /// </summary>
    class ETLController {

        /// <summary>
        /// The operativeDatabase
        /// </summary>
        private OperativeDataContext operativeDatabase;
        /// <summary>
        /// The dataWarehouseDatabase
        /// </summary>
        private DataContext dataWarehouseDatabase;         
        /// <summary>
        /// Logs to ListBox
        /// </summary>
        private Logger logger;
        /// <summary>
        /// A progressbar to show the progress of any operation to the user.
        /// </summary>
        private ProgressBar progressBar;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ETLController(Logger logger, ProgressBar progressBar) {
            this.logger = logger;
            this.progressBar = progressBar;
            InitializeDatabases();
        }

        /// <summary>
        /// Setup connections to the dbs
        /// </summary>
        public void InitializeDatabases() {

            operativeDatabase = new OperativeDataContext();
            string dbIsAccessible = operativeDatabase.DatabaseExists().ToString();
            try {
                string getTransactionTable = operativeDatabase.GetTable<Transaction>().ToArray().Length.ToString();
                logger.Log("operativeDatabase operational and reachable: " + dbIsAccessible + "  currently stored transactions: " + getTransactionTable);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                logger.Log("operativeDatabase operational and reachable: " + dbIsAccessible);
            }



            /*
            //Get source
            operativeDatabase = new DataContext(@"Data Source = (local); Initial Catalog = SM_Productive;");
            logger.Log("connected to source db 'SM_Productive'");

            //Get target
            dataWarehouseDatabase = new DataContext(@"Data Source = (local); Initial Catalog = SM_DataWarehouse;");
            logger.Log("connected to target db 'SM_DataWarehouse'");
            */
        }

        public void StartGenerating() {
            DataGenerator gen = new DataGenerator(logger);

            gen.GenerateTransactions(1000, operativeDatabase, progressBar);

            logger.Log("Currently stored transactions: " + operativeDatabase.GetTable<Transaction>().ToArray().Length.ToString());
        }

        public void ClearTransactions() {
            Table<Transaction> transactions = operativeDatabase.GetTable<Transaction>();

            logger.Log("Deleting " + transactions.ToArray().Length + " transactions");
            //Clear all transactions
            transactions.DeleteAllOnSubmit<Transaction>(transactions.ToArray());
            logger.Log("All transactions deleted");
        }

    }
}
