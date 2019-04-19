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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblDate = new System.Windows.Forms.Label();
            this.LblArgent = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.LblNbrAnimaux = new System.Windows.Forms.Label();
            this.LblNbrDechets = new System.Windows.Forms.Label();
            this.EtatJeu = new TP2_Zoo.Etat.EtatJeu();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(100)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.LblNbrDechets);
            this.panel1.Controls.Add(this.LblNbrAnimaux);
            this.panel1.Controls.Add(this.LblDate);
            this.panel1.Controls.Add(this.LblArgent);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 88);
            this.panel1.TabIndex = 1;
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDate.ForeColor = System.Drawing.Color.White;
            this.LblDate.Location = new System.Drawing.Point(12, 10);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(75, 29);
            this.LblDate.TabIndex = 2;
            this.LblDate.Text = "Date :";
            // 
            // LblArgent
            // 
            this.LblArgent.AutoSize = true;
            this.LblArgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblArgent.ForeColor = System.Drawing.Color.White;
            this.LblArgent.Location = new System.Drawing.Point(12, 47);
            this.LblArgent.Name = "LblArgent";
            this.LblArgent.Size = new System.Drawing.Size(159, 29);
            this.LblArgent.TabIndex = 1;
            this.LblArgent.Text = "Argent : 100$ ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(60)))), ((int)(((byte)(16)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1280, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // LblNbrAnimaux
            // 
            this.LblNbrAnimaux.AutoSize = true;
            this.LblNbrAnimaux.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNbrAnimaux.ForeColor = System.Drawing.Color.White;
            this.LblNbrAnimaux.Location = new System.Drawing.Point(389, 10);
            this.LblNbrAnimaux.Name = "LblNbrAnimaux";
            this.LblNbrAnimaux.Size = new System.Drawing.Size(245, 29);
            this.LblNbrAnimaux.TabIndex = 3;
            this.LblNbrAnimaux.Text = "Nombre d\'animaux : 0";
            // 
            // LblNbrDechets
            // 
            this.LblNbrDechets.AutoSize = true;
            this.LblNbrDechets.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNbrDechets.ForeColor = System.Drawing.Color.White;
            this.LblNbrDechets.Location = new System.Drawing.Point(389, 47);
            this.LblNbrDechets.Name = "LblNbrDechets";
            this.LblNbrDechets.Size = new System.Drawing.Size(257, 29);
            this.LblNbrDechets.TabIndex = 4;
            this.LblNbrDechets.Text = "Nombre de dechets : 0";
            // 
            // EtatJeu
            // 
            this.EtatJeu.Location = new System.Drawing.Point(0, 112);
            this.EtatJeu.Name = "EtatJeu";
            this.EtatJeu.Size = new System.Drawing.Size(1280, 832);
            this.EtatJeu.TabIndex = 0;
            // 
            // Zoo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 944);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.EtatJeu);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Zoo";
            this.Text = "Zoo Tycoon";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Zoo_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Etat.EtatJeu EtatJeu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.Label LblArgent;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label LblNbrDechets;
        private System.Windows.Forms.Label LblNbrAnimaux;
    }
}

