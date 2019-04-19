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

        public static Bitmap[,] TileFloorMapping = new Bitmap[40, 26];  // Probablement inutile.
        public static bool[,] SolidMapping = new bool[42, 28];  // Plus large pour créer une bordure solide autour de la carte.


        static GerantCarte() {
            InitSolidMapping();
            InitTileFloorMapping();
        }


        static void InitSolidMapping() {
            // Par defaut, tout n'est pas solide à part la bordure.
            for (int y = 0; y < SolidMapping.GetLength(1); y++) {
                for (int x = 0; x < SolidMapping.GetLength(0); x++) {
                    if ((x == 0 || x == 41) || (y == 0 || y == 27)) {
                        SolidMapping[x, y] = true;
                    }
                    else {
                        SolidMapping[x, y] = false;
                    }
                }
            }

            // Changement des bools dans TileSolidMap a solide ou les enclos sont places.
            for (int y = 0; y < SolidMapping.GetLength(1); y++) {
                for (int x = 0; x < SolidMapping.GetLength(0); x++) {
                    if ((y == 7 || y == 12 || y == 15 || y == 20) && ((x >= 8 && x <= 19) || (x >= 22 && x <= 33))) {       // Verifie ou les enclos horizontals se retrouvent.
                        SolidMapping[x, y] = true;
                    }
                    else if ((x == 8 || x == 19 || x == 22 || x == 33) && ((y >= 8 && y <= 11) || (y >= 16 && y <= 19))) {  // Verifie ou les enclos verticals se retrouvent.
                        SolidMapping[x, y] = true;
                    }
                }
            }

            // La maison est solide
            for (int y = 1; y < 6; y++) {
                for (int x = 1; x < 5; x++) {
                    SolidMapping[x, y] = true;
                }
            }
        }


        static void InitTileFloorMapping() {
            // Ajout du GAZON et SABLE
            for (int y = 0; y < TileFloorMapping.GetLength(1); y++) {
                for (int x = 0; x < TileFloorMapping.GetLength(0); x++) {
                    TileFloorMapping[x, y] = MapTileSetImageGenerator.GetTile(1);

                    if ((x == 19 || x == 20) || (y == 12 || y == 13)) {
                        TileFloorMapping[x, y] = MapTileSetImageGenerator.GetTile(4);
                    }
                    else if (x == 1 && (y >= 5 && y <= 11)) {
                        TileFloorMapping[x, y] = MapTileSetImageGenerator.GetTile(4);
                    }
                }
            }
        }


        // testing purposes
        public static void PrintSolidMapping() {
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


        // testing purposes
        public static void PaintTileFloorMapping(PaintEventArgs e) {
            for (int y = 0; y < TileFloorMapping.GetLength(1); y++) {
                for (int x = 0; x < TileFloorMapping.GetLength(0); x++) {
                    e.Graphics.DrawImage(TileFloorMapping[x, y], TuileAPixel(x), TuileAPixel(y));
                }
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
            // Peinture le chemin sable vertical au milieu.
            for (int x = 0; x < 40; x++) {
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(4), TuileAPixel(x), TuileAPixel(12));
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(4), TuileAPixel(x), TuileAPixel(13));
            }
            // Peinture le chemin sable horizontal au milieu.
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
