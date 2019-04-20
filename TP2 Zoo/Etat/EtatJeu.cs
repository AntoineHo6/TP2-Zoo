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
        int nbrAnimaux;
        int nbrVisiteurs;
        List<Pepe> listePepe;
        List<Licorne> listeLicorne;

        public EtatJeu() {
            InitializeComponent();
            DoubleBuffered = true;

            hero = new Hero();
            nbrAnimaux = 0;
            listePepe = new List<Pepe>();
            listeLicorne = new List<Licorne>();
            nbrVisiteurs = 0;

            // temp
            listePepe.Add(new Pepe("Bernard"));
            listeLicorne.Add(new Licorne(8, 7));

            // Testing purposes
            //GerantCarte.PrintSolidMappingHero();
            //GerantCarte.PrintSolidMappingAi();
            //GerantCarte.PrintSurfaceEnclosMapping();
            //GerantCarte.PrintOccupeAiMap();
        }


        private void EtatJeu_Paint(object sender, PaintEventArgs e) {
            GerantCarte.PeintureGazon(e);
            GerantCarte.PeintureCheminSable(e);
            GerantCarte.PeintureEnclos(e);
            GerantCarte.PeintureMaison(e);
            // FIN ; Cadrier toujours à la fin pour qu'il soit visible.
            GerantCarte.PeintureCadriage(e);

            hero.Peinturer(e, 0);

            // temp
            foreach (var pepe in listePepe) {
                pepe.Peinturer(e, 0);
            }
            foreach (var licorne in listeLicorne) {
                licorne.Peinturer(e, 0);
            }

        }

        // Pour bouger le perso
        private void EtatJeu_KeyDown(object sender, KeyEventArgs e) {
            hero.Deplacer(e);
            this.Refresh();
        }

        // temp utiliser thread au lieu pour pas que tout tick en meme temps.
        private void Timer_Tick(object sender, EventArgs e) {
            foreach (var pepe in listePepe) {
                pepe.Deplacer(hero.Position);
            }
            foreach (var licorne in listeLicorne) {
                licorne.Deplacer(hero.Position);
            }

            this.Refresh();
        }

        private void EtatJeu_MouseClick(object sender, MouseEventArgs e) {
            Point p = this.PointToClient(Cursor.Position);
            int pX = p.X / 32;
            int pY = p.Y / 32;

            bool heroAdjacent = HeroAdjacent(pX, pY);
            
            if (heroAdjacent) {
                if (GerantCarte.SurfaceEnclosMap[pX, pY] && !GerantCarte.OccupeAiMap[pX, pY]) { // Si clique dans un enclos sur une tuile vide
                    // VERIFIER SI ENCLOS A DEJA UN ANIMAL DEDANS OU PAS
                    // CREER UN ANIMAL
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
    }
}
