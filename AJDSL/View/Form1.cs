﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AJDSL {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            PartsModel myModel = new PartsModel("(local)", "Parts");
            MessageBox.Show(myModel.printPartNumbers());


            //Create Controller
            PartsController PartController = new PartsController();

            //Load Tree
            PartController.loadForm();
        }

       
    }
}
