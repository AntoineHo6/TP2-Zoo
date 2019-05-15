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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Zoo));
            this.PnlInfosJoueur = new System.Windows.Forms.Panel();
            this.LblEngagerConcierge = new System.Windows.Forms.Label();
            this.PctBoxArgent = new System.Windows.Forms.PictureBox();
            this.PctrBoxCalendrier = new System.Windows.Forms.PictureBox();
            this.BtnEngagerConcierge = new System.Windows.Forms.Button();
            this.LblNbrDechets = new System.Windows.Forms.Label();
            this.LblNbrAnimaux = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.LblArgent = new System.Windows.Forms.Label();
            this.MnuStrip = new System.Windows.Forms.MenuStrip();
            this.MnuToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemJouer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemQuitter = new System.Windows.Forms.ToolStripMenuItem();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.PnlInfosJoueur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctBoxArgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctrBoxCalendrier)).BeginInit();
            this.MnuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlInfosJoueur
            // 
            this.PnlInfosJoueur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(100)))), ((int)(((byte)(40)))));
            this.PnlInfosJoueur.Controls.Add(this.LblEngagerConcierge);
            this.PnlInfosJoueur.Controls.Add(this.PctBoxArgent);
            this.PnlInfosJoueur.Controls.Add(this.PctrBoxCalendrier);
            this.PnlInfosJoueur.Controls.Add(this.BtnEngagerConcierge);
            this.PnlInfosJoueur.Controls.Add(this.LblNbrDechets);
            this.PnlInfosJoueur.Controls.Add(this.LblNbrAnimaux);
            this.PnlInfosJoueur.Controls.Add(this.LblDate);
            this.PnlInfosJoueur.Controls.Add(this.LblArgent);
            this.PnlInfosJoueur.Location = new System.Drawing.Point(0, 24);
            this.PnlInfosJoueur.Name = "PnlInfosJoueur";
            this.PnlInfosJoueur.Size = new System.Drawing.Size(1280, 88);
            this.PnlInfosJoueur.TabIndex = 1;
            // 
            // LblEngagerConcierge
            // 
            this.LblEngagerConcierge.AutoSize = true;
            this.LblEngagerConcierge.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEngagerConcierge.ForeColor = System.Drawing.SystemColors.Control;
            this.LblEngagerConcierge.Location = new System.Drawing.Point(953, 26);
            this.LblEngagerConcierge.Name = "LblEngagerConcierge";
            this.LblEngagerConcierge.Size = new System.Drawing.Size(241, 29);
            this.LblEngagerConcierge.TabIndex = 8;
            this.LblEngagerConcierge.Text = "Engager Concierge : ";
            // 
            // PctBoxArgent
            // 
            this.PctBoxArgent.BackColor = System.Drawing.Color.Transparent;
            this.PctBoxArgent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PctBoxArgent.Image = ((System.Drawing.Image)(resources.GetObject("PctBoxArgent.Image")));
            this.PctBoxArgent.Location = new System.Drawing.Point(10, 47);
            this.PctBoxArgent.Name = "PctBoxArgent";
            this.PctBoxArgent.Size = new System.Drawing.Size(35, 35);
            this.PctBoxArgent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PctBoxArgent.TabIndex = 7;
            this.PctBoxArgent.TabStop = false;
            // 
            // PctrBoxCalendrier
            // 
            this.PctrBoxCalendrier.BackColor = System.Drawing.Color.Transparent;
            this.PctrBoxCalendrier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PctrBoxCalendrier.Image = ((System.Drawing.Image)(resources.GetObject("PctrBoxCalendrier.Image")));
            this.PctrBoxCalendrier.Location = new System.Drawing.Point(10, 6);
            this.PctrBoxCalendrier.Name = "PctrBoxCalendrier";
            this.PctrBoxCalendrier.Size = new System.Drawing.Size(35, 35);
            this.PctrBoxCalendrier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PctrBoxCalendrier.TabIndex = 6;
            this.PctrBoxCalendrier.TabStop = false;
            // 
            // BtnEngagerConcierge
            // 
            this.BtnEngagerConcierge.BackgroundImage = global::TP2_Zoo.Properties.Resources.Concierge;
            this.BtnEngagerConcierge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnEngagerConcierge.Location = new System.Drawing.Point(1200, 5);
            this.BtnEngagerConcierge.Name = "BtnEngagerConcierge";
            this.BtnEngagerConcierge.Size = new System.Drawing.Size(75, 78);
            this.BtnEngagerConcierge.TabIndex = 5;
            this.BtnEngagerConcierge.UseVisualStyleBackColor = true;
            this.BtnEngagerConcierge.Click += new System.EventHandler(this.EngagerConcierge_Click);
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
            this.LblNbrDechets.Text = "Nombre de déchets : 0";
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
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDate.ForeColor = System.Drawing.Color.White;
            this.LblDate.Location = new System.Drawing.Point(49, 12);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(63, 29);
            this.LblDate.TabIndex = 2;
            this.LblDate.Text = "Date";
            // 
            // LblArgent
            // 
            this.LblArgent.AutoSize = true;
            this.LblArgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblArgent.ForeColor = System.Drawing.Color.White;
            this.LblArgent.Location = new System.Drawing.Point(54, 50);
            this.LblArgent.Name = "LblArgent";
            this.LblArgent.Size = new System.Drawing.Size(71, 29);
            this.LblArgent.TabIndex = 1;
            this.LblArgent.Text = "100 $";
            // 
            // MnuStrip
            // 
            this.MnuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(60)))), ((int)(((byte)(16)))));
            this.MnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuToolStripMenu});
            this.MnuStrip.Location = new System.Drawing.Point(0, 0);
            this.MnuStrip.Name = "MnuStrip";
            this.MnuStrip.Size = new System.Drawing.Size(1280, 24);
            this.MnuStrip.TabIndex = 2;
            this.MnuStrip.Text = "menuStrip1";
            // 
            // MnuToolStripMenu
            // 
            this.MnuToolStripMenu.BackColor = System.Drawing.Color.Transparent;
            this.MnuToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemJouer,
            this.toolStripSeparator1,
            this.ToolStripMenuItemQuitter});
            this.MnuToolStripMenu.ForeColor = System.Drawing.Color.White;
            this.MnuToolStripMenu.Name = "MnuToolStripMenu";
            this.MnuToolStripMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.MnuToolStripMenu.Size = new System.Drawing.Size(50, 20);
            this.MnuToolStripMenu.Text = "Menu";
            // 
            // ToolStripMenuItemJouer
            // 
            this.ToolStripMenuItemJouer.Name = "ToolStripMenuItemJouer";
            this.ToolStripMenuItemJouer.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemJouer.Text = "Jouer";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // ToolStripMenuItemQuitter
            // 
            this.ToolStripMenuItemQuitter.Name = "ToolStripMenuItemQuitter";
            this.ToolStripMenuItemQuitter.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemQuitter.Text = "Quitter";
            this.ToolStripMenuItemQuitter.Click += new System.EventHandler(this.ToolStripMenuItemQuitter_Click);
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Zoo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 944);
            this.Controls.Add(this.PnlInfosJoueur);
            this.Controls.Add(this.MnuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.MnuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Zoo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zoo Tycoon";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Zoo_KeyDown);
            this.PnlInfosJoueur.ResumeLayout(false);
            this.PnlInfosJoueur.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctBoxArgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctrBoxCalendrier)).EndInit();
            this.MnuStrip.ResumeLayout(false);
            this.MnuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel PnlInfosJoueur;
        private System.Windows.Forms.MenuStrip MnuStrip;
        private System.Windows.Forms.ToolStripMenuItem MnuToolStripMenu;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Timer Timer;
        public System.Windows.Forms.Label LblArgent;
        public System.Windows.Forms.Label LblNbrAnimaux;
        public System.Windows.Forms.Label LblNbrDechets;
        private System.Windows.Forms.Button BtnEngagerConcierge;
        private System.Windows.Forms.PictureBox PctrBoxCalendrier;
        private System.Windows.Forms.PictureBox PctBoxArgent;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemJouer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemQuitter;
        private System.Windows.Forms.Label LblEngagerConcierge;
    }
}

