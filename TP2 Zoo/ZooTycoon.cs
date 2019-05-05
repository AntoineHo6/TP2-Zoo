using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tileSetZoo;
using TP2_Zoo.Etat;

namespace TP2_Zoo {
    public partial class Zoo : Form {
        
        enum Mois { Janvier=1, Fevrier, Mars, Avril, Mai, Juin, Juillet, Aout,
        Septembre, Octobre, Novembre, Decembre };
        
        DateTime dateNow;
        FrmEtatJeu etatJeu;

        public Zoo() {
            InitializeComponent();

            InitEtatJeu();

            dateNow = DateTime.Now;
            LblDate.Text = " " + dateNow.Day + "  " + (Mois)dateNow.Month + "  " + dateNow.Year;

            Noms.Noms.LoadNames();
        }


        private void InitEtatJeu() {
            etatJeu = new FrmEtatJeu(this);
            etatJeu.Location = new Point(0, 112);
            this.Controls.Add(etatJeu);
            //this.Size = new Size(1280, 832);
        }


        private void Timer1_Tick(object sender, EventArgs e) {
            dateNow = dateNow.AddDays(1);
            LblDate.Text = " " + dateNow.Day + "  " + (Mois)dateNow.Month + "  " + dateNow.Year;
        }

        private void Zoo_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                etatJeu.ChoixAnimal.Visible = false;
                etatJeu.InfosAnimaux.Visible = false;
                etatJeu.InfosVisiteurs.Visible = false;
                etatJeu.Focus();
            }
        }

        private void ToolStripMenuItemQuitter_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
