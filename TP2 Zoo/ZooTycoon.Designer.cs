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
            this.panel1 = new System.Windows.Forms.Panel();
            this.etatJeu1 = new TP2_Zoo.Etat.EtatJeu();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(154)))), ((int)(((byte)(66)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 68);
            this.panel1.TabIndex = 1;
            // 
            // etatJeu1
            // 
            this.etatJeu1.Location = new System.Drawing.Point(0, 68);
            this.etatJeu1.Name = "etatJeu1";
            this.etatJeu1.Size = new System.Drawing.Size(1280, 832);
            this.etatJeu1.TabIndex = 0;
            // 
            // Zoo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 900);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.etatJeu1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Zoo";
            this.Text = "Zoo Tycoon";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Zoo_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private Etat.EtatJeu etatJeu1;
        private System.Windows.Forms.Panel panel1;
    }
}

