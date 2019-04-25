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

        // PEPE
        public static int PEPE_FACE = 0;
        public static int PEPE_DOS = 1;
        public static int PEPE_GAUCHE = 2;
        public static int PEPE_DROITE = 3;
        
        // DAME
        public static int DAME_FACE = 4;
        public static int DAME_DOS = 5;
        public static int DAME_GAUCHE = 6;
        public static int DAME_DROITE = 7;

        //FILLETTE
        public static int FILLETTE_FACE = 8;
        public static int FILLETTE_DOS = 9;
        public static int FILLETTE_GAUCHE = 10;
        public static int FILLETTE_DROITE = 11;


        private static List<TileCoord> listeCoord = new List<TileCoord>();
        private static List<Bitmap> listeBitmap = new List<Bitmap>();

        /// <summary>
        /// Constructeur statique
        /// </summary>
        static VisiteurTileSetImageGenerator() {

            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 0 }); // PEPE_FACE
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 1 }); // PEPE_DOS
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 2 }); // PEPE_GAUCHE
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 2 }); // PEPE_DROITE

            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 0 }); // DAME_FACE
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 1 }); // DAME_DOS
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 2 }); // DAME_GAUCHE
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 2 }); // DAME_DROITE

            listeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 0 }); // FILLETTE_FACE
            listeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 1 }); // FILLETTE_DOS
            listeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 2 }); // FILLETTE_GAUCHE
            listeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 2 }); // FILLETTE_DROITE



            listeBitmap.Add(LoadTile(PEPE_FACE));  // PEPE_FACE
            listeBitmap.Add(LoadTile(PEPE_DOS));  // PEPE_DOS
            listeBitmap.Add(LoadTile(PEPE_GAUCHE));  // PEPE_GAUCHE
            listeBitmap.Add(LoadTile(PEPE_DROITE));  // PEPE_DROITE
            listeBitmap.Last().RotateFlip(RotateFlipType.RotateNoneFlipX);

            listeBitmap.Add(LoadTile(DAME_FACE));  // DAME_FACE
            listeBitmap.Add(LoadTile(DAME_DOS));  // DAME_DOS
            listeBitmap.Add(LoadTile(DAME_GAUCHE));  // DAME_GAUCHE
            listeBitmap.Add(LoadTile(DAME_DROITE));  // DAME_DROITE
            listeBitmap.Last().RotateFlip(RotateFlipType.RotateNoneFlipX);

            listeBitmap.Add(LoadTile(FILLETTE_FACE));  // FILLETTE_FACE
            listeBitmap.Add(LoadTile(FILLETTE_DOS));  // FILLETTE_DOS
            listeBitmap.Add(LoadTile(FILLETTE_GAUCHE));  // FILLETTE_GAUCHE
            listeBitmap.Add(LoadTile(FILLETTE_DROITE));  // FILLETTE_DROITE
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

