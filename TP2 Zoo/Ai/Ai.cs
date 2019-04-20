using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Zoo.Ai {
    public static class Ai {

        static Random r = new Random();

        static Ai() {

        }

        public static void ChoisirDirection(int[] Position) {
            int x = Position[0];
            int y = Position[1];

            int direction = r.Next(1, 5);
            switch (direction) {    // Additionne 1 aux positions parce que le tableau GerantCarte.SolidMapping a une bordure.
                case 1:
                    if (!GerantCarte.SolidMapAi[x + 1, (y + 1) - 1]) {
                        LibererTuile(x, y);
                        Position[1] -= 1;
                        OccuperTuile(Position[0], Position[1]);
                    }
                    break;
                case 2:
                    if (!GerantCarte.SolidMapAi[x + 1, (y + 1) + 1]) {
                        LibererTuile(x, y);
                        Position[1] += 1;
                        OccuperTuile(Position[0], Position[1]);
                    }
                    break;
                case 3:
                    if (!GerantCarte.SolidMapAi[(x + 1) - 1, y + 1]) {
                        LibererTuile(x, y);
                        Position[0] -= 1;
                        OccuperTuile(Position[0], Position[1]);
                    }
                    break;
                case 4:
                    if (!GerantCarte.SolidMapAi[(x + 1) + 1, y + 1]) {
                        LibererTuile(x, y);
                        Position[0] += 1;
                        OccuperTuile(Position[0], Position[1]);
                    }
                    break;
            }
        }

        public static void OccuperTuile(int x, int y) {
            GerantCarte.OccupeAiMap[x, y] = true;
        }

        public static void LibererTuile(int x, int y) {
            GerantCarte.OccupeAiMap[x, y] = false;
        }
    }
}
