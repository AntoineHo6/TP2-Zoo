using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileSetZoo {
    class MapTileSetImageGenerator {
        // Différentes tailles concernant les images dans le fichier de tuiles de jeu
        public const int IMAGE_WIDTH = 32, IMAGE_HEIGHT = 32;

        // Map
        public static int FLAQUEDEAU = 0;
        public static int GAZON = 1;
        public static int ENCLOS_H = 2;
        public static int ENCLOS_V = 3;
        public static int SABLE = 4;
        public static int MAISON = 5;
        public static int DECHET = 6;
        public static int GAZON_HAUT = 7;
        public static int FOSSE_EAU = 8;
        public static int EDIFICE_CONCIERGE = 9;

        private static List<TileCoord> ListeCoord = new List<TileCoord>();
        private static List<Bitmap> ListeBitMap = new List<Bitmap>();

        /// <summary>
        /// Constructeur statique
        /// </summary>
        static MapTileSetImageGenerator() {
            ListeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 0 });     // FLAQUEDEAU
            ListeCoord.Add(new TileCoord() { Ligne = 8, Colonne = 0 });     // GAZON
            ListeCoord.Add(new TileCoord() { Ligne = 14, Colonne = 22 });   // ENCLOS HORIZONTAL
            ListeCoord.Add(new TileCoord() { Ligne = 10, Colonne = 18 });   // ENCLOS VERTICAL
            ListeCoord.Add(new TileCoord() { Ligne = 14, Colonne = 4 });    // SABLE
            ListeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 18 });    // MAISON
            ListeCoord.Add(new TileCoord() { Ligne = 23, Colonne = 1 });    // DECHET
            ListeCoord.Add(new TileCoord() { Ligne = 8, Colonne = 3 });     // GAZON_HAUT
            ListeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 2 });     // FOSSE_EAU
            ListeCoord.Add(new TileCoord() { Ligne = 4, Colonne = 12 });     // EDIFICE_CONCIERGE


            ListeBitMap.Add(LoadTile(FLAQUEDEAU, 32, 32));            // FLAQUEDEAU
            ListeBitMap.Add(LoadTile(GAZON, 32, 32));                 // GAZON
            ListeBitMap.Add(LoadTile(ENCLOS_H, 64, 32));              // ENCLOS HORIZONTAL
            ListeBitMap.Add(LoadTile(ENCLOS_V, 32, 32));              // ENCLOS VERTICAL
            ListeBitMap.Add(LoadTile(SABLE, 32, 32));                 // SABLE
            ListeBitMap.Add(LoadTile(MAISON, 128, 160));              // MAISON
            ListeBitMap.Add(LoadTile(DECHET, 32, 32));                // DECHET
            ListeBitMap.Add(LoadTile(GAZON_HAUT, 32, 32));            // GAZON_HAUT
            ListeBitMap.Add(LoadTile(FOSSE_EAU, 32, 32));             // FOSSE_EAU
            ListeBitMap.Add(LoadTile(EDIFICE_CONCIERGE, 128, 160));   // EDIFICE_CONCIERGE
        }

        private static Bitmap LoadTile(int posListe, int imageWidth, int imageHeight) {
            Image source = TP2_Zoo.Properties.Resources.zoo_tileset;
            TileCoord coord = ListeCoord[posListe];
            Rectangle crop = new Rectangle((coord.Colonne * IMAGE_WIDTH), (coord.Ligne * IMAGE_HEIGHT), imageWidth, imageHeight);

            var bmp = new Bitmap(crop.Width, crop.Height);
            using (var gr = Graphics.FromImage(bmp)) {
                gr.DrawImage(source, new Rectangle(0, 0, bmp.Width, bmp.Height), crop, GraphicsUnit.Pixel);
            }
            return bmp;
        }

        public static Bitmap GetTile(int posListe) {
            return ListeBitMap[posListe];
        }

    }

    public class TileCoord {
        public int Ligne { get; set; }
        public int Colonne { get; set; }
    };
}

