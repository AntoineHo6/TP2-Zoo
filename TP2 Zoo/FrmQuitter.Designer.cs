namespace TP2_Zoo {
    partial class FrmQuitter {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuitter));
            this.LblMontantTotal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PctrBoxProfit = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctrBoxProfit)).BeginInit();
            this.SuspendLayout();
            // 
            // LblMontantTotal
            // 
            this.LblMontantTotal.AutoSize = true;
            this.LblMontantTotal.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMontantTotal.Location = new System.Drawing.Point(91, 61);
            this.LblMontantTotal.Name = "LblMontantTotal";
            this.LblMontantTotal.Size = new System.Drawing.Size(78, 33);
            this.LblMontantTotal.TabIndex = 1;
            this.LblMontantTotal.Text = "Profit";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.PctrBoxProfit);
            this.panel1.Controls.Add(this.LblMontantTotal);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 113);
            this.panel1.TabIndex = 2;
            // 
            // PctrBoxProfit
            // 
            this.PctrBoxProfit.Image = global::TP2_Zoo.Properties.Resources.Profit_Logo;
            this.PctrBoxProfit.Location = new System.Drawing.Point(3, 19);
            this.PctrBoxProfit.Name = "PctrBoxProfit";
            this.PctrBoxProfit.Size = new System.Drawing.Size(75, 75);
            this.PctrBoxProfit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PctrBoxProfit.TabIndex = 2;
            this.PctrBoxProfit.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Profit :";
            // 
            // FrmQuitter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 137);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuitter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profit Total";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmQuitter_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctrBoxProfit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblMontantTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox PctrBoxProfit;
        private System.Windows.Forms.Label label1;
    }
}