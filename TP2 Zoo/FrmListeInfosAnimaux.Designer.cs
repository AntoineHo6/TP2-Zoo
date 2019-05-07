namespace TP2_Zoo
{
    partial class FrmListeInfosAnimaux
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListeInfosAnimaux));
            this.FlpListeInfosAnimaux = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // FlpListeInfosAnimaux
            // 
            this.FlpListeInfosAnimaux.Location = new System.Drawing.Point(3, 3);
            this.FlpListeInfosAnimaux.Name = "FlpListeInfosAnimaux";
            this.FlpListeInfosAnimaux.Size = new System.Drawing.Size(281, 296);
            this.FlpListeInfosAnimaux.TabIndex = 0;
            // 
            // FrmListeInfosAnimaux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 300);
            this.Controls.Add(this.FlpListeInfosAnimaux);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListeInfosAnimaux";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liste d\'animaux";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FlpListeInfosAnimaux;
    }
}