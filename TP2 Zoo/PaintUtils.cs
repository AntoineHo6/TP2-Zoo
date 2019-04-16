using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using tileSetZoo;

namespace TP2_Zoo {
    public static class PaintUtils {

        static Bitmap[,] Gazon = new Bitmap[40, 25];

        static PaintUtils() {
            
        }

        // Taille de 40 x 25 ou (39 x 24 si on commmence par index 0)
        static int TuileAPixel(int Tuile) {
            return Tuile * 32;
        }

        public static void PeintureGazon(PaintEventArgs e) {
            for (int y = 0; y < 25; y++) {
                for (int x = 0; x < 40; x++) {
                    e.Graphics.DrawImage(TilesetImageGenerator.GetTile(1), TuileAPixel(x), TuileAPixel(y));
                }
            }
        }

        public static void PeintureEnclos(PaintEventArgs e) {
            e.Graphics.DrawImage(TilesetImageGenerator.GetTile(2), TuileAPixel(38), TuileAPixel(0));
        }

        public static void PeintureCadriage(PaintEventArgs e) {
            Pen blackPen = new Pen(Color.Black, 1);

            // peinture lignes verticales
            for (int i = 0; i < 40; i++) {
                e.Graphics.DrawLine(blackPen, TuileAPixel(i), 0, TuileAPixel(i), 800);
            }

            // peinture lines horizontales
            for (int i = 0; i < 25; i++) {
                e.Graphics.DrawLine(blackPen, 0, TuileAPixel(i), 1296, TuileAPixel(i));
            }

            
        }
    }
}
