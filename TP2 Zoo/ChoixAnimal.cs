using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP2_Zoo.Etat;

namespace TP2_Zoo {
    public partial class ChoixAnimal : UserControl {

        EtatJeu etatJeu;

        public ChoixAnimal(EtatJeu etatJeu) {
            InitializeComponent();

            this.etatJeu = etatJeu;
        }

        public void Setup(int argentHero) {
            if (argentHero < 20) {
                LblPrixMouton.ForeColor = Color.Red;
                LblPrixLion.ForeColor = Color.Red;
                LblPrixLicorne.ForeColor = Color.Red;
                BtnMouton.BackgroundImage = Properties.Resources.Mouton_Mono;
                BtnLion.BackgroundImage = Properties.Resources.Lion_Mono;
                BtnLicorne.BackgroundImage = Properties.Resources.Licorne_Mono;
                BtnMouton.Enabled = false;
                BtnLion.Enabled = false;
                BtnLicorne.Enabled = false;

            }
            else if (argentHero < 35) {
                LblPrixLion.ForeColor = Color.Red;
                LblPrixLicorne.ForeColor = Color.Red;
                BtnLion.BackgroundImage = Properties.Resources.Lion_Mono;
                BtnLicorne.BackgroundImage = Properties.Resources.Licorne_Mono;
                BtnLion.Enabled = false;
                BtnLicorne.Enabled = false;
            }
            else if (argentHero < 50) {
                LblPrixLicorne.ForeColor = Color.Red;
                BtnLicorne.BackgroundImage = Properties.Resources.Licorne_Mono;
                BtnLicorne.Enabled = false;
            }
            else {
                BtnMouton.BackgroundImage = Properties.Resources.Mouton;
                BtnLion.BackgroundImage = Properties.Resources.Lion;
                BtnLicorne.BackgroundImage = Properties.Resources.Licorne;
            }
        }

        private void BtnMouton_Click(object sender, EventArgs e) {

        }

        private void BtnLion_Click(object sender, EventArgs e) {

        }

        private void BtnLicorne_Click(object sender, EventArgs e) {

        }
    }
}
