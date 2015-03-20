namespace Patientensystem
{
    partial class Patientenstudie
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.gb_patient = new System.Windows.Forms.GroupBox();
            this.cmd_show_p = new System.Windows.Forms.Button();
            this.cmd_add_p = new System.Windows.Forms.Button();
            this.lbl_ausgabe_p = new System.Windows.Forms.Label();
            this.txt_patient = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.gb_arzt = new System.Windows.Forms.GroupBox();
            this.cmd_show_a = new System.Windows.Forms.Button();
            this.lbl_ausgabe_a = new System.Windows.Forms.Label();
            this.cmd_add_a = new System.Windows.Forms.Button();
            this.txt_befund = new System.Windows.Forms.TextBox();
            this.lbl_befund = new System.Windows.Forms.Label();
            this.lbl_Titel = new System.Windows.Forms.Label();
            this.gb_patient.SuspendLayout();
            this.gb_arzt.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_patient
            // 
            this.gb_patient.Controls.Add(this.cmd_show_p);
            this.gb_patient.Controls.Add(this.cmd_add_p);
            this.gb_patient.Controls.Add(this.lbl_ausgabe_p);
            this.gb_patient.Controls.Add(this.txt_patient);
            this.gb_patient.Controls.Add(this.lbl_name);
            this.gb_patient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_patient.Location = new System.Drawing.Point(12, 61);
            this.gb_patient.Name = "gb_patient";
            this.gb_patient.Size = new System.Drawing.Size(419, 135);
            this.gb_patient.TabIndex = 0;
            this.gb_patient.TabStop = false;
            this.gb_patient.Text = "Patient";
            // 
            // cmd_show_p
            // 
            this.cmd_show_p.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_show_p.Location = new System.Drawing.Point(338, 106);
            this.cmd_show_p.Name = "cmd_show_p";
            this.cmd_show_p.Size = new System.Drawing.Size(75, 23);
            this.cmd_show_p.TabIndex = 4;
            this.cmd_show_p.Text = "Show";
            this.cmd_show_p.UseVisualStyleBackColor = true;
            this.cmd_show_p.Click += new System.EventHandler(this.cmd_show_p_Click);
            // 
            // cmd_add_p
            // 
            this.cmd_add_p.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_add_p.Location = new System.Drawing.Point(257, 106);
            this.cmd_add_p.Name = "cmd_add_p";
            this.cmd_add_p.Size = new System.Drawing.Size(75, 23);
            this.cmd_add_p.TabIndex = 3;
            this.cmd_add_p.Text = "Add";
            this.cmd_add_p.UseVisualStyleBackColor = true;
            this.cmd_add_p.Click += new System.EventHandler(this.cmd_add_p_Click);
            // 
            // lbl_ausgabe_p
            // 
            this.lbl_ausgabe_p.AutoSize = true;
            this.lbl_ausgabe_p.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ausgabe_p.Location = new System.Drawing.Point(162, 29);
            this.lbl_ausgabe_p.Name = "lbl_ausgabe_p";
            this.lbl_ausgabe_p.Size = new System.Drawing.Size(52, 13);
            this.lbl_ausgabe_p.TabIndex = 2;
            this.lbl_ausgabe_p.Text = "Ausgabe:";
            // 
            // txt_patient
            // 
            this.txt_patient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_patient.Location = new System.Drawing.Point(56, 26);
            this.txt_patient.Name = "txt_patient";
            this.txt_patient.Size = new System.Drawing.Size(100, 20);
            this.txt_patient.TabIndex = 1;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(6, 29);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(38, 13);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "Name:";
            // 
            // gb_arzt
            // 
            this.gb_arzt.Controls.Add(this.cmd_show_a);
            this.gb_arzt.Controls.Add(this.lbl_ausgabe_a);
            this.gb_arzt.Controls.Add(this.cmd_add_a);
            this.gb_arzt.Controls.Add(this.txt_befund);
            this.gb_arzt.Controls.Add(this.lbl_befund);
            this.gb_arzt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_arzt.Location = new System.Drawing.Point(437, 61);
            this.gb_arzt.Name = "gb_arzt";
            this.gb_arzt.Size = new System.Drawing.Size(419, 135);
            this.gb_arzt.TabIndex = 1;
            this.gb_arzt.TabStop = false;
            this.gb_arzt.Text = "Hausarzt";
            // 
            // cmd_show_a
            // 
            this.cmd_show_a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_show_a.Location = new System.Drawing.Point(338, 106);
            this.cmd_show_a.Name = "cmd_show_a";
            this.cmd_show_a.Size = new System.Drawing.Size(75, 23);
            this.cmd_show_a.TabIndex = 6;
            this.cmd_show_a.Text = "Show";
            this.cmd_show_a.UseVisualStyleBackColor = true;
            this.cmd_show_a.Click += new System.EventHandler(this.cmd_show_a_Click);
            // 
            // lbl_ausgabe_a
            // 
            this.lbl_ausgabe_a.AutoSize = true;
            this.lbl_ausgabe_a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ausgabe_a.Location = new System.Drawing.Point(162, 29);
            this.lbl_ausgabe_a.Name = "lbl_ausgabe_a";
            this.lbl_ausgabe_a.Size = new System.Drawing.Size(52, 13);
            this.lbl_ausgabe_a.TabIndex = 3;
            this.lbl_ausgabe_a.Text = "Ausgabe:";
            // 
            // cmd_add_a
            // 
            this.cmd_add_a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_add_a.Location = new System.Drawing.Point(257, 106);
            this.cmd_add_a.Name = "cmd_add_a";
            this.cmd_add_a.Size = new System.Drawing.Size(75, 23);
            this.cmd_add_a.TabIndex = 5;
            this.cmd_add_a.Text = "Add";
            this.cmd_add_a.UseVisualStyleBackColor = true;
            this.cmd_add_a.Click += new System.EventHandler(this.cmd_add_a_Click);
            // 
            // txt_befund
            // 
            this.txt_befund.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_befund.Location = new System.Drawing.Point(56, 26);
            this.txt_befund.Name = "txt_befund";
            this.txt_befund.Size = new System.Drawing.Size(100, 20);
            this.txt_befund.TabIndex = 2;
            // 
            // lbl_befund
            // 
            this.lbl_befund.AutoSize = true;
            this.lbl_befund.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_befund.Location = new System.Drawing.Point(6, 29);
            this.lbl_befund.Name = "lbl_befund";
            this.lbl_befund.Size = new System.Drawing.Size(44, 13);
            this.lbl_befund.TabIndex = 1;
            this.lbl_befund.Text = "Befund:";
            // 
            // lbl_Titel
            // 
            this.lbl_Titel.AutoSize = true;
            this.lbl_Titel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titel.Location = new System.Drawing.Point(21, 13);
            this.lbl_Titel.Name = "lbl_Titel";
            this.lbl_Titel.Size = new System.Drawing.Size(146, 24);
            this.lbl_Titel.TabIndex = 2;
            this.lbl_Titel.Text = "Patientensystem";
            // 
            // Patientenstudie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 219);
            this.Controls.Add(this.lbl_Titel);
            this.Controls.Add(this.gb_arzt);
            this.Controls.Add(this.gb_patient);
            this.Name = "Patientenstudie";
            this.Text = "Patientensystem Fallstudie";
            this.gb_patient.ResumeLayout(false);
            this.gb_patient.PerformLayout();
            this.gb_arzt.ResumeLayout(false);
            this.gb_arzt.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_patient;
        private System.Windows.Forms.Button cmd_show_p;
        private System.Windows.Forms.Button cmd_add_p;
        private System.Windows.Forms.Label lbl_ausgabe_p;
        private System.Windows.Forms.TextBox txt_patient;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.GroupBox gb_arzt;
        private System.Windows.Forms.Button cmd_show_a;
        private System.Windows.Forms.Label lbl_ausgabe_a;
        private System.Windows.Forms.Button cmd_add_a;
        private System.Windows.Forms.TextBox txt_befund;
        private System.Windows.Forms.Label lbl_befund;
        private System.Windows.Forms.Label lbl_Titel;
    }
}

