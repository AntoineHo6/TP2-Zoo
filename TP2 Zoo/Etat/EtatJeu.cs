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
            PaintUtils.PeintureGazon(e);

            PaintUtils.PeintureEnclos(e);
        }
    }
}
