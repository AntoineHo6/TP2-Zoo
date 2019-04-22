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

        Zoo formPrincipale;
        EtatJeu etatJeu;
        int spawnX;
        int spawnY;

        public ChoixAnimal(EtatJeu etatJeu, Zoo formPrincipale) {
            InitializeComponent();

            this.formPrincipale = formPrincipale;
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


        public void SetSpawn(int x, int y) {
            spawnX = x;
            spawnY = y;
        }


        private void BtnMouton_Click(object sender, EventArgs e) {
            Mouton mouton = new Mouton(true, spawnX, spawnY);
            DeduireArgentHero(mouton.Prix);
            etatJeu.listeMouton.Add(mouton);
            Cacher();
        }

        private void BtnLion_Click(object sender, EventArgs e) {
            Lion lion = new Lion(true, spawnX, spawnY);
            DeduireArgentHero(lion.Prix);
            etatJeu.listeLion.Add(lion);
            Cacher();
        }

        private void BtnLicorne_Click(object sender, EventArgs e) {
            Licorne licorne = new Licorne(true, spawnX, spawnY);
            DeduireArgentHero(licorne.Prix);
            etatJeu.listeLicorne.Add(licorne);
            Cacher();
        }

        private void Cacher() {
            this.Visible = false;
            etatJeu.Focus();
        }

        private void DeduireArgentHero(int montant) {
            etatJeu.hero.Argent -= montant;
            formPrincipale.LblArgent.Text = "Argent : " + etatJeu.hero.Argent + "$";
        }
    }

    /// TODO: deduct money.
}
