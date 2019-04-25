using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileSetZoo {
    class VisiteurTileSetImageGenerator {
        // Différentes tailles concernant les images dans le fichier de tuiles de jeu
        public const int IMAGE_WIDTH = 32, IMAGE_HEIGHT = 32;


        public static int PEPE_FACE1 = 0;
        public static int PEPE_DOS1 = 1;
        public static int PEPE_GAUCHE1 = 2;
        public static int PEPE_DROITE1 = 3;



        private static List<TileCoord> listeCoord = new List<TileCoord>();
        private static List<Bitmap> listeBitmap = new List<Bitmap>();

        /// <summary>
        /// Constructeur statique
        /// </summary>
        static VisiteurTileSetImageGenerator() {

            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 0 }); // PEPE_FACE1
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 1 }); // PEPE_DOS1
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 2 }); // PEPE_GAUCHE1
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 2 }); // PEPE_DROITE1


            listeBitmap.Add(LoadTile(PEPE_FACE1));  // PEPE_FACE1
            listeBitmap.Add(LoadTile(PEPE_DOS1));  // PEPE_DOS1
            listeBitmap.Add(LoadTile(PEPE_GAUCHE1));  // PEPE_GAUCHE1
            listeBitmap.Add(LoadTile(PEPE_DROITE1));  // PEPE_DROITE1
            listeBitmap.Last().RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

        private static Bitmap LoadTile(int posListe) {
            Image source = TP2_Zoo.Properties.Resources.personnages;
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

