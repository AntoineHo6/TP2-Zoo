using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tileSetZoo;
using TP2_Zoo.Personne;
using System.Threading;
using TP2_Zoo.Animal;

namespace TP2_Zoo.Etat {
    public partial class EtatJeu : UserControl {

        Zoo formPrincipale;
        int nbrAnimaux;

        public Hero hero;

        public List<Mouton> listeMouton;
        public List<Lion> listeLion;
        public List<Licorne> listeLicorne;
        public ChoixAnimal choixAnimal;

        List<Pepe> listePepe;

        public EtatJeu(Zoo formPrincipale) {
            InitializeComponent();
            DoubleBuffered = true;

            nbrAnimaux = 0;
            this.formPrincipale = formPrincipale;
            hero = new Hero();
            InitListeAI();
            InitChoixAnimal();
        }


        private void InitChoixAnimal() {
            choixAnimal = new ChoixAnimal(this);
            choixAnimal.Location = new Point(345, 239);
            this.Controls.Add(choixAnimal);
            choixAnimal.Visible = false;
        }


        private void InitListeAI() {
            listePepe = new List<Pepe>();
            listeMouton = new List<Mouton>();
            listeLion = new List<Lion>();
            listeLicorne = new List<Licorne>();
        }


        private void EtatJeu_Paint(object sender, PaintEventArgs e) {
            GerantCarte.PeintureMap(e);

            hero.Peinturer(e, 0);

            // Paint les animaux
            foreach (var mouton in listeMouton) {
                mouton.Peinturer(e, 0);
            }
            foreach (var lion in listeLion) {
                lion.Peinturer(e, 0);
            }
            foreach (var licorne in listeLicorne) {
                licorne.Peinturer(e, 0);
            }

            // Paint les visiteurs
            foreach (var pepe in listePepe) {
                pepe.Peinturer(e, 0);
            }
        }


        // Pour bouger le perso
        private void EtatJeu_KeyDown(object sender, KeyEventArgs e) {
            hero.Deplacer(e);
            this.Refresh();
        }


        private void EtatJeu_MouseClick(object sender, MouseEventArgs e) {
            Point p = this.PointToClient(Cursor.Position);
            int pX = p.X / 32;
            int pY = p.Y / 32;

            if (e.Button == MouseButtons.Left) {
                bool heroAdjacent = HeroAdjacent(pX, pY);

                if (heroAdjacent) {
                    int enclos = GerantCarte.SurfaceEnclosMap[pX, pY];  // 0: pas dans un enclos.
                    String enclosTypeAnimal = GerantCarte.animalEnclos[enclos];

                    // Si clique dans un enclos sur une tuile vide
                    if (enclos != 0 && !GerantCarte.OccupeAiMap[pX, pY] && (pX != hero.Position[0] || pY != hero.Position[1])) {
                        // Si aucun animal dans l'enclos
                        if (enclosTypeAnimal == null) {
                            choixAnimal.Setup(hero.Argent, enclos, pX, pY);
                            choixAnimal.Visible = true;
                        }
                        else {
                            CreerAnimal(enclosTypeAnimal, pX, pY);
                        }
                    }
                    // Si clique sur un animal
                    else if (enclos != 0 && GerantCarte.OccupeAiMap[pX, pY]) {
                        if (hero.Argent >= 1) {
                            NourrirAnimal(enclosTypeAnimal, pX, pY);
                        }
                    }
                }
            }
        }

        public void CreerAnimal(String animal, int x, int y) {
            switch (animal) {
                case "Mouton":
                    if (hero.Argent >= 20) {
                        CreerMouton(x, y);
                    }                    
                    break;
                case "Lion":
                    if (hero.Argent >= 35) {
                        CreerLion(x, y);
                    }
                    break;
                case "Licorne":
                    if (hero.Argent >= 50) {
                        CreerLicorne(x, y);
                    }
                    break;
            }

            UpdateLblNbrAnimaux();
        }

        public void CreerMouton(int x, int y) {
            DeduireArgentHero(20);
            listeMouton.Add(new Mouton(true, x, y));
            nbrAnimaux++;
            Refresh();
        }

        public void CreerLion(int x, int y) {
            DeduireArgentHero(35);
            listeLion.Add(new Lion(true, x, y));
            nbrAnimaux++;
            Refresh();
        }

        public void CreerLicorne(int x, int y) {
            DeduireArgentHero(50);
            listeLicorne.Add(new Licorne(true, x, y));
            nbrAnimaux++;
            Refresh();
        }

        public void DeduireArgentHero(int montant) {
            hero.Argent -= montant;
            formPrincipale.LblArgent.Text = "Argent : " + hero.Argent + "$";
        }

        /// <summary>
        ///     Verifie si le hero est adjacent à la tuile cliquée.
        /// </summary>
        /// <param name="iX"> Coordonnée X de la tuile cliquée </param>
        /// <param name="iY"> Coordonnée Y de la tuile cliquée </param>
        /// <returns></returns>
        private bool HeroAdjacent(int iX, int iY) {
            bool heroAdjacent = false;

            for (int y = -1; y < 2; y++) {
                for (int x = -1; x < 2; x++) {
                    if ((hero.Position[0] == iX + x) && (hero.Position[1] == iY + y)) {
                        heroAdjacent = true;
                    }
                }
            }
            return heroAdjacent;
        }


        void UpdateLblNbrAnimaux() {
            formPrincipale.LblNbrAnimaux.Text = "Nombre d'animaux : " + nbrAnimaux;
        }


        private void NourrirAnimal(String typeAnimal, int x, int y) {
            switch (typeAnimal) {
                case "Mouton":
                    foreach (var mouton in listeMouton) {
                        if (mouton.Position[0] == x && mouton.Position[1] == y) {
                            NourrirMouton(mouton);
                        }
                    }
                    break;
                case "Lion":
                    foreach (var lion in listeLion) {
                        if (lion.Position[0] == x && lion.Position[1] == y) {
                            NourrirLion(lion);
                        }
                    }
                    break;
                case "Licorne":
                    foreach (var licorne in listeLicorne) {
                        if (licorne.Position[0] == x && licorne.Position[1] == y) {
                            NourrirLicorne(licorne);
                        }
                    }
                    break;
            }
        }


        private void NourrirMouton(Mouton mouton) {
            if (mouton.Faim) {
                DeduireArgentHero(2);
            }
            else {
                DeduireArgentHero(1);
            }

            mouton.Manger();
        }


        private void NourrirLion(Lion lion) {
            if (lion.Faim) {
                DeduireArgentHero(2);
            }
            else {
                DeduireArgentHero(1);
            }

            lion.Manger();
        }


        private void NourrirLicorne(Licorne licorne) {
            if (licorne.Faim) {
                DeduireArgentHero(2);
            }
            else {
                DeduireArgentHero(1);
            }

            licorne.Manger();
        }


        private void Timer_Tick(object sender, EventArgs e) {
            foreach (var pepe in listePepe) {
                pepe.NbrJours++;
                pepe.Deplacer(hero.Position);
            }

            foreach (var mouton in listeMouton) {
                mouton.NbrJours++;
                mouton.JoursPasNourri++;

                if (mouton.JoursPasNourri > 30) {
                    mouton.Faim = true;
                }

                mouton.Deplacer(hero.Position);
            }

            foreach (var lion in listeLion) {
                lion.NbrJours++;
                lion.JoursPasNourri++;

                if (lion.JoursPasNourri > 30){
                    lion.Faim = true;
                }

                lion.Deplacer(hero.Position);
            }

            foreach (var licorne in listeLicorne) {
                licorne.NbrJours++;
                licorne.JoursPasNourri++;

                if (licorne.JoursPasNourri > 30){
                    licorne.Faim = true;
                }

                licorne.Deplacer(hero.Position);
            }

            this.Refresh();
        }
    }
}
