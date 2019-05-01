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
        Zoo formePrincipale;
        int nbrAnimaux;
        int nbrDechet;
        int secondesJeu;

        public Heros heros;

        public List<Animal> listeAnimaux;
        public ChoixAnimal choixAnimal;

        List<Visiteur> listeVisiteurs;


        public EtatJeu(Zoo formPrincipale) {
            InitializeComponent();
            DoubleBuffered = true;

            nbrAnimaux = 0;
            nbrDechet = 0;
            secondesJeu = 0;

            this.formePrincipale = formPrincipale;
            heros = new Heros();
            listeAnimaux = new List<Animal>();
            listeVisiteurs = new List<Visiteur>();
            InitChoixAnimal();
        }


        /// <summary>
        ///     Prépare le user control qui permet de choisir le type d'animal à créer dans un nouvel enclos.
        /// </summary>
        private void InitChoixAnimal() {
            choixAnimal = new ChoixAnimal(this);
            choixAnimal.Location = new Point(345, 239);
            this.Controls.Add(choixAnimal);
            choixAnimal.Visible = false;
        }


        /// <summary>
        ///     Peinture la map, le hero et finalement les AIs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EtatJeu_Paint(object sender, PaintEventArgs e) {
            GerantCarte.PeintureMap(e);
            heros.Peinturer(e, heros.Touche);
            PeinturerAI(e);
        }


        /// <summary>
        ///     Peintures les AIs (les animaux et visiteurs).
        /// </summary>
        /// <param name="e"></param>
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


        /// <summary>
        ///     Gère les cliques de souris du joueur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EtatJeu_MouseClick(object sender, MouseEventArgs e) {
            Point p = this.PointToClient(Cursor.Position);
            int pX = p.X / 32;
            int pY = p.Y / 32;

            int enclos = GerantCarte.SurfaceEnclosMap[pX, pY];  // 0: pas dans un enclos.

            if (e.Button == MouseButtons.Left) {
                if (HerosAdjacent(pX, pY)) {
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
                if (enclos != 0 && GerantCarte.OccupeAiMap[pX, pY]) {
                    Console.WriteLine("C'est un animal!");
                }
            }
        }


        /// <summary>
        ///     Créé un nouvel animal à une position précise.
        /// </summary>
        /// <param name="animal"> Le type d'animal à créé </param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void CreerAnimal(String animal, int x, int y) {
            bool animalCree = false;

            switch (animal) {
                case "Mouton":
                    if (heros.Argent >= 20) {
                        DeduireArgentHeros(20);
                        listeAnimaux.Add(new Mouton(true, x, y));
                        animalCree = true;
                    }
                    break;
                case "Lion":
                    if (heros.Argent >= 35) {
                        DeduireArgentHeros(35);
                        listeAnimaux.Add(new Lion(true, x, y));
                        animalCree = true;
                    }
                    break;
                case "Licorne":
                    if (heros.Argent >= 50) {
                        DeduireArgentHeros(50);
                        listeAnimaux.Add(new Licorne(true, x, y));
                        animalCree = true;
                    }
                    break;
            }

            if (animalCree) {
                CreerVisiteur();
                IncNbrAnimaux();
                Refresh();
            }
        }


        /// <summary>
        ///     Créé un nouveau visiteur de type aléatoire.
        /// </summary>
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

            AjouterArgentHeros(2);
        }


        /// <summary>
        ///     Déduit de l'argent du héros.
        /// </summary>
        /// <param name="montant"> Le montant d'argent à déduire. </param>
        private void DeduireArgentHeros(double montant) {
            heros.Argent -= montant;
            formePrincipale.LblArgent.Text = "Argent : " + heros.Argent + "$";
        }


        /// <summary>
        ///     Ajoute de l'argent au héros.
        /// </summary>
        /// <param name="montant"> Le montant d'argent à ajouter. </param>
        private void AjouterArgentHeros(double montant) {
            heros.Argent += montant;
            formePrincipale.LblArgent.Text = "Argent : " + heros.Argent + "$";
        }


        /// <summary>
        ///     Vérifie si le héros est adjacent à la tuile cliquée.
        /// </summary>
        /// <param name="iX"> Coordonnée X de la tuile cliquée </param>
        /// <param name="iY"> Coordonnée Y de la tuile cliquée </param>
        /// <returns></returns>
        private bool HerosAdjacent(int iX, int iY) {
            bool heroAdjacent = false;

            // parcours les tuiles autour du héros.
            for (int y = -1; y < 2; y++) {
                for (int x = -1; x < 2; x++) {
                    if ((heros.Position[0] == iX + x) && (heros.Position[1] == iY + y)) {
                        heroAdjacent = true;
                    }
                }
            }
            return heroAdjacent;
        }


        /// <summary>
        ///     Incrémente la variable du nombre d'animaux.
        /// </summary>
        private void IncNbrAnimaux() {
            nbrAnimaux++;
            formePrincipale.LblNbrAnimaux.Text = "Nombre d'animaux : " + nbrAnimaux;
        }


        /// <summary>
        ///     Nourri un animal. Coûte 1$ au héros.
        /// </summary>
        /// <param name="x"> La position X de l'animal </param>
        /// <param name="y"> La position Y de l'animal </param>
        private void NourrirAnimal(int x, int y) {
            foreach (var animal in listeAnimaux) {
                if (animal.Position[0] == x && animal.Position[1] == y) {
                    DeduireArgentHeros(1);
                    animal.Manger();
                }
            }
        }


        /// <summary>
        ///     Mets à jours tous les AIs et paie le joueur à chaque minute dépendamment du nombre d'animaux et de déchets.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e) {
            TickVisiteurs();
            TickAnimaux();

            secondesJeu++;

            if (secondesJeu % 60 == 0) {
                AjouterArgentHeros(nbrAnimaux * nbrAnimaux); // chaque visiteur repaie 1$ pour chaque animal présent, et pour chaque animal, il y a un visiteur.
                DeduireArgentHeros(nbrDechet * 0.10);
            }

            this.Refresh();
        }


        /// <summary>
        ///     Mets à jour chaque visiteur et ils se déplacent.
        /// </summary>
        private void TickVisiteurs() {
            foreach (var visiteur in listeVisiteurs) {
                visiteur.NbrJours++;
                ChanceProduireDechet(visiteur);
                visiteur.Deplacer(heros.Position);
                visiteur.VerifierPeutQuit();

                // temp
                // a tester
                if (VisiteurPeuxTuQuitter(visiteur)) {
                    listeVisiteurs.Remove(visiteur);
                }
            }
        }


        /// <summary>
        ///     Vérifie si un visiteur peut quitter.
        /// </summary>
        /// <param name="visiteur"> Le visiteur a verifier. </param>
        /// <returns></returns>
        private bool VisiteurPeuxTuQuitter(Visiteur visiteur) {
            return visiteur.droitQuitter && ((visiteur.Position[0] == 19 || visiteur.Position[0] == 20) && visiteur.Position[1] == 25);
        }


        /// <summary>
        ///     Mets à jours tous les animaux et ils se déplacent.
        /// </summary>
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


        /// <summary>
        ///     Le visiteur a 3% chance de laisser tomber un dechet.
        /// </summary>
        /// <param name="visiteur"> Le visiteur qui a la chance de faire tomber un dechet. </param>
        private void ChanceProduireDechet(Visiteur visiteur) {
            //                     |              pas de dechet sur un autre dechet.                    |
            if (r.Next(100) < 3 && !GerantCarte.PosDechetsMap[visiteur.Position[0], visiteur.Position[1]]) {
                visiteur.LaisserDechet();
                IncNbrDechet();
            }
        }


        /// <summary>
        ///     Incrémente le nombre de déchets.
        /// </summary>
        private void IncNbrDechet() {
            nbrDechet++;
            formePrincipale.LblNbrDechets.Text = "Nombre de dechets : " + nbrDechet;
        }


        /// <summary>
        ///     Décremente le nombre de déchets.
        /// </summary>
        private void DecNbrDechet() {
            nbrDechet--;
            formePrincipale.LblNbrDechets.Text = "Nombre de dechets : " + nbrDechet;
        }


        /// <summary>
        ///     Déduit 2$ du joueur.
        /// </summary>
        private void Contravention() {
            DeduireArgentHeros(2);
        }
    }
}
