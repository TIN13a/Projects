namespace AJDSL {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.treeView = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbChilds = new System.Windows.Forms.ListBox();
            this.lbParents = new System.Windows.Forms.ListBox();
            this.tb_debug_id = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_save_part = new System.Windows.Forms.Button();
            this.btn_new_part = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_description = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_height = new System.Windows.Forms.TextBox();
            this.Breite = new System.Windows.Forms.Label();
            this.tb_width = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_length = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_weight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_mass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_partnr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tb_search_down = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lb_debug = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.HideSelection = false;
            this.treeView.Location = new System.Drawing.Point(12, 34);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(313, 578);
            this.treeView.TabIndex = 0;
            this.treeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_ItemDrag);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(345, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(479, 600);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.lbChilds);
            this.tabPage1.Controls.Add(this.lbParents);
            this.tabPage1.Controls.Add(this.tb_debug_id);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.btn_save_part);
            this.tabPage1.Controls.Add(this.btn_new_part);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.tb_description);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tb_height);
            this.tabPage1.Controls.Add(this.Breite);
            this.tabPage1.Controls.Add(this.tb_width);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tb_length);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.tb_weight);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tb_mass);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tb_partnr);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(471, 574);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Verwalten";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(244, 285);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(185, 16);
            this.label11.TabIndex = 24;
            this.label11.Text = "Untergeordnete Elemente";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 285);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(182, 16);
            this.label10.TabIndex = 23;
            this.label10.Text = "Übergeordnete Elemente";
            // 
            // lbChilds
            // 
            this.lbChilds.AllowDrop = true;
            this.lbChilds.FormattingEnabled = true;
            this.lbChilds.Location = new System.Drawing.Point(247, 317);
            this.lbChilds.Name = "lbChilds";
            this.lbChilds.Size = new System.Drawing.Size(211, 238);
            this.lbChilds.TabIndex = 22;
            this.lbChilds.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.lbChilds.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_DragEnter);
            // 
            // lbParents
            // 
            this.lbParents.AllowDrop = true;
            this.lbParents.FormattingEnabled = true;
            this.lbParents.Location = new System.Drawing.Point(14, 317);
            this.lbParents.Name = "lbParents";
            this.lbParents.Size = new System.Drawing.Size(216, 238);
            this.lbParents.TabIndex = 21;
            this.lbParents.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.lbParents.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_DragEnter);
            this.lbParents.DoubleClick += new System.EventHandler(this.listBox_removeRelationship);
            // 
            // tb_debug_id
            // 
            this.tb_debug_id.Location = new System.Drawing.Point(242, 212);
            this.tb_debug_id.Name = "tb_debug_id";
            this.tb_debug_id.Size = new System.Drawing.Size(40, 20);
            this.tb_debug_id.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(188, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Debug ID";
            // 
            // btn_save_part
            // 
            this.btn_save_part.Location = new System.Drawing.Point(269, 173);
            this.btn_save_part.Name = "btn_save_part";
            this.btn_save_part.Size = new System.Drawing.Size(75, 23);
            this.btn_save_part.TabIndex = 18;
            this.btn_save_part.Text = "Speichern";
            this.btn_save_part.UseVisualStyleBackColor = true;
            this.btn_save_part.Click += new System.EventHandler(this.btn_save_part_Click);
            // 
            // btn_new_part
            // 
            this.btn_new_part.Location = new System.Drawing.Point(188, 173);
            this.btn_new_part.Name = "btn_new_part";
            this.btn_new_part.Size = new System.Drawing.Size(75, 23);
            this.btn_new_part.TabIndex = 17;
            this.btn_new_part.Text = "Neu";
            this.btn_new_part.UseVisualStyleBackColor = true;
            this.btn_new_part.Click += new System.EventHandler(this.btn_new_part_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(185, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Beschreibung";
            // 
            // tb_description
            // 
            this.tb_description.Location = new System.Drawing.Point(188, 52);
            this.tb_description.Multiline = true;
            this.tb_description.Name = "tb_description";
            this.tb_description.Size = new System.Drawing.Size(270, 101);
            this.tb_description.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Höhe";
            // 
            // tb_height
            // 
            this.tb_height.Location = new System.Drawing.Point(14, 254);
            this.tb_height.Name = "tb_height";
            this.tb_height.Size = new System.Drawing.Size(152, 20);
            this.tb_height.TabIndex = 13;
            // 
            // Breite
            // 
            this.Breite.AutoSize = true;
            this.Breite.Location = new System.Drawing.Point(9, 199);
            this.Breite.Name = "Breite";
            this.Breite.Size = new System.Drawing.Size(34, 13);
            this.Breite.TabIndex = 12;
            this.Breite.Text = "Breite";
            // 
            // tb_width
            // 
            this.tb_width.Location = new System.Drawing.Point(12, 215);
            this.tb_width.Name = "tb_width";
            this.tb_width.Size = new System.Drawing.Size(152, 20);
            this.tb_width.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Länge";
            // 
            // tb_length
            // 
            this.tb_length.Location = new System.Drawing.Point(12, 173);
            this.tb_length.Name = "tb_length";
            this.tb_length.Size = new System.Drawing.Size(152, 20);
            this.tb_length.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Gewicht";
            // 
            // tb_weight
            // 
            this.tb_weight.Location = new System.Drawing.Point(11, 133);
            this.tb_weight.Name = "tb_weight";
            this.tb_weight.Size = new System.Drawing.Size(152, 20);
            this.tb_weight.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Masse";
            // 
            // tb_mass
            // 
            this.tb_mass.Location = new System.Drawing.Point(11, 91);
            this.tb_mass.Name = "tb_mass";
            this.tb_mass.Size = new System.Drawing.Size(152, 20);
            this.tb_mass.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nummer";
            // 
            // tb_partnr
            // 
            this.tb_partnr.Location = new System.Drawing.Point(11, 52);
            this.tb_partnr.Name = "tb_partnr";
            this.tb_partnr.Size = new System.Drawing.Size(152, 20);
            this.tb_partnr.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bestandteil";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tb_search_down);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(471, 574);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Suchen";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tb_search_down
            // 
            this.tb_search_down.Location = new System.Drawing.Point(10, 24);
            this.tb_search_down.Name = "tb_search_down";
            this.tb_search_down.Size = new System.Drawing.Size(207, 20);
            this.tb_search_down.TabIndex = 1;
            this.tb_search_down.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchTreeDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Nach Part Nummer";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Datenbank";
            // 
            // lb_debug
            // 
            this.lb_debug.FormattingEnabled = true;
            this.lb_debug.Location = new System.Drawing.Point(12, 619);
            this.lb_debug.Name = "lb_debug";
            this.lb_debug.Size = new System.Drawing.Size(808, 95);
            this.lb_debug.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 724);
            this.Controls.Add(this.lb_debug);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.treeView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_partnr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_mass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_length;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_weight;
        private System.Windows.Forms.Label Breite;
        private System.Windows.Forms.TextBox tb_width;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_description;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_height;
        private System.Windows.Forms.Button btn_save_part;
        private System.Windows.Forms.Button btn_new_part;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_debug_id;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lbChilds;
        private System.Windows.Forms.ListBox lbParents;
        private System.Windows.Forms.ListBox lb_debug;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_search_down;
    }
}

