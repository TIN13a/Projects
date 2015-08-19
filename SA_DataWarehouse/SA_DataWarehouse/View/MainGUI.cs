using SA_DataWarehouse.Helper;
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
            controller = new ETLController(logger);
        }

        private void label2_Click(object sender, EventArgs e) {

        }
    }
}
