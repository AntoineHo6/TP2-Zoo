using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using tileSetZoo;

namespace TP2_Zoo {
    class GerantPersonnages {


        public static void DessinerHeros(PaintEventArgs e) {
            int x = 1;
            int y = 5;
            e.Graphics.DrawImage(PersonneTileSetImageGenerator.GetTile(1), TuileAPixel(x), TuileAPixel(y));
        }

        static int TuileAPixel(int Tuile) {
            return Tuile * 32;
        }

    }
}
