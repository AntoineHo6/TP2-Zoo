using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using tileSetZoo;

namespace TP2_Zoo {
    public static class GerantCarte {

        public static bool[,] SolidMapping = new bool[40, 26];
        public static Bitmap[,] TileFloorMapping = new Bitmap[40, 26];

        static GerantCarte() {
            // Par defaut, tout n'est pas solide.
            for (int y = 0; y < SolidMapping.GetLength(1); y++) {
                for (int x = 0; x < SolidMapping.GetLength(0); x++) {
                    SolidMapping[x, y] = false;
                }
            }

            // Changement des bools dans TileSolidMap a solide ou les enclos sont places.
            for (int y = 0; y < SolidMapping.GetLength(1); y++) {
                for (int x = 0; x < SolidMapping.GetLength(0); x++) {
                    if ((y == 6 || y == 11 || y == 14 || y == 19) && ((x >= 7 && x <= 18) || (x >= 21 && x <= 32))) {       // Verifie ou les enclos horizontals se retrouvent.
                        SolidMapping[x, y] = true;
                    }
                    else if ((x == 7 || x == 18 || x == 21 || x == 32) && ((y >= 7 && y <= 10) || (y >= 15 && y <= 18))) {  // Verifie ou les enclos verticals se retrouvent.
                        SolidMapping[x, y] = true;
                    }
                }
            }

            for (int y = 0; y < 5; y++) {
                for (int x = 0; x < 4; x++) {
                    SolidMapping[x, y] = true;
                }
            }
        }

        // testing purposes
        public static void PrintTileSolidMapping() {
            for (int y = 0; y < SolidMapping.GetLength(1); y++) {
                for (int x = 0; x < SolidMapping.GetLength(0); x++) {
                    if (SolidMapping[x, y]) {
                        Console.Write("1 ");
                    }
                    else {
                        Console.Write("- ");
                    }
                }
                Console.Write("\n");
            }
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
                    e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(1), TuileAPixel(x), TuileAPixel(y));
                }
            }
        }


        public static void PeintureCheminSable(PaintEventArgs e) {
            // Peinture le chemin vertical au milieu.
            for (int x = 0; x < 40; x++) {
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(4), TuileAPixel(x), TuileAPixel(12));
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(4), TuileAPixel(x), TuileAPixel(13));
            }
            // Peinture le chemin horizontal au milieu.
            for (int y = 0; y < 26; y++) {
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(4), TuileAPixel(19), TuileAPixel(y));
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(4), TuileAPixel(20), TuileAPixel(y));
            }

            for (int y = 0; y < 7; y++) {
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(4), TuileAPixel(1), TuileAPixel(y + 5));
            }
        }


        public static void PeintureEnclos(PaintEventArgs e) {
            // Peinture enclos horizontales.
            for (int x = 0; x < 11; x++) {
                // pour l'enclos en haut à gauche.
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(2), TuileAPixel(7+x) + 8, TuileAPixel(6));
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(2), TuileAPixel(7+x) + 8, TuileAPixel(11));

                // pour l'enclos en haut à droite.
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(2), TuileAPixel(21+x) + 8, TuileAPixel(6));
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(2), TuileAPixel(21+x) + 8, TuileAPixel(11));

                // Peinture l'enclos en bas à gauche.
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(2), TuileAPixel(7 + x) + 8, TuileAPixel(14));
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(2), TuileAPixel(7 + x) + 8, TuileAPixel(19));

                // Peinture l'enclos en bas à droite.
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(2), TuileAPixel(21 + x) + 8, TuileAPixel(14));
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(2), TuileAPixel(21 + x) + 8, TuileAPixel(19));
            }

            // Peinture enclos verticales.
            for (int y = 0; y < 5; y++) {
                // pour l'enclos en haut à gauche.
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(3), TuileAPixel(7), TuileAPixel(6+y));
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(3), TuileAPixel(18), TuileAPixel(6+y));

                // pour l'enclos en haut à droite.
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(3), TuileAPixel(21), TuileAPixel(6+y));
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(3), TuileAPixel(32), TuileAPixel(6+y));

                // Peinture l'enclos en bas à gauche.
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(3), TuileAPixel(7), TuileAPixel(14 + y));
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(3), TuileAPixel(18), TuileAPixel(14 + y));

                // Peinture l'enclos en bas à droite.
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(3), TuileAPixel(21), TuileAPixel(14 + y));
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(3), TuileAPixel(32), TuileAPixel(14 + y));
            }
        }


        public static void PeintureMaison(PaintEventArgs e) {
            e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(5), TuileAPixel(0), 0);
        }
    }
}
