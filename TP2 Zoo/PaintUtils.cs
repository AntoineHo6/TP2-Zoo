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


        // Taille de 40 x 26 ou (39 x 25 si on commmence par index 0)
        static int TuileAPixel(int Tuile) {
            return Tuile * 32;
        }


        public static void PeintureCadriage(PaintEventArgs e) {
            Pen blackPen = new Pen(Color.Black, 1);

            // peinture lignes verticales
            for (int i = 0; i < 40; i++) {
                e.Graphics.DrawLine(blackPen, TuileAPixel(i), 0, TuileAPixel(i), 832);
            }

            // peinture lines horizontales
            for (int i = 0; i < 26; i++) {
                e.Graphics.DrawLine(blackPen, 0, TuileAPixel(i), 1296, TuileAPixel(i));
            }
        }


        public static void PeintureGazon(PaintEventArgs e) {
            for (int y = 0; y < 26; y++) {
                for (int x = 0; x < 40; x++) {
                    e.Graphics.DrawImage(TilesetImageGenerator.GetTile(1), TuileAPixel(x), TuileAPixel(y));
                }
            }
        }


        public static void PeintureCheminSable(PaintEventArgs e) {
            for (int x = 0; x < 40; x++) {
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(4), TuileAPixel(x), TuileAPixel(12));
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(4), TuileAPixel(x), TuileAPixel(13));
            }

            for (int y = 0; y < 26; y++) {
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(4), TuileAPixel(19), TuileAPixel(y));
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(4), TuileAPixel(20), TuileAPixel(y));
            }
        }


        public static void PeintureEnclos(PaintEventArgs e) {
            // Quand on peinture un enclos horizontal, il faut ajouter 8 pixel car ils sont autistes.


            // Peinture enclos horizontales.
            for (int x = 0; x < 11; x++) {
                // pour l'enclos en haut à gauche.
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(2), TuileAPixel(7+x) + 8, TuileAPixel(6));
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(2), TuileAPixel(7+x) + 8, TuileAPixel(11));

                // pour l'enclos en haut à droite.
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(2), TuileAPixel(21+x) + 8, TuileAPixel(6));
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(2), TuileAPixel(21+x) + 8, TuileAPixel(11));

                // Peinture l'enclos en bas à gauche.
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(2), TuileAPixel(7 + x) + 8, TuileAPixel(14));
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(2), TuileAPixel(7 + x) + 8, TuileAPixel(19));

                // Peinture l'enclos en bas à droite.
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(2), TuileAPixel(21 + x) + 8, TuileAPixel(14));
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(2), TuileAPixel(21 + x) + 8, TuileAPixel(19));
            }

            // Peinture enclos verticales.
            for (int y = 0; y < 5; y++) {
                // pour l'enclos en haut à gauche.
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(3), TuileAPixel(7), TuileAPixel(6+y));
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(3), TuileAPixel(18), TuileAPixel(6+y));

                // pour l'enclos en haut à droite.
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(3), TuileAPixel(21), TuileAPixel(6+y));
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(3), TuileAPixel(32), TuileAPixel(6+y));

                // Peinture l'enclos en bas à gauche.
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(3), TuileAPixel(7), TuileAPixel(14 + y));
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(3), TuileAPixel(18), TuileAPixel(14 + y));

                // Peinture l'enclos en bas à droite.
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(3), TuileAPixel(21), TuileAPixel(14 + y));
                e.Graphics.DrawImage(TilesetImageGenerator.GetTile(3), TuileAPixel(32), TuileAPixel(14 + y));
            }
        }
    }
}
