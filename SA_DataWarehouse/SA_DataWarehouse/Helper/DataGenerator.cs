using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Windows.Forms;

using SA_DataWarehouse.Helper;
using SA_DataWarehouse.Model;

namespace SA_DataWarehouse.Helper {

    class DataGenerator {

        Logger logger;

        public DataGenerator(Logger newLogger) {
            this.logger = newLogger;
        }

        /// <summary>
        /// Generate random transactions
        /// </summary>
        public void GenerateTransactions(int count, OperativeDataContext dataContext, ProgressBar progressBar){   

            //Get Tables
            Table<Article> articles = dataContext.GetTable<Article>();
            Table<Branch> branches = dataContext.GetTable<Branch>();
            Table<Seller> sellers = dataContext.GetTable<Seller>();

            //counter for logging
            int created = 0;

            if (count <= 0) {
                Random rand = new Random();
                count = rand.Next(1000, 10000);
            }

            try {
                //Generate transaction
                for (int i = 0; i < count; i++) {

                    Random rand = new Random();
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
                    transaction.total = (double)transaction.count * (double)article.price;
                    transaction.date = DateTime.Now;

                    dataContext.GetTable<Transaction>().InsertOnSubmit(transaction);
                    
                    created++;

                    //Show Progress
                    if(created % 10 == 0) {
                        progressBar.Value = created / 10;
                    }
                }
            } catch (Exception e) {
                logger.Log("Generation failed with error: " + e.Message);
            }
            //Save data to context
            dataContext.SubmitChanges();
            logger.Log("Generated " + created + "/" + count + " new transactions");
        }

    }
}
