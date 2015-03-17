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
            List<Part> parts = PartController.loadParts();

            //Load Tree
            for (int i = 0; i < parts.Count; i++ ) {
                Part part = parts[i];

                TreeNode[] childs = addNodeChilds(part.getChilds());

                TreeNode node = new TreeNode(part.PartNumber, childs);
                node.Tag = part;
                treeView.Nodes.Add(node);
            }
        }

        //Create Treenodes
        private TreeNode[] addNodeChilds(List<Part> parts) {
            TreeNode[] childs = new TreeNode[parts.Count];

            int i = 0;
            foreach (Part part in parts) {

                TreeNode newNode;
                if (part.getChilds().Count > 0) {
                    TreeNode[] partChilds = addNodeChilds(part.getChilds());
                    newNode = new TreeNode(part.PartNumber, partChilds);
                } else {
                    newNode = new TreeNode(part.PartNumber);
                }

                newNode.Tag = part;
                childs[i] = newNode;

                i++;
            }

            return childs;
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e) {
            Part part = (Part)e.Node.Tag;

            //debug parts id
            tb_debug_id.Text = part.Id.ToString();

            tb_partnr.Text          = part.PartNumber;
            tb_description.Text     = part.Description;
            tb_mass.Text            = part.Mass.ToString();
            tb_weight.Text          = part.Weight.ToString();
            tb_width.Text          = part.Width.ToString();
            tb_height.Text          = part.Height.ToString();
            tb_length.Text          = part.Length.ToString();
        }
    }
}
