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
        public event EventHandler<KeyPressEventArgs> OnKeyPressed;

        public EtatJeu() {
            InitializeComponent();
            DoubleBuffered = true;

            hero = new Hero(1, 5);

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

            hero.Peinturer(e);

            // FIN ; Cadrier toujours à la fin pour qu'il soit visible.
            GerantCarte.PeintureCadriage(e);

            // temp
            e.Graphics.DrawImage(VisiteurTileSetImageGenerator.GetTile(7), 1 * 32, 6 * 32);
        }

        // Pour bouger le perso
        private void EtatJeu_KeyPress(object sender, KeyPressEventArgs e) {
            OnKeyPressed?.Invoke(sender, e);
        }
    }
}
