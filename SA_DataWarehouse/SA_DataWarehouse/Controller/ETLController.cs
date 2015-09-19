using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

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
        /// If controller is something 
        /// </summary>
        public bool isCalculating = false;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ETLController(Logger logger, ProgressBar progressBar) {
            this.logger = logger;
            this.progressBar = progressBar;
            InitializeDatabases();
        }

        delegate void ShowProgressDelegate(int total, int progress, String message);

        void ShowProgress(int total, int progress, String message) {
            Console.WriteLine("ShowProgress: msg: '" + message + "'");

            // Make sure we're on the right thread
            if (progressBar.InvokeRequired == false) {
                if (message != null && message != "") {
                    logger.Log(message);
                }

                progressBar.Maximum = total;
                progressBar.Value = progress;
            } else {
                // Show progress asynchronously
                ShowProgressDelegate showProgress = new ShowProgressDelegate(ShowProgress);
                progressBar.Invoke(showProgress, new object[] { total, progress, message });
            }
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

        
        public void print(string title, string message) {
            // just for debugging
            logger.Log(title + ":\t" + message);
        }


        public void StartGenerating() {
            Task generatingTask = Task.Run(() => { 
                GenerateTransactions(500, operativeDatabase);
            });
        }

        public void ClearTransactions() {
            Table<Transaction> transactions = operativeDatabase.GetTable<Transaction>();

            logger.Log("Deleting " + transactions.ToArray().Length + " transactions");
            //Clear all transactions
            transactions.DeleteAllOnSubmit<Transaction>(transactions.ToArray());

            System.Threading.Thread.Sleep(200);
            operativeDatabase.SubmitChanges();
            logger.Log("All transactions deleted");
        }

        public void StartTransforming() {
            Task generatingTask = Task.Run(() => {
                ExtractTransformLoad();
            });
        }

        public void ClearSales() {
            Table<Sales> sales = dataWarehouseDatabase.GetTable<Sales>();

            logger.Log("Deleting " + sales.ToArray().Length + " sales");
            //Clear all transactions
            sales.DeleteAllOnSubmit<Sales>(sales.ToArray());

            System.Threading.Thread.Sleep(200);

            dataWarehouseDatabase.SubmitChanges();
            logger.Log("All sales deleted");
        }

        /**
         * Generating
         */
        private void GenerateTransactions(int count, OperativeDataContext dataContext) {
            ShowProgress(100, 0, "Start generating of " + count + " new transactions");

            isCalculating = true;

            //Get Tables
            Table<Article> articles = dataContext.GetTable<Article>();
            Table<Branch> branches = dataContext.GetTable<Branch>();
            Table<Seller> sellers = dataContext.GetTable<Seller>();

            //counter for logging
            int created = 0;

            Random rand = new Random();

            if (count <= 0) {
                count = rand.Next(1000, 10000);
            }

            try {
                //Generate transaction
                for (int i = 0; i < count; i++) {

                    
                    int randBranch = rand.Next(0, branches.ToArray().Length);
                    int randArticles = rand.Next(0, articles.ToArray().Length);
                    int randSeller = rand.Next(0, sellers.ToArray().Length);

                    //Get a branch
                    Branch branch = branches.ToArray()[randBranch];
                    //Get a article
                    Article article = articles.ToArray()[randArticles];
                    //Get a branch
                    Seller seller = sellers.ToArray()[randSeller];

                    //create a transaction
                    Transaction transaction = new Transaction();
                    transaction.Branch = branch;
                    transaction.Article = article;
                    transaction.Seller = seller;
                    transaction.count = rand.Next(1, (int)article.quantity);
                    //transaction.total = (double)transaction.count * (double)article.price;
                    String date = rand.Next(1, 30).ToString() + "/" + rand.Next(3, 12).ToString() + "/" + rand.Next(2000, 2015).ToString();

                    //Show Progress
                    ShowProgress(count, created, date);

                    transaction.date = DateTime.Parse(date);
                    dataContext.GetTable<Transaction>().InsertOnSubmit(transaction);

                    dataContext.SubmitChanges();
                    created++;
                }
            } catch (Exception e) {
                ShowProgress(100, 0, "Error while generating!" + e.Message);
            } finally {
                isCalculating = false;
                ShowProgress(100, 0, "Generating done. New transactions: " + created.ToString() + " Total: " + dataContext.GetTable<Transaction>().ToList<Transaction>().Count.ToString());
            }
        }

        public void ExtractTransformLoad() {

            isCalculating = true;

            //LINQ SQL Data Model
            List<Transaction> transactionList = operativeDatabase.GetTable<Transaction>().ToList<Transaction>();
            List<Sales> salesList = new List<Sales>();

            int transformedTransactions = 0;

            ShowProgress(100, 0, "Start transforming of " + transactionList.Count.ToString() + " transactions");

            /**
            * Sale
            */
            try {
                foreach (Transaction transaction in transactionList) {

                    foreach (Article_Category relation in transaction.Article.Article_Category) {
                        //Create a new Sales object for the new data
                        Sales baseSale = new Sales();
                        baseSale.sum = (double)transaction.Article.price * (1.0 - (1.0 - TransformHelper.EUR)) * transaction.count;
                        
                        //Branches
                        foreach (Branches branches in dataWarehouseDatabase.Branches.ToArray<Branches>()) {
                            if (branches.name == transaction.Branch.name) {
                                baseSale.Branches = branches;
                                break;
                            }
                        }

                        if (baseSale.Branches == null) {
                            baseSale.Branches = new Branches();
                            baseSale.Branches.name = transaction.Branch.name;
                        }

                        //Countries
                        foreach (Countries countries in dataWarehouseDatabase.Countries.ToArray<Countries>()) {
                            if (countries.name == "DE") {
                                baseSale.Countries = countries;
                                break;
                            }
                        }

                        if (baseSale.Countries == null) {
                            baseSale.Countries = new Countries();
                            baseSale.Countries.name = "DE";
                        }

                        //Day
                        foreach (SA_DataWarehouse.Model.Day day in dataWarehouseDatabase.Day.ToArray<SA_DataWarehouse.Model.Day>()) {
                            if (day.name == transaction.date.Day.ToString()) {
                                baseSale.Day = day;
                                break;
                            }
                        }

                        if (baseSale.Day == null) {
                            baseSale.Day = new SA_DataWarehouse.Model.Day();
                            baseSale.Day.name = transaction.date.Day.ToString();
                        }

                        //Month
                        foreach (Month month in dataWarehouseDatabase.Month.ToArray<Month>()) {
                            if (month.name == transaction.date.Month.ToString()) {
                                baseSale.Month = month;
                                break;
                            }
                        }

                        if (baseSale.Month == null) {
                            baseSale.Month = new Month();
                            baseSale.Month.name = transaction.date.Month.ToString();
                        }

                        //Year
                        foreach (Year year in dataWarehouseDatabase.Year.ToArray<Year>()) {
                            if (year.name == transaction.date.Year.ToString()) {
                                baseSale.Year = year;
                                break;
                            }
                        }

                        if (baseSale.Year == null) {
                            baseSale.Year = new Year();
                            baseSale.Year.name = transaction.date.Year.ToString();
                        }

                        //Categories
                        foreach (Categories category in dataWarehouseDatabase.Categories.ToArray<Categories>()) {
                            if (category.name == relation.Category.name) {
                                baseSale.Categories = category;
                                break;
                            }
                        }

                        if (baseSale.Categories == null) {
                            baseSale.Categories = new Categories();
                            baseSale.Categories.name = relation.Category.name;
                        }

                        

                        //Add Copies
                        dataWarehouseDatabase.GetTable<Sales>().InsertOnSubmit(baseSale);

                        transformedTransactions++;

                        //logger.Log("transformed transaction with id: " + transaction.id.ToString());

                        //logger.Log(String.Format("id: {0}, sum: {1}, country:{2}", baseSale.id, baseSale.sum, baseSale.Countries.name));

                        //Submit changes
                        dataWarehouseDatabase.SubmitChanges();

                        ShowProgress(transactionList.Count, transformedTransactions, null);
                    }
                }
            } catch (Exception e) {
                ShowProgress(100, 0, "Error while transforming");
            } finally {
                isCalculating = false;
                ShowProgress(100, 0, "Transforming done. New Sales: " + transformedTransactions.ToString() + " Total: " + dataWarehouseDatabase.GetTable<Sales>().ToList<Sales>().Count.ToString());
            }
        }
    }
}
