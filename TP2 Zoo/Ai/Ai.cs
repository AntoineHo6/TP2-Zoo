using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Zoo;

namespace TP2_Zoo.Ai {
    public static class Ai {

        static Random r = new Random();

        static Ai() {

        }


        /*
         * 1: en haut
         * 2. en bas
         * 3. a gauche
         * 4. a droite
         */
        public static void ChoixDirectionAleatoire(int[] Position, int[] positionHero) {
            int x = Position[0];
            int y = Position[1];

            int direction = r.Next(1, 5);
            switch (direction) {    // Additionne 1 aux positions de SolidMapAi parce qu'il a une "bordure de solides".
                case 1:
                        // A REFACTOR LES CONDITIONS
                        // Si la prochaine tuile n'est pas un solide          Si le hero n'est pas sur la prochaine tuile                    si un ai n'est pas sur la prochaine tuile 
                    if (!GerantCarte.SolidMapAi[ToSolidCoord(x), ToSolidCoord(y) - 1] && (x != positionHero[0] && y - 1 != positionHero[1]) && !GerantCarte.PosAiMap[x, y - 1]) {
                        LibererTuile(x, y);
                        Position[1] -= 1;
                        OccuperTuile(Position[0], Position[1]);
                    }
                    break;
                case 2:
                    if (!GerantCarte.SolidMapAi[ToSolidCoord(x), ToSolidCoord(y) + 1] && (x != positionHero[0] && y + 1 != positionHero[1]) && !GerantCarte.PosAiMap[x, y + 1]) {
                        LibererTuile(x, y);
                        Position[1] += 1;
                        OccuperTuile(Position[0], Position[1]);
                    }
                    break;
                case 3:
                    if (!GerantCarte.SolidMapAi[ToSolidCoord(x) - 1, ToSolidCoord(y)] && (x - 1 != positionHero[0] && y != positionHero[1]) && !GerantCarte.PosAiMap[x - 1, y]) {
                        LibererTuile(x, y);
                        Position[0] -= 1;
                        OccuperTuile(Position[0], Position[1]);
                    }
                    break;
                case 4:
                    if (!GerantCarte.SolidMapAi[ToSolidCoord(x) + 1, ToSolidCoord(y)] && (x + 1 != positionHero[0] && y != positionHero[1]) && !GerantCarte.PosAiMap[x + 1, y]) {
                        LibererTuile(x, y);
                        Position[0] += 1;
                        OccuperTuile(Position[0], Position[1]);
                    }
                    break;
            }
        }

        public static void OccuperTuile(int x, int y) {
            GerantCarte.PosAiMap[x, y] = true;
        }

        public static void LibererTuile(int x, int y) {
            GerantCarte.PosAiMap[x, y] = false;
        }

        static int ToSolidCoord(int coord) {
            return coord + 1;
        }
    }
}
