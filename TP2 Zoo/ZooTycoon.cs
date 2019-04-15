using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tileSetZoo;

namespace TP2_Zoo {
    public partial class Zoo : Form {

        enum Jour { Janvier=1, Fevrier, Mars, Avril, Mai, Juin, Juillet, Aout,
        Septembre, Octobre, Novembre, Decembre };
        public Zoo() {
            InitializeComponent();

        }

        private void Zoo_Paint(object sender, PaintEventArgs e) {
            PaintUtils.PeintureGazon(e);

            // PAINT TESTING GROUND
            e.Graphics.DrawImage(TilesetImageGenerator.GetTile(2), 0, 0);
        }
    }
}
