using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileSetZoo {
    class TilesetImageGenerator {
        // Différentes tailles concernant les images dans le fichier de tuiles de jeu
        public const int IMAGE_WIDTH = 32, IMAGE_HEIGHT = 32;

        // La valeur entière correspond "par hasard" à la position de l'image dans la List<TileCoord>
        public static int FLAQUEDEAU = 0;
        public static int GAZON = 1;
        public static int ENCLOS = 2;
        public static int SABLE = 3;

        private static List<TileCoord> listeCoord = new List<TileCoord>();
        private static List<Bitmap> listeBitmap = new List<Bitmap>();

        /// <summary>
        /// Constructeur statique
        /// </summary>
        static TilesetImageGenerator() {
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 0 }); // FLAQUEDEAU
            listeCoord.Add(new TileCoord() { Ligne = 8, Colonne = 0 }); // GAZON
            listeCoord.Add(new TileCoord() { Ligne = 14, Colonne = 22 }); // ENCLOS
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 14 }); // SABLE

            listeBitmap.Add(LoadTile(FLAQUEDEAU, 32, 32));  // FLAQUEDEAU
            listeBitmap.Add(LoadTile(GAZON, 32, 32));       // GAZON
            listeBitmap.Add(LoadTile(ENCLOS, 64, 32));      // ENCLOS
            listeBitmap.Add(LoadTile(SABLE, 32, 32));      // SABLE
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

