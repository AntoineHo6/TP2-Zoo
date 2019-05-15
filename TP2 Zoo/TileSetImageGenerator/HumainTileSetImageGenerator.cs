using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileSetZoo {
    class HumainTileSetImageGenerator {
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

        // MONSIEUR
        public static int MONSIEUR_FACE = 12;
        public static int MONSIEUR_DOS = 13;
        public static int MONSIEUR_GAUCHE = 14;
        public static int MONSIEUR_DROITE = 15;

        // CONCIERGE
        public static int CONCIERGE_FACE = 16;
        public static int CONCIERGE_DOS = 17;
        public static int CONCIERGE_GAUCHE = 18;
        public static int CONCIERGE_DROITE = 19;


        private static List<TileCoord> ListeCoord = new List<TileCoord>();
        private static List<Bitmap> ListeBitMap = new List<Bitmap>();

        /// <summary>
        /// Constructeur statique
        /// </summary>
        static HumainTileSetImageGenerator() {

            ListeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 0 }); // PEPE_FACE
            ListeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 1 }); // PEPE_DOS
            ListeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 2 }); // PEPE_GAUCHE
            ListeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 2 }); // PEPE_DROITE

            ListeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 0 }); // DAME_FACE
            ListeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 1 }); // DAME_DOS
            ListeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 2 }); // DAME_GAUCHE
            ListeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 2 }); // DAME_DROITE

            ListeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 0 }); // FILLETTE_FACE
            ListeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 1 }); // FILLETTE_DOS
            ListeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 2 }); // FILLETTE_GAUCHE
            ListeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 2 }); // FILLETTE_DROITE

            ListeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 0 }); // MONSIEUR_FACE
            ListeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 1 }); // MONSIEUR_DOS
            ListeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 2 }); // MONSIEUR_GAUCHE
            ListeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 2 }); // MONSIEUR_DROITE

            ListeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 0});  // CONCIERGE_FACE
            ListeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 1 }); // CONCIERGE_DOS
            ListeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 2 }); // CONCIERGE_GAUCHE
            ListeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 2 }); // CONCIERGE_DROITE

            ListeBitMap.Add(LoadTile(PEPE_FACE));       // PEPE_FACE
            ListeBitMap.Add(LoadTile(PEPE_DOS));        // PEPE_DOS
            ListeBitMap.Add(LoadTile(PEPE_GAUCHE));     // PEPE_GAUCHE
            ListeBitMap.Add(LoadTile(PEPE_DROITE));     // PEPE_DROITE
            ListeBitMap.Last().RotateFlip(RotateFlipType.RotateNoneFlipX);

            ListeBitMap.Add(LoadTile(DAME_FACE));       // DAME_FACE
            ListeBitMap.Add(LoadTile(DAME_DOS));        // DAME_DOS
            ListeBitMap.Add(LoadTile(DAME_GAUCHE));     // DAME_GAUCHE
            ListeBitMap.Add(LoadTile(DAME_DROITE));     // DAME_DROITE
            ListeBitMap.Last().RotateFlip(RotateFlipType.RotateNoneFlipX);

            ListeBitMap.Add(LoadTile(FILLETTE_FACE));   // FILLETTE_FACE
            ListeBitMap.Add(LoadTile(FILLETTE_DOS));    // FILLETTE_DOS
            ListeBitMap.Add(LoadTile(FILLETTE_GAUCHE)); // FILLETTE_GAUCHE
            ListeBitMap.Add(LoadTile(FILLETTE_DROITE)); // FILLETTE_DROITE
            ListeBitMap.Last().RotateFlip(RotateFlipType.RotateNoneFlipX);

            ListeBitMap.Add(LoadTile(MONSIEUR_FACE));   // MONSIEUR_FACE
            ListeBitMap.Add(LoadTile(MONSIEUR_DOS));    // MONSIEUR_DOS
            ListeBitMap.Add(LoadTile(MONSIEUR_GAUCHE)); // MONSIEUR_GAUCHE
            ListeBitMap.Add(LoadTile(MONSIEUR_DROITE)); // MONSIEUR_DROITE
            ListeBitMap.Last().RotateFlip(RotateFlipType.RotateNoneFlipX);

            ListeBitMap.Add(LoadTile(CONCIERGE_FACE));  // CONCIERGE_FACE
            ListeBitMap.Add(LoadTile(CONCIERGE_DOS));  // CONCIERGE_DOS
            ListeBitMap.Add(LoadTile(CONCIERGE_GAUCHE));  // CONCIERGE_GAUCHE
            ListeBitMap.Add(LoadTile(CONCIERGE_DROITE));  // CONCIERGE_DROITE
            ListeBitMap.Last().RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

        private static Bitmap LoadTile(int posListe) {
            Image source = TP2_Zoo.Properties.Resources.personnages;
            TileCoord coord = ListeCoord[posListe];
            Rectangle crop = new Rectangle((coord.Colonne * IMAGE_WIDTH), (coord.Ligne * IMAGE_HEIGHT), IMAGE_WIDTH, IMAGE_HEIGHT);

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
}

