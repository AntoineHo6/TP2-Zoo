namespace TP2_Zoo
{
    partial class FrmInfosVisiteurs
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
            this.PctrBoxVisiteur = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblNom = new System.Windows.Forms.Label();
            this.LblSexe = new System.Windows.Forms.Label();
            this.LblDuree = new System.Windows.Forms.Label();
            this.LblNomVisiteur = new System.Windows.Forms.Label();
            this.LblSexeVisiteur = new System.Windows.Forms.Label();
            this.LblDureeVisiteur = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PctrBoxVisiteur)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PctrBoxVisiteur
            // 
            this.PctrBoxVisiteur.Location = new System.Drawing.Point(102, 21);
            this.PctrBoxVisiteur.Name = "PctrBoxVisiteur";
            this.PctrBoxVisiteur.Size = new System.Drawing.Size(90, 90);
            this.PctrBoxVisiteur.TabIndex = 0;
            this.PctrBoxVisiteur.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblDureeVisiteur);
            this.panel1.Controls.Add(this.LblSexeVisiteur);
            this.panel1.Controls.Add(this.LblNomVisiteur);
            this.panel1.Controls.Add(this.LblDuree);
            this.panel1.Controls.Add(this.LblSexe);
            this.panel1.Controls.Add(this.LblNom);
            this.panel1.Location = new System.Drawing.Point(12, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 157);
            this.panel1.TabIndex = 1;
            // 
            // LblNom
            // 
            this.LblNom.AutoSize = true;
            this.LblNom.Location = new System.Drawing.Point(3, 9);
            this.LblNom.Name = "LblNom";
            this.LblNom.Size = new System.Drawing.Size(35, 13);
            this.LblNom.TabIndex = 0;
            this.LblNom.Text = "Nom :";
            // 
            // LblSexe
            // 
            this.LblSexe.AutoSize = true;
            this.LblSexe.Location = new System.Drawing.Point(3, 39);
            this.LblSexe.Name = "LblSexe";
            this.LblSexe.Size = new System.Drawing.Size(37, 13);
            this.LblSexe.TabIndex = 1;
            this.LblSexe.Text = "Sexe :";
            // 
            // LblDuree
            // 
            this.LblDuree.AutoSize = true;
            this.LblDuree.Location = new System.Drawing.Point(3, 68);
            this.LblDuree.Name = "LblDuree";
            this.LblDuree.Size = new System.Drawing.Size(84, 13);
            this.LblDuree.TabIndex = 2;
            this.LblDuree.Text = "Durée de visite :";
            // 
            // LblNomVisiteur
            // 
            this.LblNomVisiteur.AutoSize = true;
            this.LblNomVisiteur.Location = new System.Drawing.Point(44, 9);
            this.LblNomVisiteur.Name = "LblNomVisiteur";
            this.LblNomVisiteur.Size = new System.Drawing.Size(80, 13);
            this.LblNomVisiteur.TabIndex = 3;
            this.LblNomVisiteur.Text = "Nom du visiteur";
            // 
            // LblSexeVisiteur
            // 
            this.LblSexeVisiteur.AutoSize = true;
            this.LblSexeVisiteur.Location = new System.Drawing.Point(46, 39);
            this.LblSexeVisiteur.Name = "LblSexeVisiteur";
            this.LblSexeVisiteur.Size = new System.Drawing.Size(82, 13);
            this.LblSexeVisiteur.TabIndex = 4;
            this.LblSexeVisiteur.Text = "Sexe du visiteur";
            // 
            // LblDureeVisiteur
            // 
            this.LblDureeVisiteur.AutoSize = true;
            this.LblDureeVisiteur.Location = new System.Drawing.Point(93, 68);
            this.LblDureeVisiteur.Name = "LblDureeVisiteur";
            this.LblDureeVisiteur.Size = new System.Drawing.Size(87, 13);
            this.LblDureeVisiteur.TabIndex = 5;
            this.LblDureeVisiteur.Text = "Durée du visiteur";
            // 
            // FrmInfosVisiteurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 296);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PctrBoxVisiteur);
            this.Name = "FrmInfosVisiteurs";
            this.Text = "InfosVisiteur";
            ((System.ComponentModel.ISupportInitialize)(this.PctrBoxVisiteur)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PctrBoxVisiteur;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblDuree;
        private System.Windows.Forms.Label LblSexe;
        private System.Windows.Forms.Label LblNom;
        private System.Windows.Forms.Label LblDureeVisiteur;
        private System.Windows.Forms.Label LblSexeVisiteur;
        private System.Windows.Forms.Label LblNomVisiteur;
    }
}