namespace TP2_Zoo {
    partial class ChoixAnimal {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.BtnMouton = new System.Windows.Forms.Button();
            this.BtnLion = new System.Windows.Forms.Button();
            this.BtnLicorne = new System.Windows.Forms.Button();
            this.LblPrixMouton = new System.Windows.Forms.Label();
            this.LblPrixLion = new System.Windows.Forms.Label();
            this.LblPrixLicorne = new System.Windows.Forms.Label();
            this.LblEscape = new System.Windows.Forms.Label();
            this.LblMouton = new System.Windows.Forms.Label();
            this.LblLion = new System.Windows.Forms.Label();
            this.LblLicorne = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnMouton
            // 
            this.BtnMouton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnMouton.Location = new System.Drawing.Point(50, 50);
            this.BtnMouton.Name = "BtnMouton";
            this.BtnMouton.Size = new System.Drawing.Size(130, 130);
            this.BtnMouton.TabIndex = 0;
            this.BtnMouton.UseVisualStyleBackColor = true;
            this.BtnMouton.Click += new System.EventHandler(this.BtnMouton_Click);
            // 
            // BtnLion
            // 
            this.BtnLion.Location = new System.Drawing.Point(230, 50);
            this.BtnLion.Name = "BtnLion";
            this.BtnLion.Size = new System.Drawing.Size(130, 130);
            this.BtnLion.TabIndex = 1;
            this.BtnLion.UseVisualStyleBackColor = true;
            this.BtnLion.Click += new System.EventHandler(this.BtnLion_Click);
            // 
            // BtnLicorne
            // 
            this.BtnLicorne.Location = new System.Drawing.Point(410, 50);
            this.BtnLicorne.Name = "BtnLicorne";
            this.BtnLicorne.Size = new System.Drawing.Size(130, 130);
            this.BtnLicorne.TabIndex = 2;
            this.BtnLicorne.UseVisualStyleBackColor = true;
            this.BtnLicorne.Click += new System.EventHandler(this.BtnLicorne_Click);
            // 
            // LblPrixMouton
            // 
            this.LblPrixMouton.AutoSize = true;
            this.LblPrixMouton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPrixMouton.Location = new System.Drawing.Point(92, 183);
            this.LblPrixMouton.Name = "LblPrixMouton";
            this.LblPrixMouton.Size = new System.Drawing.Size(48, 25);
            this.LblPrixMouton.TabIndex = 3;
            this.LblPrixMouton.Text = "20$";
            // 
            // LblPrixLion
            // 
            this.LblPrixLion.AutoSize = true;
            this.LblPrixLion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPrixLion.Location = new System.Drawing.Point(276, 183);
            this.LblPrixLion.Name = "LblPrixLion";
            this.LblPrixLion.Size = new System.Drawing.Size(48, 25);
            this.LblPrixLion.TabIndex = 4;
            this.LblPrixLion.Text = "35$";
            // 
            // LblPrixLicorne
            // 
            this.LblPrixLicorne.AutoSize = true;
            this.LblPrixLicorne.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPrixLicorne.Location = new System.Drawing.Point(454, 183);
            this.LblPrixLicorne.Name = "LblPrixLicorne";
            this.LblPrixLicorne.Size = new System.Drawing.Size(48, 25);
            this.LblPrixLicorne.TabIndex = 5;
            this.LblPrixLicorne.Text = "50$";
            // 
            // LblEscape
            // 
            this.LblEscape.AutoSize = true;
            this.LblEscape.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEscape.Location = new System.Drawing.Point(3, 292);
            this.LblEscape.Name = "LblEscape";
            this.LblEscape.Size = new System.Drawing.Size(121, 20);
            this.LblEscape.TabIndex = 6;
            this.LblEscape.Text = "(Esc pour sortir)";
            // 
            // LblMouton
            // 
            this.LblMouton.AutoSize = true;
            this.LblMouton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMouton.Location = new System.Drawing.Point(80, 23);
            this.LblMouton.Name = "LblMouton";
            this.LblMouton.Size = new System.Drawing.Size(74, 24);
            this.LblMouton.TabIndex = 7;
            this.LblMouton.Text = "Mouton";
            // 
            // LblLion
            // 
            this.LblLion.AutoSize = true;
            this.LblLion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLion.Location = new System.Drawing.Point(277, 23);
            this.LblLion.Name = "LblLion";
            this.LblLion.Size = new System.Drawing.Size(46, 24);
            this.LblLion.TabIndex = 8;
            this.LblLion.Text = "Lion";
            // 
            // LblLicorne
            // 
            this.LblLicorne.AutoSize = true;
            this.LblLicorne.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLicorne.Location = new System.Drawing.Point(441, 23);
            this.LblLicorne.Name = "LblLicorne";
            this.LblLicorne.Size = new System.Drawing.Size(73, 24);
            this.LblLicorne.TabIndex = 9;
            this.LblLicorne.Text = "Licorne";
            // 
            // ChoixAnimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.Controls.Add(this.LblLicorne);
            this.Controls.Add(this.LblLion);
            this.Controls.Add(this.LblMouton);
            this.Controls.Add(this.LblEscape);
            this.Controls.Add(this.LblPrixLicorne);
            this.Controls.Add(this.LblPrixLion);
            this.Controls.Add(this.LblPrixMouton);
            this.Controls.Add(this.BtnLicorne);
            this.Controls.Add(this.BtnLion);
            this.Controls.Add(this.BtnMouton);
            this.Name = "ChoixAnimal";
            this.Size = new System.Drawing.Size(590, 322);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnMouton;
        private System.Windows.Forms.Button BtnLion;
        private System.Windows.Forms.Button BtnLicorne;
        private System.Windows.Forms.Label LblPrixMouton;
        private System.Windows.Forms.Label LblPrixLion;
        private System.Windows.Forms.Label LblPrixLicorne;
        private System.Windows.Forms.Label LblEscape;
        private System.Windows.Forms.Label LblMouton;
        private System.Windows.Forms.Label LblLion;
        private System.Windows.Forms.Label LblLicorne;
    }
}
