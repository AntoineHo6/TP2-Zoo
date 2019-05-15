using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using tileSetZoo;
using TP2_Zoo.Noms;

namespace TP2_Zoo {
    public static class GerantCarte {

        public static bool[,] SolidMapHeros = new bool[42, 28];  // Plus large pour créer une bordure solide autour de la carte.
        public static bool[,] SolidMapAi = new bool[42, 28];    // Pour les visiteurs et les animaux.
        public static bool[,] PosAiMap = new bool[40, 26];   // Position occupée des visiteurs et des animaux.
        public static int[,] SurfaceEnclosMap = new int[40, 26];    // Vérifie quelles tuiles sont dans l'enclos. 1: NW, 2: NE, 3: SW, 4: SE
        public static String[] AnimalEnclos = new String[5];        // Stock le type d'animal que chaque enclos contient. Commence à l'index 1.
        public static bool[,] PosDechetsMap = new bool[40, 26];     // Position occupée des déchets

        static GerantCarte() {
            InitSolidMaps();
            InitSurfaceEnclosMap();
        }

        /// <summary>
        ///     Méthode qui initialise le tableau de collisions de jeu.
        /// </summary>
        private static void InitSolidMaps() {
            // Par defaut, tout n'est pas solide à part la bordure.
            for (int y = 0; y < SolidMapHeros.GetLength(1); y++) {
                for (int x = 0; x < SolidMapHeros.GetLength(0); x++) {
                    if ((x == 0 || x == 41) || (y == 0 || y == 27)) {
                        SolidMapHeros[x, y] = true;
                        SolidMapAi[x, y] = true;
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

            // Change a false les entrées pour les enclos
            for (int i = 0; i < SolidMapHeros.GetLength(0); i++) {
                if (i == 13 || i == 14 || i == 27 || i == 28) {
                    SolidMapHeros[i, 7] = false;
                    SolidMapHeros[i, 20] = false;
                }
            }

            // La maison est solide
            for (int y = 1; y < 6; y++) {
                for (int x = 37; x < 41; x++) {
                    SolidMapHeros[x, y] = true;
                    SolidMapAi[x, y] = true;
                }
            }

            // Le bâtiment de concierges est solide
            for (int y = 1; y < 6; y++) {
                for (int x = 1; x < 5; x++) {
                    SolidMapHeros[x, y] = true;
                    SolidMapAi[x, y] = true;
                }
            }
        }

        private static void InitSurfaceEnclosMap() {
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

        // Taille de 40 x 26 ou (39 x 25 si on commmence par index 0)
        static int TuileAPixel(int Tuile) {
            return Tuile * 32;
        }

        /// <summary>
        ///     Méthode qui peint l'interface visuelle du jeu.
        /// </summary>
        /// <param name="e"></param>
        public static void PeintureMap(PaintEventArgs e) {
            PeintureGazon(e);
            PeintureEau(e);
            PeintureCheminSable(e);
            PeintureEnclos(e);
            PeintureMaison(e);
            PeinturerEdificeConcierge(e);
            // PeintureCadriage(e);
            PeinturerDechet(e);
        }


        private static void PeintureCadriage(PaintEventArgs e) {
            Pen blackPen = new Pen(Color.Black, 1);

            // Peinture des lignes verticales
            for (int i = 0; i < 40; i++) {
                e.Graphics.DrawLine(blackPen, TuileAPixel(i), 0, TuileAPixel(i), 832);
            }

            // Peinture des lignes horizontales
            for (int i = 0; i < 26; i++) {
                e.Graphics.DrawLine(blackPen, 0, TuileAPixel(i), 1296, TuileAPixel(i));
            }
        }


        private static void PeintureGazon(PaintEventArgs e) {
            // Peinture gazon normal partout.
            for (int y = 0; y < 26; y++) {
                for (int x = 0; x < 40; x++) {
                    e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(1), TuileAPixel(x), TuileAPixel(y));
                }
            }

            // Peinture gazon_haut dans les enclos
            for (int y = 0; y < 26; y++) {
                for (int x = 0; x < 40; x++) {
                    if (((x > 6 && x < 19) || (x > 20 && x < 33)) && ((y > 5 && y < 12) || (y > 13 && y < 20))) {
                        e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(7), TuileAPixel(x), TuileAPixel(y));
                    }
                }
            }
        }

        /// <summary>
        ///     Méthode qui peint des images d'eau.
        /// </summary>
        /// <param name="e"></param>
        private static void PeintureEau(PaintEventArgs e) {
            for (int y = 0; y < 26; y++) {
                for (int x = 0; x < 40; x++) {
                    if ((x == 17 || x == 22) && (y == 10 || y == 15)) {
                        e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(8), TuileAPixel(x), TuileAPixel(y));
                    }
                }
            }
        }

        /// <summary>
        ///     Méthode qui peint l'allée de sable.
        /// </summary>
        /// <param name="e"></param>
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

        /// <summary>
        ///     Méthode qui peint les enclos des animaux.
        /// </summary>
        /// <param name="e"></param>
        private static void PeintureEnclos(PaintEventArgs e) {
            // Peinture enclos horizontales.
            for (int x = 0; x < 11; x++) {
                // pour l'enclos en haut à gauche.
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(2), TuileAPixel(7 + x) + 8, TuileAPixel(6));
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(2), TuileAPixel(7 + x) + 8, TuileAPixel(11));

                // pour l'enclos en haut à droite.
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(2), TuileAPixel(21 + x) + 8, TuileAPixel(6));
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(2), TuileAPixel(21 + x) + 8, TuileAPixel(11));

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
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(3), TuileAPixel(7), TuileAPixel(6 + y));
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(3), TuileAPixel(18), TuileAPixel(6 + y));

                // pour l'enclos en haut à droite.
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(3), TuileAPixel(21), TuileAPixel(6 + y));
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(3), TuileAPixel(32), TuileAPixel(6 + y));

                // Peinture l'enclos en bas à gauche.
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(3), TuileAPixel(7), TuileAPixel(14 + y));
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(3), TuileAPixel(18), TuileAPixel(14 + y));

                // Peinture l'enclos en bas à droite.
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(3), TuileAPixel(21), TuileAPixel(14 + y));
                e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(3), TuileAPixel(32), TuileAPixel(14 + y));
            }

            // Peinture les entrées
            for (int i = 0; i < SolidMapHeros.GetLength(0); i++) {
                if (i == 12 || i == 13 || i == 26 || i == 27) {
                    e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(7), TuileAPixel(i), TuileAPixel(6));
                    e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(7), TuileAPixel(i), TuileAPixel(19));
                }
            }
        }

        /// <summary>
        ///     Méthode qui peint la maison de l'héros.
        /// </summary>
        /// <param name="e"></param>
        private static void PeintureMaison(PaintEventArgs e) {
            e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(5), 0, 0);
        }

        /// <summary>
        ///     Méthode qui peint l'édifice du concierge.
        /// </summary>
        /// <param name="e"></param>
        private static void PeinturerEdificeConcierge(PaintEventArgs e) {
            e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(9), TuileAPixel(36), 0);
        }

        /// <summary>
        ///     Méthode qui peint des déchets.
        /// </summary>
        /// <param name="e"></param>
        private static void PeinturerDechet(PaintEventArgs e) {
            for (int y = 0; y < PosDechetsMap.GetLength(1); y++) {
                for (int x = 0; x < PosDechetsMap.GetLength(0); x++) {
                    if (PosDechetsMap[x, y]) {
                        e.Graphics.DrawImage(MapTileSetImageGenerator.GetTile(6), TuileAPixel(x), TuileAPixel(y));
                    }
                }
            }
        }
    }
}
