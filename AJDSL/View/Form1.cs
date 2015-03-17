using System;
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
            //MessageBox.Show(myModel.printPartNumbers());


            //Create Controller
            PartsController PartController = new PartsController();
            List<Part> parts = PartController.loadForm();

            //Load Tree
            for (int i = 0; i < parts.Count; i++ ) {
                Part part = parts[i];

                TreeNode[] childs = addNodeChilds(part.getChilds());

                TreeNode node = new TreeNode(part.PartNumber, childs);

                treeView.Nodes.Add(node);
            }
        }

        //Create Treenodes
        private TreeNode[] addNodeChilds(List<Part> parts) {
            TreeNode[] childs = new TreeNode[parts.Count];

            int i = 0;
            foreach (Part part in parts) {
                if (part.getChilds().Count > 0) {
                    TreeNode[] partChilds = addNodeChilds(part.getChilds());

                    childs[i] = new TreeNode(part.PartNumber, partChilds);
                } else {
                    childs[i] = new TreeNode(part.PartNumber);
                }

                i++;
            }

            return childs;
        }
    }
}
