namespace TP2_Zoo
{
    partial class InfosVisiteurs
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblDureeVisiteur = new System.Windows.Forms.Label();
            this.LblSexeVisiteur = new System.Windows.Forms.Label();
            this.LblNomVisiteur = new System.Windows.Forms.Label();
            this.LblDuree = new System.Windows.Forms.Label();
            this.LblSexe = new System.Windows.Forms.Label();
            this.LblNom = new System.Windows.Forms.Label();
            this.PctrBoxVisiteur = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctrBoxVisiteur)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblDureeVisiteur);
            this.panel1.Controls.Add(this.LblSexeVisiteur);
            this.panel1.Controls.Add(this.LblNomVisiteur);
            this.panel1.Controls.Add(this.LblDuree);
            this.panel1.Controls.Add(this.LblSexe);
            this.panel1.Controls.Add(this.LblNom);
            this.panel1.Location = new System.Drawing.Point(25, 256);
            this.panel1.Margin = new System.Windows.Forms.Padding(7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 216);
            this.panel1.TabIndex = 3;
            // 
            // LblDureeVisiteur
            // 
            this.LblDureeVisiteur.AutoSize = true;
            this.LblDureeVisiteur.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDureeVisiteur.Location = new System.Drawing.Point(268, 152);
            this.LblDureeVisiteur.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LblDureeVisiteur.Name = "LblDureeVisiteur";
            this.LblDureeVisiteur.Size = new System.Drawing.Size(259, 38);
            this.LblDureeVisiteur.TabIndex = 5;
            this.LblDureeVisiteur.Text = "Durée du visiteur";
            // 
            // LblSexeVisiteur
            // 
            this.LblSexeVisiteur.AutoSize = true;
            this.LblSexeVisiteur.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSexeVisiteur.Location = new System.Drawing.Point(127, 87);
            this.LblSexeVisiteur.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LblSexeVisiteur.Name = "LblSexeVisiteur";
            this.LblSexeVisiteur.Size = new System.Drawing.Size(243, 38);
            this.LblSexeVisiteur.TabIndex = 4;
            this.LblSexeVisiteur.Text = "Sexe du visiteur";
            // 
            // LblNomVisiteur
            // 
            this.LblNomVisiteur.AutoSize = true;
            this.LblNomVisiteur.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNomVisiteur.Location = new System.Drawing.Point(124, 20);
            this.LblNomVisiteur.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LblNomVisiteur.Name = "LblNomVisiteur";
            this.LblNomVisiteur.Size = new System.Drawing.Size(240, 38);
            this.LblNomVisiteur.TabIndex = 3;
            this.LblNomVisiteur.Text = "Nom du visiteur";
            // 
            // LblDuree
            // 
            this.LblDuree.AutoSize = true;
            this.LblDuree.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDuree.Location = new System.Drawing.Point(7, 152);
            this.LblDuree.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LblDuree.Name = "LblDuree";
            this.LblDuree.Size = new System.Drawing.Size(247, 38);
            this.LblDuree.TabIndex = 2;
            this.LblDuree.Text = "Durée de visite :";
            // 
            // LblSexe
            // 
            this.LblSexe.AutoSize = true;
            this.LblSexe.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSexe.Location = new System.Drawing.Point(7, 87);
            this.LblSexe.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LblSexe.Name = "LblSexe";
            this.LblSexe.Size = new System.Drawing.Size(106, 38);
            this.LblSexe.TabIndex = 1;
            this.LblSexe.Text = "Sexe :";
            // 
            // LblNom
            // 
            this.LblNom.AutoSize = true;
            this.LblNom.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNom.Location = new System.Drawing.Point(7, 20);
            this.LblNom.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LblNom.Name = "LblNom";
            this.LblNom.Size = new System.Drawing.Size(103, 38);
            this.LblNom.TabIndex = 0;
            this.LblNom.Text = "Nom :";
            // 
            // PctrBoxVisiteur
            // 
            this.PctrBoxVisiteur.Location = new System.Drawing.Point(184, 31);
            this.PctrBoxVisiteur.Margin = new System.Windows.Forms.Padding(7);
            this.PctrBoxVisiteur.Name = "PctrBoxVisiteur";
            this.PctrBoxVisiteur.Size = new System.Drawing.Size(210, 201);
            this.PctrBoxVisiteur.TabIndex = 2;
            this.PctrBoxVisiteur.TabStop = false;
            // 
            // InfosVisiteurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PctrBoxVisiteur);
            this.Name = "InfosVisiteurs";
            this.Size = new System.Drawing.Size(598, 524);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctrBoxVisiteur)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblDureeVisiteur;
        private System.Windows.Forms.Label LblSexeVisiteur;
        private System.Windows.Forms.Label LblNomVisiteur;
        private System.Windows.Forms.Label LblDuree;
        private System.Windows.Forms.Label LblSexe;
        private System.Windows.Forms.Label LblNom;
        private System.Windows.Forms.PictureBox PctrBoxVisiteur;
    }
}
