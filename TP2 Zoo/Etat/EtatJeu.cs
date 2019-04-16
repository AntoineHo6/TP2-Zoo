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

namespace TP2_Zoo.Etat {
    public partial class EtatJeu : UserControl {
        public EtatJeu() {
            InitializeComponent();
        }

        private void EtatJeu_Paint(object sender, PaintEventArgs e) {
            // temp
            GerantCarte.PrintTileSolidMapping();

            GerantCarte.PeintureGazon(e);
            GerantCarte.PeintureCheminSable(e);
            GerantCarte.PeintureEnclos(e);

            // FIN ; Cadrier toujours à la fin pour qu'il soit visible.
            GerantCarte.PeintureCadriage(e);
        }
    }
}
