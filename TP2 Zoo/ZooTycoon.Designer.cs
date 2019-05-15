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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PctBoxArgent = new System.Windows.Forms.PictureBox();
            this.PctrBoxCalendrier = new System.Windows.Forms.PictureBox();
            this.EngagerConcierge = new System.Windows.Forms.Button();
            this.LblNbrDechets = new System.Windows.Forms.Label();
            this.LblNbrAnimaux = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.LblArgent = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MnuToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemJouer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemQuitter = new System.Windows.Forms.ToolStripMenuItem();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctBoxArgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctrBoxCalendrier)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(100)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.PctBoxArgent);
            this.panel1.Controls.Add(this.PctrBoxCalendrier);
            this.panel1.Controls.Add(this.EngagerConcierge);
            this.panel1.Controls.Add(this.LblNbrDechets);
            this.panel1.Controls.Add(this.LblNbrAnimaux);
            this.panel1.Controls.Add(this.LblDate);
            this.panel1.Controls.Add(this.LblArgent);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 88);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(955, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Engager Concierge : ";
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
            // EngagerConcierge
            // 
            this.EngagerConcierge.BackgroundImage = global::TP2_Zoo.Properties.Resources.Concierge;
            this.EngagerConcierge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EngagerConcierge.Location = new System.Drawing.Point(1202, 0);
            this.EngagerConcierge.Name = "EngagerConcierge";
            this.EngagerConcierge.Size = new System.Drawing.Size(75, 78);
            this.EngagerConcierge.TabIndex = 5;
            this.EngagerConcierge.UseVisualStyleBackColor = true;
            this.EngagerConcierge.Click += new System.EventHandler(this.EngagerConcierge_Click);
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
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(60)))), ((int)(((byte)(16)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuToolStripMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1280, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
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
            this.ToolStripMenuItemJouer.Size = new System.Drawing.Size(111, 22);
            this.ToolStripMenuItemJouer.Text = "Jouer";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(108, 6);
            // 
            // ToolStripMenuItemQuitter
            // 
            this.ToolStripMenuItemQuitter.Name = "ToolStripMenuItemQuitter";
            this.ToolStripMenuItemQuitter.Size = new System.Drawing.Size(111, 22);
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
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Zoo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zoo Tycoon";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Zoo_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctBoxArgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctrBoxCalendrier)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MnuToolStripMenu;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Timer Timer;
        public System.Windows.Forms.Label LblArgent;
        public System.Windows.Forms.Label LblNbrAnimaux;
        public System.Windows.Forms.Label LblNbrDechets;
        private System.Windows.Forms.Button EngagerConcierge;
        private System.Windows.Forms.PictureBox PctrBoxCalendrier;
        private System.Windows.Forms.PictureBox PctBoxArgent;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemJouer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemQuitter;
        private System.Windows.Forms.Label label1;
    }
}

