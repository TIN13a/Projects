﻿using SA_DataWarehouse.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA_DataWarehouse {
    public partial class MainGUI : Form {
        public MainGUI() {
            InitializeComponent();
        }

        /// <summary>
        /// Default logger for this app
        /// </summary>
        private Logger logger;
        /// <summary>
        /// Controller for this app
        /// </summary>
        private ETLController controller;

        private void MainGUI_Load(object sender, EventArgs e) {
            //Set logger
            logger = new Logger(lb_logger);
            //set controller
            controller = new ETLController(logger, progressBar);
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void btn_gen_transactions_Click(object sender, EventArgs e) {


            if (MessageBox.Show("Do you want to delete old transactions?", "Delete transactions?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                controller.ClearTransactions();
            }

            //Start generation of transactions
            controller.StartGenerating();
        }
    }
}
