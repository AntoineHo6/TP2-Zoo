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

        public Hero hero;
        List<Pepe> listePepe;
        public List<Mouton> listeMouton;
        public List<Lion> listeLion;
        public List<Licorne> listeLicorne;
        public ChoixAnimal choixAnimal;

        public EtatJeu() {
            InitializeComponent();
            DoubleBuffered = true;

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
            GerantCarte.PeintureGazon(e);
            GerantCarte.PeintureCheminSable(e);
            GerantCarte.PeintureEnclos(e);
            GerantCarte.PeintureMaison(e);
            GerantCarte.PeintureCadriage(e);

            hero.Peinturer(e, 0);

            // temp ou pas;
            foreach (var pepe in listePepe) {
                pepe.Peinturer(e, 0);
            }
            foreach (var mouton in listeMouton) {
                mouton.Peinturer(e, 0);
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
                int enclos = GerantCarte.SurfaceEnclosMap[pX, pY];  // 0: pas dans un enclos.

                if (heroAdjacent) {
                    if (enclos != 0 && !GerantCarte.OccupeAiMap[pX, pY] && (pX != hero.Position[0] || pY != hero.Position[1])) { // Si clique dans un enclos sur une tuile vide
                        if (GerantCarte.animalEnclos[enclos - 1] == null) {
                            choixAnimal.Setup(hero.Argent);
                            choixAnimal.SetSpawn(pX, pY);
                            choixAnimal.Visible = true;
                        }
                        else {
                            // CREER UN ANIMAL 
                        }
                    }
                }
            }
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

        private void Timer_Tick(object sender, EventArgs e) {
            foreach (var pepe in listePepe) {
                pepe.Deplacer(hero.Position);
            }
            foreach (var mouton in listeMouton) {
                mouton.Deplacer(hero.Position);
            }

            this.Refresh();
            GerantCarte.PrintOccupeAiMap();
        }
    }
}
