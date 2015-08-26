namespace SA_DataWarehouse {
    partial class MainGUI {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.lb_logger = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_gen_transactions = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Extract - Transform - Load";
            // 
            // lb_logger
            // 
            this.lb_logger.FormattingEnabled = true;
            this.lb_logger.Location = new System.Drawing.Point(16, 325);
            this.lb_logger.Name = "lb_logger";
            this.lb_logger.Size = new System.Drawing.Size(792, 212);
            this.lb_logger.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output:";
            // 
            // btn_gen_transactions
            // 
            this.btn_gen_transactions.Location = new System.Drawing.Point(680, 270);
            this.btn_gen_transactions.Name = "btn_gen_transactions";
            this.btn_gen_transactions.Size = new System.Drawing.Size(128, 23);
            this.btn_gen_transactions.TabIndex = 3;
            this.btn_gen_transactions.Text = "Gen. Transactions";
            this.btn_gen_transactions.UseVisualStyleBackColor = true;
            this.btn_gen_transactions.Click += new System.EventHandler(this.btn_gen_transactions_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(677, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Testen";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(16, 270);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(658, 23);
            this.progressBar.TabIndex = 6;
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 549);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_gen_transactions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_logger);
            this.Controls.Add(this.label1);
            this.Name = "MainGUI";
            this.Text = "ETL - A. Jörg, D. Lutz";
            this.Load += new System.EventHandler(this.MainGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lb_logger;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_gen_transactions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

