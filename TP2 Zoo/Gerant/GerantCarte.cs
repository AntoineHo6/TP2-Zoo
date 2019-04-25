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

        public static bool[,] SolidMapHeros = new bool[42, 28];  // Plus large pour créer une bordure solide autour de la carte.
        public static bool[,] SolidMapAi = new bool[42, 28];    // Pour les visiteurs et les animaux
        public static bool[,] OccupeAiMap = new bool[40, 26];
        public static int[,] SurfaceEnclosMap = new int[40, 26];    // Verifie quelles tuiles sont dans l'enclos. 1: NW, 2: NE, 3: SW, 4: SE
        public static String[] animalEnclos = new String[5];        // Stock le type d'animal que chaque enclos contient. commence a index 1.

        static GerantCarte() {
            InitSolidMaps();
            InitSurfaceEnclosMap();
            InitOccupeAiMap();

            // les prints pour tester
            //PrintSurfaceEnclosMap();
        }
        

        static void InitSolidMaps() {
            // Par defaut, tout n'est pas solide à part la bordure.
            for (int y = 0; y < SolidMapHeros.GetLength(1); y++) {
                for (int x = 0; x < SolidMapHeros.GetLength(0); x++) {
                    if ((x == 0 || x == 41) || (y == 0 || y == 27)) {
                        SolidMapHeros[x, y] = true;
                        SolidMapAi[x, y] = true;
                    }
                    else {
                        SolidMapHeros[x, y] = false;
                        SolidMapAi[x, y] = false;
                    }
                }
            }

            // Changement des bools dans TileSolidMap a solide ou les enclos sont places.
            for (int y = 0; y < SolidMapHeros.GetLength(1); y++) {
                for (int x = 0; x < SolidMapHeros.GetLength(0); x++) {
                    if ((y == 7 || y == 12 || y == 15 || y == 20) && ((x >= 8 && x <= 19) || (x >= 22 && x <= 33))) {       // Verifie ou les enclos horizontals se retrouvent.
                        SolidMapHeros[x, y] = true;
                        SolidMapAi[x, y] = true;
                    }
                    else if ((x == 8 || x == 19 || x == 22 || x == 33) && ((y >= 8 && y <= 11) || (y >= 16 && y <= 19))) {  // Verifie ou les enclos verticals se retrouvent.
                        SolidMapHeros[x, y] = true;
                        SolidMapAi[x, y] = true;
                    }
                }
            }
            // Change a false les entrees pour les enclos
            for (int i = 0; i < SolidMapHeros.GetLength(0); i++) {
                if (i == 13 || i == 14 || i == 27 || i == 28) {
                    SolidMapHeros[i, 7] = false;
                    SolidMapHeros[i, 20] = false;
                }
            }

            // La maison est solide
            for (int y = 1; y < 6; y++) {
                for (int x = 1; x < 5; x++) {
                    SolidMapHeros[x, y] = true;
                    SolidMapAi[x, y] = true;
                }
            }
        }

        static void InitSurfaceEnclosMap() {
            for (int y = 0; y < SurfaceEnclosMap.GetLength(1); y++) {
                for (int x = 0; x < SurfaceEnclosMap.GetLength(0); x++) {
                    if ((x > 7 && x < 18)) {
                        if (y > 6 && y < 11) {
                            SurfaceEnclosMap[x, y] = 1;
                        }
                        else if (y > 14 && y < 19) {
                            SurfaceEnclosMap[x, y] = 3;
                        }
                    }
                    else if (x > 21 && x < 32) {
                        if (y > 6 && y < 11) {
                            SurfaceEnclosMap[x, y] = 2;
                        }
                        else if (y > 14 && y < 19) {
                            SurfaceEnclosMap[x, y] = 4;
                        }
                    }
                }
            }
        }

        static void InitOccupeAiMap() {
            for (int y = 0; y < OccupeAiMap.GetLength(1); y++) {
                for (int x = 0; x < OccupeAiMap.GetLength(0); x++) {
                    OccupeAiMap[x, y] = false;
                }
            }
        }

        // testing purposes
        public static void PrintSolidMapHeros() {
            Console.WriteLine("SOLID MAPPING HERO: ");
            for (int y = 0; y < SolidMapHeros.GetLength(1); y++) {
                for (int x = 0; x < SolidMapHeros.GetLength(0); x++) {
                    if (SolidMapHeros[x, y]) {
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
        public static void PrintSolidMapAi() {
            Console.WriteLine("SOLID MAPPING AI: ");
            for (int y = 0; y < SolidMapAi.GetLength(1); y++) {
                for (int x = 0; x < SolidMapAi.GetLength(0); x++) {
                    if (SolidMapAi[x, y]) {
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
        public static void PrintSurfaceEnclosMap() {
            Console.WriteLine("SURFACE MAPPING ENCLOS: ");
            for (int y = 0; y < SurfaceEnclosMap.GetLength(1); y++) {
                for (int x = 0; x < SurfaceEnclosMap.GetLength(0); x++) {
                    if (SurfaceEnclosMap[x, y] == 0) {
                        Console.Write("- ");
                    }
                    else {
                        Console.Write(SurfaceEnclosMap[x, y] + " ");
                    }
                }
                Console.Write("\n");
            }
        }

        // testing purposes
        public static void PrintOccupeAiMap() {
            Console.WriteLine("AI OCCUPE MAPPING: ");
            for (int y = 0; y < OccupeAiMap.GetLength(1); y++) {
                for (int x = 0; x < OccupeAiMap.GetLength(0); x++) {
                    if (OccupeAiMap[x, y]) {
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


        public static void PeintureMap(PaintEventArgs e) {
            PeintureGazon(e);
            PeintureCheminSable(e);
            PeintureEnclos(e);
            PeintureMaison(e);
            PeintureCadriage(e);
        }


        private static void PeintureCadriage(PaintEventArgs e) {
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


        private static void PeintureGazon(PaintEventArgs e) {
            for (int y = 0; y < 26; y++) {
                for (int x = 0; x < 40; x++) {
                    e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(1), TuileAPixel(x), TuileAPixel(y));
                }
            }
        }


        private static void PeintureCheminSable(PaintEventArgs e) {
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


        private static void PeintureEnclos(PaintEventArgs e) {
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

            // Peinture les entrees
            for (int i = 0; i < SolidMapHeros.GetLength(0); i++) {
                if (i == 12 || i == 13 || i == 26 || i == 27) {
                    e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(1), TuileAPixel(i), TuileAPixel(6));
                    e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(1), TuileAPixel(i), TuileAPixel(19));
                }
            }
        }


        private static void PeintureMaison(PaintEventArgs e) {
            e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(5), TuileAPixel(0), 0);
        }
    }
}
