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
using TP2_Zoo.Animaux;

namespace TP2_Zoo.Etat {
    public partial class EtatJeu : UserControl {
        static Random r = new Random();
        Zoo formPrincipale;
        int nbrAnimaux;
        int nbrDechet;
        int secondesJeu;

        public Heros heros;
        public List<Animal> listeAnimaux;

        public ChoixAnimal choixAnimal;

        List<Visiteur> listeVisiteurs = new List<Visiteur>();


        public EtatJeu(Zoo formPrincipale) {
            InitializeComponent();
            DoubleBuffered = true;

            nbrAnimaux = 0;
            nbrDechet = 0;
            secondesJeu = 0;

            this.formPrincipale = formPrincipale;
            heros = new Heros();
            listeAnimaux = new List<Animal>();
            listeVisiteurs = new List<Visiteur>();
            InitChoixAnimal();
        }


        private void InitChoixAnimal() {
            choixAnimal = new ChoixAnimal(this);
            choixAnimal.Location = new Point(345, 239);
            this.Controls.Add(choixAnimal);
            choixAnimal.Visible = false;
        }


        private void EtatJeu_Paint(object sender, PaintEventArgs e) {
            GerantCarte.PeintureMap(e);
            heros.Peinturer(e, heros.Touche);
            PeinturerAI(e);
        }


        private void PeinturerAI(PaintEventArgs e) {
            foreach (var animal in listeAnimaux) {
                animal.Peinturer(e, 0);
            }
            foreach (var visiteur in listeVisiteurs) {
                visiteur.Peinturer(e, 0);
            }
        }


        /// <summary>
        ///     Permet de déplacer le heros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EtatJeu_KeyDown(object sender, KeyEventArgs e) {
            heros.Deplacer(e);
            this.Refresh();
        }


        private void EtatJeu_MouseClick(object sender, MouseEventArgs e) {
            Point p = this.PointToClient(Cursor.Position);
            int pX = p.X / 32;
            int pY = p.Y / 32;

            if (e.Button == MouseButtons.Left) {
                if (HerosAdjacent(pX, pY)) {
                    int enclos = GerantCarte.SurfaceEnclosMap[pX, pY];  // 0: pas dans un enclos.
                    String enclosTypeAnimal = GerantCarte.AnimalEnclos[enclos];

                    // Si clique dans un enclos sur une tuile vide
                    if (enclos != 0 && !GerantCarte.OccupeAiMap[pX, pY] && (pX != heros.Position[0] || pY != heros.Position[1])) {
                        // Si aucun animal dans l'enclos
                        if (enclosTypeAnimal == null) {
                            choixAnimal.Setup(heros.Argent, enclos, pX, pY);
                            choixAnimal.Visible = true;
                        }
                        else {
                            CreerAnimal(enclosTypeAnimal, pX, pY);
                        }
                    }
                    // Si clique sur un animal
                    else if (enclos != 0 && GerantCarte.OccupeAiMap[pX, pY]) {
                        if (heros.Argent >= 1) {
                            NourrirAnimal(pX, pY);
                        }
                    }
                    // si clique sur un dechet
                    else if (GerantCarte.PosDechetsMap[pX, pY]) {
                        GerantCarte.PosDechetsMap[pX, pY] = false;
                        DecNbrDechet();
                        Refresh();
                    }
                }
            }
            else if (e.Button == MouseButtons.Right) {
                int enclos = GerantCarte.SurfaceEnclosMap[pX, pY];  // 0: pas dans un enclos.
                if (enclos != 0 && GerantCarte.OccupeAiMap[pX, pY]) {
                    Console.WriteLine("C'est un animal!");
                }
            }
        }

        public void CreerAnimal(String animal, int x, int y) {
            bool animalCree = false;

            switch (animal) {
                case "Mouton":
                    if (heros.Argent >= 20) {
                        DeduireArgentHero(20);
                        listeAnimaux.Add(new Mouton(true, x, y));
                        animalCree = true;
                    }
                    break;
                case "Lion":
                    if (heros.Argent >= 35) {
                        DeduireArgentHero(35);
                        listeAnimaux.Add(new Lion(true, x, y));
                        animalCree = true;
                    }
                    break;
                case "Licorne":
                    if (heros.Argent >= 50) {
                        DeduireArgentHero(50);
                        listeAnimaux.Add(new Licorne(true, x, y));
                        animalCree = true;
                    }
                    break;
            }

            if (animalCree) {
                CreerVisiteur();
                nbrAnimaux++;
                UpdateLblNbrAnimaux();
                Refresh();
            }
        }


        void CreerVisiteur() {
            int typeVisiteur = r.Next(0, 4);

            switch (typeVisiteur) {
                case 0:
                    listeVisiteurs.Add(new Pepe());
                    break;
                case 1:
                    listeVisiteurs.Add(new Dame());
                    break;
                case 2:
                    listeVisiteurs.Add(new Fillette());
                    break;
                case 3:
                    listeVisiteurs.Add(new Monsieur());
                    break;
            }

            AjouterArgentHero(2);
        }


        private void DeduireArgentHero(double montant) {
            heros.Argent -= montant;
            formPrincipale.LblArgent.Text = "Argent : " + heros.Argent + "$";
        }

        private void AjouterArgentHero(double montant) {
            heros.Argent += montant;
            formPrincipale.LblArgent.Text = "Argent : " + heros.Argent + "$";
        }

        /// <summary>
        ///     Verifie si le heros est adjacent à la tuile cliquée.
        /// </summary>
        /// <param name="iX"> Coordonnée X de la tuile cliquée </param>
        /// <param name="iY"> Coordonnée Y de la tuile cliquée </param>
        /// <returns></returns>
        private bool HerosAdjacent(int iX, int iY) {
            bool heroAdjacent = false;

            for (int y = -1; y < 2; y++) {
                for (int x = -1; x < 2; x++) {
                    if ((heros.Position[0] == iX + x) && (heros.Position[1] == iY + y)) {
                        heroAdjacent = true;
                    }
                }
            }
            return heroAdjacent;
        }


        private void UpdateLblNbrAnimaux() {
            formPrincipale.LblNbrAnimaux.Text = "Nombre d'animaux : " + nbrAnimaux;
        }


        private void NourrirAnimal(int x, int y) {
            foreach (var animal in listeAnimaux) {
                if (animal.Position[0] == x && animal.Position[1] == y) {
                    DeduireArgentHero(1);
                    animal.Manger();
                }
            }
        }


        private void Timer_Tick(object sender, EventArgs e) {
            TickVisiteurs();

            TickAnimaux();

            secondesJeu++;

            if (secondesJeu % 60 == 0) {
                AjouterArgentHero(nbrAnimaux * nbrAnimaux); // chaque visiteur repaie 1$ pour chaque animal présent, et pour chaque animal, il y a un visiteur.
                DeduireArgentHero(nbrDechet * 0.10);
            }

            this.Refresh();
        }


        private void TickVisiteurs() {
            foreach (var visiteur in listeVisiteurs) {
                visiteur.NbrJours++;
                ChanceProduireDechet(visiteur);
                visiteur.Deplacer(heros.Position);
                visiteur.VerifierPeutQuit();
            }
        }


        private void TickAnimaux() {
            foreach (var animal in listeAnimaux) {
                animal.NbrJours++;
                animal.JoursPasNourri++;

                if (animal.JoursPasNourri > 120) {
                    animal.JoursPasNourri = 0;
                    Contravention();
                }

                animal.Deplacer(heros.Position);
            }
        }


        private void ChanceProduireDechet(Visiteur visiteur) {
            // 5% chance de laisser tomber un dechet et pas de dechet dans la position courante du visiteur
            if (r.Next(100) < 5 && !GerantCarte.PosDechetsMap[visiteur.Position[0], visiteur.Position[1]]) {
                visiteur.LaisserDechet();
                IncNbrDechet();
            }
        }


        private void IncNbrDechet() {
            nbrDechet++;
            formPrincipale.LblNbrDechets.Text = "Nombre de dechets : " + nbrDechet;
        }


        private void DecNbrDechet() {
            nbrDechet--;
            formPrincipale.LblNbrDechets.Text = "Nombre de dechets : " + nbrDechet;
        }


        private void Contravention() {
            DeduireArgentHero(2);
        }
    }
}
