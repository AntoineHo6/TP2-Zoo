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

namespace TP2_Zoo.Etat {
    public partial class EtatJeu : UserControl {

        Hero hero;
        int nbrAnimaux;
        int nbrVisiteurs;
        List<Pepe> listePepe;
        Thread animeHero;

        public EtatJeu() {
            InitializeComponent();
            DoubleBuffered = true;

            hero = new Hero();
            nbrAnimaux = 0;
            listePepe = new List<Pepe>();
            
            nbrVisiteurs = 0;

            // temp
            listePepe.Add(new Pepe("Bernard"));

            // Testing purposes
            GerantCarte.PrintSolidMapping();
        }


        private void EtatJeu_Paint(object sender, PaintEventArgs e) {
            GerantCarte.PeintureGazon(e);
            GerantCarte.PeintureCheminSable(e);
            GerantCarte.PeintureEnclos(e);
            GerantCarte.PeintureMaison(e);
            // FIN ; Cadrier toujours à la fin pour qu'il soit visible.
            GerantCarte.PeintureCadriage(e);

            hero.Peinturer(e, 0);

            foreach (var pepe in listePepe) {
                pepe.Peinturer(e, 0);
            }

            
        }

        // Pour bouger le perso
        private void EtatJeu_KeyPress(object sender, KeyPressEventArgs e) {
            
        }

        private void Timer_Tick(object sender, EventArgs e) {
            foreach (var pepe in listePepe) {
                pepe.Deplacer();
            }

            this.Refresh();
        }

        private void EtatJeu_MouseClick(object sender, MouseEventArgs e) {
            Point p = this.PointToClient(Cursor.Position);
            int indexX = p.X / 32;
            int indexY = p.Y / 32;

            bool heroAdjacent = HeroAdjacent(indexX, indexY);
            // temp
            Console.WriteLine("Hero adjacent?: " + heroAdjacent);
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
