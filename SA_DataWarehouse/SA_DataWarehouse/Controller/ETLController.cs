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

namespace SA_DataWarehouse {
    /// <summary>
    /// This class controls the businesslogic for the ETL-Application.
    /// </summary>
    class ETLController {

        /// <summary>
        /// The sourceDatabase
        /// </summary>
        private DataContext sourceDatabase;
        /// <summary>
        /// The targetDatabase
        /// </summary>
        private DataContext targetDatabase;         
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
            //Get source
            sourceDatabase = new DataContext(@"Data Source = (local); Initial Catalog = SM_Productive;");
            logger.Log("connected to source db 'SM_Productive'");

            //Get target
            targetDatabase = new DataContext(@"Data Source = (local); Initial Catalog = SM_DataWarehouse;");
            logger.Log("connected to target db 'SM_DataWarehouse'");
        }
    }
}
