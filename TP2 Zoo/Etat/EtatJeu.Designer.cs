namespace TP2_Zoo.Etat {
    partial class EtatJeu {
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
            this.components = new System.ComponentModel.Container();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.ChoixAnimal = new TP2_Zoo.ChoixAnimal();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // ChoixAnimal
            // 
            this.ChoixAnimal.Location = new System.Drawing.Point(345, 239);
            this.ChoixAnimal.Name = "ChoixAnimal";
            this.ChoixAnimal.Size = new System.Drawing.Size(590, 322);
            this.ChoixAnimal.TabIndex = 0;
            this.ChoixAnimal.Visible = false;
            // 
            // EtatJeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ChoixAnimal);
            this.Name = "EtatJeu";
            this.Size = new System.Drawing.Size(1280, 800);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EtatJeu_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EtatJeu_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EtatJeu_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Timer;
        public ChoixAnimal ChoixAnimal;
    }
}
