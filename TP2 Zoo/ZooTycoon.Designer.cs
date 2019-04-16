namespace TP2_Zoo {
    partial class Zoo {
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent() {
            this.etatJeu1 = new TP2_Zoo.Etat.EtatJeu();
            this.SuspendLayout();
            // 
            // etatJeu1
            // 
            this.etatJeu1.Location = new System.Drawing.Point(0, 0);
            this.etatJeu1.Name = "etatJeu1";
            this.etatJeu1.Size = new System.Drawing.Size(1609, 762);
            this.etatJeu1.TabIndex = 0;
            // 
            // Zoo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 762);
            this.Controls.Add(this.etatJeu1);
            this.Name = "Zoo";
            this.Text = "Zoo Tycoon";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Zoo_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private Etat.EtatJeu etatJeu1;
    }
}

