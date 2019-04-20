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
            int direction = r.Next(1, 5);
            //TODO: Ne pas permettre l'acces a travers les enclos.
            switch (direction) {    // Additionne 1 aux positions parce que le tableau GerantCarte.SolidMapping a une bordure.
                case 1:
                    if (!GerantCarte.SolidMappingAi[Position[0] + 1, Position[1] + 1 - 1]) {
                        Position[1] -= 1;
                    }
                    break;
                case 2:
                    if (!GerantCarte.SolidMappingAi[Position[0] + 1, Position[1] + 1 + 1]) {
                        Position[1] += 1;
                    }
                    break;
                case 3:
                    if (!GerantCarte.SolidMappingAi[Position[0] + 1 - 1, Position[1] + 1]) {
                        Position[0] -= 1;
                    }
                    break;
                case 4:
                    if (!GerantCarte.SolidMappingAi[Position[0] + 1 + 1, Position[1] + 1]) {
                        Position[0] += 1;
                    }
                    break;
            }
        }
    }
}
