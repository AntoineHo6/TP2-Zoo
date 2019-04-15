namespace TP2_Zoo {
    partial class InfosAnimaux {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent() {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LblNom = new System.Windows.Forms.Label();
            this.LblType = new System.Windows.Forms.Label();
            this.LblGenre = new System.Windows.Forms.Label();
            this.LblAge = new System.Windows.Forms.Label();
            this.LblFaim = new System.Windows.Forms.Label();
            this.LblEnceinte = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(25, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LblNom
            // 
            this.LblNom.AutoSize = true;
            this.LblNom.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNom.Location = new System.Drawing.Point(109, 25);
            this.LblNom.Name = "LblNom";
            this.LblNom.Size = new System.Drawing.Size(47, 17);
            this.LblNom.TabIndex = 1;
            this.LblNom.Text = "Nom :";
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblType.Location = new System.Drawing.Point(109, 58);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(47, 17);
            this.LblType.TabIndex = 2;
            this.LblType.Text = "Type :";
            // 
            // LblGenre
            // 
            this.LblGenre.AutoSize = true;
            this.LblGenre.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGenre.Location = new System.Drawing.Point(22, 100);
            this.LblGenre.Name = "LblGenre";
            this.LblGenre.Size = new System.Drawing.Size(56, 17);
            this.LblGenre.TabIndex = 3;
            this.LblGenre.Text = "Genre :";
            // 
            // LblAge
            // 
            this.LblAge.AutoSize = true;
            this.LblAge.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAge.Location = new System.Drawing.Point(22, 132);
            this.LblAge.Name = "LblAge";
            this.LblAge.Size = new System.Drawing.Size(41, 17);
            this.LblAge.TabIndex = 4;
            this.LblAge.Text = "Âge :";
            // 
            // LblFaim
            // 
            this.LblFaim.AutoSize = true;
            this.LblFaim.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFaim.Location = new System.Drawing.Point(22, 166);
            this.LblFaim.Name = "LblFaim";
            this.LblFaim.Size = new System.Drawing.Size(49, 17);
            this.LblFaim.TabIndex = 5;
            this.LblFaim.Text = "Faim :";
            // 
            // LblEnceinte
            // 
            this.LblEnceinte.AutoSize = true;
            this.LblEnceinte.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEnceinte.Location = new System.Drawing.Point(22, 200);
            this.LblEnceinte.Name = "LblEnceinte";
            this.LblEnceinte.Size = new System.Drawing.Size(73, 17);
            this.LblEnceinte.TabIndex = 6;
            this.LblEnceinte.Text = "Enceinte :";
            // 
            // InfosAnimaux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LblEnceinte);
            this.Controls.Add(this.LblFaim);
            this.Controls.Add(this.LblAge);
            this.Controls.Add(this.LblGenre);
            this.Controls.Add(this.LblType);
            this.Controls.Add(this.LblNom);
            this.Controls.Add(this.pictureBox1);
            this.Name = "InfosAnimaux";
            this.Size = new System.Drawing.Size(295, 238);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblNom;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.Label LblGenre;
        private System.Windows.Forms.Label LblAge;
        private System.Windows.Forms.Label LblFaim;
        private System.Windows.Forms.Label LblEnceinte;
    }
}
