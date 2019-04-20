using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2_Zoo.Personne {
    public class Hero : Personne {
        int Argent { get; set; }

        public Hero() {
            this.Position = new int[] { 1, 5 };
            Argent = 100;

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
        }

        public void Deplacer(KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.W:
                    if (!GerantCarte.SolidMappingHero[Position[0] + 1, Position[1] + 1 - 1]) {
                        Position[1] -= 1;
                    }
                    break;
                case Keys.A:
                    if (!GerantCarte.SolidMappingHero[Position[0] + 1 - 1, Position[1] + 1]) {
                        Position[0] -= 1;
                    }
                    break;
                case Keys.S:
                    if (!GerantCarte.SolidMappingHero[Position[0] + 1, Position[1] + 1 + 1]) {
                        Position[1] += 1;
                    }
                    break;
                case Keys.D:
                    if (!GerantCarte.SolidMappingHero[Position[0] + 1 + 1, Position[1] + 1]) {
                        Position[0] += 1;
                    }
                    break;
            }
        }
    }
}
