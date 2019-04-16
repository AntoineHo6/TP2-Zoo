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

namespace TP2_Zoo.Etat {
    public partial class EtatJeu : UserControl {

        Hero hero;

        public EtatJeu() {
            InitializeComponent();
            DoubleBuffered = true;

            hero = new Hero(1, 1);


            // Testing purposes
            GerantCarte.PrintSolidMapping();
        }

        private void EtatJeu_Paint(object sender, PaintEventArgs e) {
            // temp
            //GerantCarte.PaintTileFloorMapping(e);

            GerantCarte.PeintureGazon(e);
            GerantCarte.PeintureCheminSable(e);
            GerantCarte.PeintureEnclos(e);
            GerantCarte.PeintureMaison(e);

            // FIN ; Cadrier toujours à la fin pour qu'il soit visible.
            GerantCarte.PeintureCadriage(e);
        }

        // Pour bouger le perso
        private void EtatJeu_KeyPress(object sender, KeyPressEventArgs e) {

        }
    }
}
