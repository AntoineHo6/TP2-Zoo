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

        private static List<TileCoord> listeCoord = new List<TileCoord>();
        private static List<Bitmap> listeBitmap = new List<Bitmap>();

        /// <summary>
        /// Constructeur statique
        /// </summary>
        static MapTileSetImageGenerator() {
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 0 });     // FLAQUEDEAU
            listeCoord.Add(new TileCoord() { Ligne = 8, Colonne = 0 });     // GAZON
            listeCoord.Add(new TileCoord() { Ligne = 14, Colonne = 22 });   // ENCLOS HORIZONTAL
            listeCoord.Add(new TileCoord() { Ligne = 10, Colonne = 18 });   // ENCLOS VERTICAL
            listeCoord.Add(new TileCoord() { Ligne = 14, Colonne = 4 });    // SABLE
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 18 });    // MAISON
            listeCoord.Add(new TileCoord() { Ligne = 24, Colonne = 1 });    // DECHET
            listeCoord.Add(new TileCoord() { Ligne = 8, Colonne = 3 });     // GAZON_HAUT
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 2 });     // FOSSE_EAU


            listeBitmap.Add(LoadTile(FLAQUEDEAU, 32, 32));      // FLAQUEDEAU
            listeBitmap.Add(LoadTile(GAZON, 32, 32));           // GAZON
            listeBitmap.Add(LoadTile(ENCLOS_H, 64, 32));        // ENCLOS HORIZONTAL
            listeBitmap.Add(LoadTile(ENCLOS_V, 32, 32));        // ENCLOS VERTICAL
            listeBitmap.Add(LoadTile(SABLE, 32, 32));           // SABLE
            listeBitmap.Add(LoadTile(MAISON, 128, 160));        // MAISON
            listeBitmap.Add(LoadTile(DECHET, 32, 32));          // DECHET
            listeBitmap.Add(LoadTile(GAZON_HAUT, 32, 32));      // GAZON_HAUT
            listeBitmap.Add(LoadTile(FOSSE_EAU, 32, 32));             // FOSSE_EAU
        }

        private static Bitmap LoadTile(int posListe, int imageWidth, int imageHeight) {
            Image source = TP2_Zoo.Properties.Resources.zoo_tileset;
            TileCoord coord = listeCoord[posListe];
            Rectangle crop = new Rectangle((coord.Colonne * IMAGE_WIDTH), (coord.Ligne * IMAGE_HEIGHT), imageWidth, imageHeight);

            var bmp = new Bitmap(crop.Width, crop.Height);
            using (var gr = Graphics.FromImage(bmp)) {
                gr.DrawImage(source, new Rectangle(0, 0, bmp.Width, bmp.Height), crop, GraphicsUnit.Pixel);
            }
            return bmp;
        }

        public static Bitmap GetTile(int posListe) {
            return listeBitmap[posListe];
        }

    }

    public class TileCoord {
        public int Ligne { get; set; }
        public int Colonne { get; set; }
    };
}

