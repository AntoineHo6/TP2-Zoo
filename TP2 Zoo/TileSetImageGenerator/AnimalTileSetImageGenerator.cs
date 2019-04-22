using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileSetZoo {
    class AnimalTileSetImageGenerator {
        // Différentes tailles concernant les images dans le fichier de tuiles de jeu
        public const int IMAGE_WIDTH = 32, IMAGE_HEIGHT = 32;

        public static int MOUTON_NEUTRE1 = 0;
        public static int LION_NEUTRE1 = 1;
        public static int LICORNE_NEUTRE1 = 2;


        private static List<TileCoord> listeCoord = new List<TileCoord>();
        private static List<Bitmap> listeBitmap = new List<Bitmap>();

        /// <summary>
        /// Constructeur statique
        /// </summary>
        static AnimalTileSetImageGenerator() {
            listeCoord.Add(new TileCoord() { Ligne = 19, Colonne = 8 });    // MOUTON_NEUTRE1
            listeCoord.Add(new TileCoord() { Ligne = 16, Colonne = 24 });   // LION_NEUTRE1
            listeCoord.Add(new TileCoord() { Ligne = 16, Colonne = 16 });   // LICORNE_NEUTRE1

            listeBitmap.Add(LoadTile(MOUTON_NEUTRE1));   // MOUTON_NEUTRE1
            listeBitmap.Add(LoadTile(LION_NEUTRE1));     // LION_NEUTRE1
            listeBitmap.Add(LoadTile(LICORNE_NEUTRE1));  // LICORNE_NEUTRE1

        }

        private static Bitmap LoadTile(int posListe) {
            Image source = TP2_Zoo.Properties.Resources.zoo_tileset;
            TileCoord coord = listeCoord[posListe];
            Rectangle crop = new Rectangle((coord.Colonne * IMAGE_WIDTH), (coord.Ligne * IMAGE_HEIGHT), IMAGE_WIDTH, IMAGE_HEIGHT);

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

    //public class TileCoord {
    //    public int Ligne { get; set; }
    //    public int Colonne { get; set; }
    //};
}

