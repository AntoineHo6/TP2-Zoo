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
using TP2_Zoo.Animaux;
using System.Threading;

namespace TP2_Zoo {
    public partial class ChoixAnimal : UserControl {

        FrmEtatJeu EtatJeu;
        int SpawnX;
        int SpawnY;
        public int Enclos { get; set; }

        public ChoixAnimal(FrmEtatJeu etatJeu) {
            InitializeComponent();
            this.EtatJeu = etatJeu;
        }

        /// <summary>
        ///     Méthode qui gère l'affichage pour le choix des animaux.
        /// </summary>
        /// <param name="argentHero">L'argent de l'héros</param>
        /// <param name="enclos">L'indice de l'enclos</param>
        /// <param name="x">La position X de l'héros</param>
        /// <param name="y">La position Y de l'héros</param>
        public void Setup(double argentHero, int enclos, int x, int y) {
            this.Enclos = enclos;
            SpawnX = x;
            SpawnY = y;

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

        /// <summary>
        ///     Méthode qui créé un mouton dans un enclos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMouton_Click(object sender, EventArgs e) {
            EtatJeu.CreerAnimal("Mouton", Enclos, SpawnX, SpawnY);
            GerantCarte.AnimalEnclos[Enclos] = "Mouton";
            Cacher();
        }

        /// <summary>
        ///     Méthode qui créé un lion dans un enclos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLion_Click(object sender, EventArgs e) {
            EtatJeu.CreerAnimal("Lion", Enclos, SpawnX, SpawnY);
            GerantCarte.AnimalEnclos[Enclos] = "Lion";
            Cacher();
        }

        /// <summary>
        ///     Méthode qui créé une licorne dans un enclos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLicorne_Click(object sender, EventArgs e) {
            EtatJeu.CreerAnimal("Licorne", Enclos, SpawnX, SpawnY);
            GerantCarte.AnimalEnclos[Enclos] = "Licorne";
            Cacher();
        }

        private void Cacher() {
            this.Visible = false;
            EtatJeu.Focus();
        }
    }
}
