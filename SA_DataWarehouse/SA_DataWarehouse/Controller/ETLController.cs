using System;
using System.Collections;
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
        private DataWarehouseDataContext dataWarehouseDatabase;
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
                logger.Log("operativeDatabase operational and reachable: " + dbIsAccessible);
                logger.Log("Currently stored transactions: " + getTransactionTable);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                //MessageBox.Show(ex.ToString(), "Error", MessageBoxIcon.Error, MessageBoxButtons.OK);
                logger.Log("operativeDatabase operational and reachable: " + dbIsAccessible);
            }


            dataWarehouseDatabase = new DataWarehouseDataContext();
            dbIsAccessible = dataWarehouseDatabase.DatabaseExists().ToString();
            try {
                string getSalesTable = dataWarehouseDatabase.GetTable<Sales>().ToArray().Length.ToString();
                logger.Log("dataWarehouseDB operational and reachable: " + dbIsAccessible);
                logger.Log("Currently stored sales entries: " + getSalesTable);
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                //MessageBox.Show(ex.ToString(), "Error", MessageBoxIcon.Error, MessageBoxButtons.OK);
                logger.Log("dataWarehouseDB operational and reachable: " + dbIsAccessible);
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

        public void ExtractTransformLoad() {
            //LINQ SQL Data Model
            List<Transaction> transactionList = operativeDatabase.GetTable<Transaction>().ToList<Transaction>();
            List<Sales> salesList = new List<Sales>();

            progressBar.Value = 0;

            int transformedTransactions = 0;
            foreach (Transaction transaction in transactionList) {
                //print("Article", transaction.Article.name.ToString());
                //transaction.Article.price = Math.Round(transaction.Article.price * TransformHelper.EUR, 2);
                print("Article", transaction.Article.name.ToString() + "  Price: " + transaction.Article.price.ToString());

                /**
                 * Sale
                 */
                try {
                    foreach (Article_Category relation in transaction.Article.Article_Category) {
                    //Create a new Sales object for the new data
                    Sales baseSale = new Sales();
                    baseSale.sum = (double)transaction.Article.price * (1.0 - (1.0 - TransformHelper.EUR)) * transaction.count;
                    baseSale.Branches = new Branches();
                    baseSale.Branches.name = transaction.Branch.name;
                    baseSale.Countries = new Countries();
                    baseSale.Countries.name = "DE";
                    baseSale.Day = new SA_DataWarehouse.Model.Day();
                    baseSale.Day.name = transaction.date.Day.ToString();
                    baseSale.Month = new Month();
                    baseSale.Month.name = transaction.date.Month.ToString();
                    baseSale.Year = new Year();
                    baseSale.Year.name = transaction.date.Year.ToString();
                    baseSale.Categories = new Categories();
                    baseSale.Categories.name = relation.Category.name;

                    //Add Copies and clear list
                    dataWarehouseDatabase.GetTable<Sales>().InsertOnSubmit(baseSale);

                    transformedTransactions++;

                    progressBar.Value = transformedTransactions / transactionList.Count * 100;

                    logger.Log("transformed transaction with id: " + transaction.id.ToString());

                    logger.Log(String.Format("id: {0}, sum: {1}, country:{2}", baseSale.id, baseSale.sum, baseSale.Countries.name));

                    //Submit changes
                    dataWarehouseDatabase.SubmitChanges();
                    }
                } catch (Exception e) {
                    logger.Log(e.Message);
                }
            }

            logger.Log("Transformed " + transformedTransactions + " transactions. Currently amout of sales entries stored: " + dataWarehouseDatabase.GetTable<Sales>().ToArray().Length.ToString());

        }

        public void print(string title, string message) {
            // just for debugging
            logger.Log(title + ":\t" + message);
        }


        public void StartGenerating() {
            DataGenerator gen = new DataGenerator(logger);

            gen.GenerateTransactions(5000, operativeDatabase, progressBar);

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
