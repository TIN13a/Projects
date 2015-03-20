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
        private PartsController PartController = new PartsController();
        private List<Part> parts = new List<Part>();

        public Form1() {
            InitializeComponent();
        }

        //Load Form
        private void Form1_Load(object sender, EventArgs e) {


            parts = PartController.loadParts();
            this.loadTree(parts);

            //Add drag and drop handler
            // ---> Handlers are added in form designer
            /*this.treeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_ItemDrag);
            this.lbParents.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_DragEnter);
            this.lbChilds.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_DragEnter);
            this.lbParents.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.lbChilds.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);	  */
        }

        private void treeView_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e) {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void listBox_DragEnter(object sender, System.Windows.Forms.DragEventArgs e) {
            e.Effect = DragDropEffects.All;
        }

        private void listBox_DragDrop(object sender, System.Windows.Forms.DragEventArgs e) {
            TreeNode NewNode;

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false)) {
                NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");

                Part draggedPart = (Part)NewNode.Tag;
                TreeNode selectedNode = (TreeNode)treeView.SelectedNode;
                Part selectedPart = (Part)selectedNode.Tag;

                
                //Check if part can be added
                if (selectedPart.Id == draggedPart.Id){
                    return;
                }

                lb_debug.Items.Add("selected: " + selectedPart.Id + " -> " + selectedPart.ToString() + " dragged: " + draggedPart.Id + " -> " + draggedPart.ToString());

                //Add Part
                if (((ListBox)sender).Name == "lbParents") {
                    selectedPart.addParent(draggedPart);
                    draggedPart.addChild(draggedPart);
                } else {
                    selectedPart.addChild(draggedPart);
                    draggedPart.addParent(selectedPart);
                }

                //Refill form
                this.clearForm();
                //Reset Root nodes if parents
                parts = PartController.setRootNodes(parts);
                //Reload Tree
                this.loadTree(parts); 
            }
        }

        //Load Tree
        private void loadTree(List<Part> parts) {

            //Clear tree
            treeView.Nodes.Clear();

            //Load Tree
            for (int i = 0; i < parts.Count; i++) {
                Part part = parts[i];

                TreeNode[] childs = addNodeChilds(part.Childs);

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
                if (part.Childs.Count > 0) {
                    TreeNode[] partChilds = addNodeChilds(part.Childs);
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

        /// <summary>
        /// Load part data into edit form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e) {

            if (e.Node.Tag == null)
                return;
            
            //Get Part
            Part part = (Part)e.Node.Tag;

            //Clear form
            this.clearForm();

            //Refill form
            this.fillForm(part);
        }

        /// <summary>
        /// Clear form on click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_new_part_Click(object sender, EventArgs e) {
            MessageBox.Show(PartController.printPart(tb_partnr.Text));
            this.clearForm();
        }

        /// <summary>
        /// Save or update current part
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_part_Click(object sender, EventArgs e) {
            if (treeView.SelectedNode.Tag != null) {
                this.readForm((Part)treeView.SelectedNode.Tag);
            }
            Part part = new Part(-1, tb_partnr.Text.ToString());
            part.Mass = PartController.convertStringToFloat(tb_mass.Text.ToString());
            part.Weight = PartController.convertStringToFloat(tb_weight.Text.ToString());
            part.Length = PartController.convertStringToFloat(tb_length.Text.ToString());
            part.Width = PartController.convertStringToFloat(tb_width.Text.ToString());
            part.Height = PartController.convertStringToFloat(tb_height.Text.ToString());
            part.Description = tb_description.Text.ToString();
            if (PartController.savePart(part)) {
                PartController.showMessageInfo("Part wurde erfolgreich gespeichert.", "Info");
            }
            else {
                PartController.showMessageWarning("Part konnte nicht gespeichert werden.", "Warnung");
            }
            PartController.addPart();
        }

        /// <summary>
        /// Clear form to create a new part.
        /// </summary>
        private void clearForm() {
            tb_debug_id.Text = "";

            tb_partnr.Text = "";
            tb_description.Text = "";
            tb_mass.Text = "";
            tb_weight.Text = "";
            tb_width.Text = "";
            tb_height.Text = "";
            tb_length.Text = "";

            lbParents.Items.Clear();
            lbChilds.Items.Clear();
        }

        private void fillForm(Part part) {
            //debug parts id
            tb_debug_id.Text = part.Id.ToString();

            tb_partnr.Text = part.PartNumber;
            tb_description.Text = part.Description;
            tb_mass.Text = part.Mass.ToString();
            tb_weight.Text = part.Weight.ToString();
            tb_width.Text = part.Width.ToString();
            tb_height.Text = part.Height.ToString();
            tb_length.Text = part.Length.ToString();

            //List parents and childs
            foreach (Part parent in part.Parents) {
                lbParents.Items.Add(parent.PartNumber);
            }

            foreach (Part child in part.Childs) {
                lbChilds.Items.Add(child.PartNumber);
            }
        }

        private void readForm(Part part) {
            part.PartNumber = tb_partnr.Text;
            part.Description = tb_description.Text;

            float number;
            float.TryParse(tb_mass.Text, out number);
            part.Mass = number;
            float.TryParse(tb_weight.Text, out number);
            part.Weight = number;
            float.TryParse(tb_width.Text, out number);
            part.Width = number;
            float.TryParse(tb_height.Text, out number);
            part.Height = number;
            float.TryParse(tb_length.Text, out number);
            part.Length = number;
        }

        private void searchTreeDown(object sender, KeyEventArgs e) {
            TreeNode[] foundNodes = treeView.Nodes.Find(tb_search_down.Text, true);
            lb_debug.Items.AddRange(foundNodes);
        }
    }
}
