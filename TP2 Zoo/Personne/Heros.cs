using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2_Zoo.Personne {
    public class Heros : Personne {
        public double Argent { get; set; }
        public int Sprite { get; set; }
        public int RotationSpriteBas { get; set; }
        public int RotationSpriteDroite { get; set; }
        public int RotationSpriteGauche { get; set; }
        public int RotationSpriteHaut { get; set; }


        public Heros() {
            this.Position = new int[] { 1, 5 };
            Argent = 100.0;

            Sprites.Add(Properties.Resources.bas1);     // 0
            Sprites.Add(Properties.Resources.bas2);     // 1
            Sprites.Add(Properties.Resources.bas3);     // 2
            Sprites.Add(Properties.Resources.droite1);  // 3
            Sprites.Add(Properties.Resources.droite2);  // 4
            Sprites.Add(Properties.Resources.gauche1);  // 5
            Sprites.Add(Properties.Resources.gauche2);  // 6
            Sprites.Add(Properties.Resources.haut1);    // 7
            Sprites.Add(Properties.Resources.haut2);    // 8
            Sprites.Add(Properties.Resources.haut3);    // 9

            RotationSpriteBas = 0;
            RotationSpriteDroite = 3;
            RotationSpriteGauche = 5;
            RotationSpriteHaut = 7;
        }

        /// <summary>
        ///     Méthode qui permet le déplacement de l'héros avec les touches WASD du clavier.
        /// </summary>
        /// <param name="e"></param>
        public void Deplacer(KeyEventArgs e) {
            int x = Position[0];
            int y = Position[1];

            switch (e.KeyCode) {
                case Keys.W:
                    if (!GerantCarte.SolidMapHeros[ToSolidCoord(x), ToSolidCoord(y) - 1] && !GerantCarte.PosAiMap[Position[0], Position[1] - 1]) {
                        Position[1] -= 1;
                        Sprite = RotationSpriteHaut;
                        
                        if (RotationSpriteHaut == 9) {
                            RotationSpriteHaut = 7;
                        }
                        else {
                            RotationSpriteHaut++;
                        }
                    }
                    break;
                case Keys.A:
                    if (!GerantCarte.SolidMapHeros[ToSolidCoord(x) - 1, ToSolidCoord(y)] && !GerantCarte.PosAiMap[Position[0] - 1, Position[1]]) {
                        Position[0] -= 1;
                        Sprite = RotationSpriteGauche;

                        if (RotationSpriteGauche == 6) {
                            RotationSpriteGauche = 5;
                        }
                        else {
                            RotationSpriteGauche++;
                        }
                    }
                    break;
                case Keys.S:
                    if (!GerantCarte.SolidMapHeros[ToSolidCoord(x), ToSolidCoord(y) + 1] && !GerantCarte.PosAiMap[Position[0], Position[1] + 1]) {
                        Position[1] += 1;
                        Sprite = RotationSpriteBas;

                        if (RotationSpriteBas == 2) {
                            RotationSpriteBas = 0;
                        }
                        else {
                            RotationSpriteBas++;
                        }
                    }
                    break;
                case Keys.D:
                    if (!GerantCarte.SolidMapHeros[ToSolidCoord(x) + 1, ToSolidCoord(y)] && !GerantCarte.PosAiMap[Position[0] + 1, Position[1]]) {
                        Position[0] += 1;
                        Sprite = RotationSpriteDroite;

                        if (RotationSpriteDroite == 4) {
                            RotationSpriteDroite = 3;
                        }
                        else {
                            RotationSpriteDroite++;
                        }
                    }
                    break;
            }
        }

        int ToSolidCoord(int coord) {
            return coord + 1;
        }
    }
}
