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
using TP2_Zoo.Animal;
using System.Threading;

namespace TP2_Zoo {
    public partial class ChoixAnimal : UserControl {

        EtatJeu etatJeu;
        int spawnX;
        int spawnY;
        public int Enclos { get; set; }

        public ChoixAnimal(EtatJeu etatJeu) {
            InitializeComponent();

            this.etatJeu = etatJeu;
        }

        public void Setup(int argentHero, int Enclos, int x, int y) {
            this.Enclos = Enclos;
            spawnX = x;
            spawnY = y;

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
                LblPrixMouton.ForeColor = Color.Black;
                LblPrixLion.ForeColor = Color.Red;
                LblPrixLicorne.ForeColor = Color.Red;
                BtnMouton.BackgroundImage = Properties.Resources.Mouton;
                BtnLion.BackgroundImage = Properties.Resources.Lion_Mono;
                BtnLicorne.BackgroundImage = Properties.Resources.Licorne_Mono;
                BtnMouton.Enabled = true;
                BtnLion.Enabled = false;
                BtnLicorne.Enabled = false;
            }
            else if (argentHero < 50) {
                LblPrixMouton.ForeColor = Color.Black;
                LblPrixLion.ForeColor = Color.Black;
                LblPrixLicorne.ForeColor = Color.Red;
                BtnMouton.BackgroundImage = Properties.Resources.Mouton;
                BtnLion.BackgroundImage = Properties.Resources.Lion;
                BtnLicorne.BackgroundImage = Properties.Resources.Licorne_Mono;
                BtnMouton.Enabled = true;
                BtnLion.Enabled = true;
                BtnLicorne.Enabled = false;
            }
            else {
                LblPrixMouton.ForeColor = Color.Black;
                LblPrixLion.ForeColor = Color.Black;
                LblPrixLicorne.ForeColor = Color.Black;
                BtnMouton.BackgroundImage = Properties.Resources.Mouton;
                BtnLion.BackgroundImage = Properties.Resources.Lion;
                BtnLicorne.BackgroundImage = Properties.Resources.Licorne;
                BtnMouton.Enabled = true;
                BtnLion.Enabled = true;
                BtnLicorne.Enabled = true;
            }
        }


        private void BtnMouton_Click(object sender, EventArgs e) {
            etatJeu.CreerAnimal("Mouton", spawnX, spawnY);
            GerantCarte.animalEnclos[Enclos] = "Mouton";
            Cacher();
        }

        private void BtnLion_Click(object sender, EventArgs e) {
            etatJeu.CreerAnimal("Lion", spawnX, spawnY);
            GerantCarte.animalEnclos[Enclos] = "Lion";
            Cacher();
        }

        private void BtnLicorne_Click(object sender, EventArgs e) {
            etatJeu.CreerAnimal("Licorne", spawnX, spawnY);
            GerantCarte.animalEnclos[Enclos] = "Licorne";
            Cacher();
        }

        private void Cacher() {
            this.Visible = false;
            etatJeu.Focus();
        }
    }

    /// TODO: deduct money.
}
