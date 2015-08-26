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
        /// Default Constructor
        /// </summary>
        public ETLController(Logger logger) {
            this.logger = logger;
            InitializeDatabases();
        }

        /// <summary>
        /// Setup connections to the dbs
        /// </summary>
        public void InitializeDatabases() {

            operativeDatabase = new OperativeDataContext();
            logger.Log("operativeDatabase operational and reachable: " + operativeDatabase.DatabaseExists().ToString() + "  currently stored transactions: " + operativeDatabase.GetTable<Transaction>().ToArray().Length.ToString());

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

            gen.GenerateTransactions(1000, operativeDatabase);

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
