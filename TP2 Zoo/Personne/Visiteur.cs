using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Zoo;

namespace TP2_Zoo.Personne {
    public abstract class Visiteur : Personne {

        public String Nom { get; set; }
        public String Sexe { get; set; }
        public int NbrJours { get; set; }
        public int NbrDechets { get; set; }
        public int PrixEntree { get; set; }
        static Random r = new Random();

        public Visiteur() {
            Position = new int[] {19, 0 };
            PrixEntree = 2;
        }


        // A REFACTOR: CHANGER LORDRE
        /*
         * en haut: 1
         * en bas:  2
         * à gauche: 3
         * à droite: 4
         * 
         */
        public void Deplacer() {
            int direction = r.Next(1, 5);

            switch (direction) {    // Additionne 1 aux positions parce que le tableau GerantCarte.SolidMapping a une bordure.
                case 1:
                    if (!GerantCarte.SolidMapping[Position[0]+1, Position[1]+1 - 1]) {
                        Position[1] -= 1;
                    }
                    break;
                case 2:
                    if (!GerantCarte.SolidMapping[Position[0]+1, Position[1]+1 + 1]) {
                        Position[1] += 1;
                    }
                    break;
                case 3:
                    if (!GerantCarte.SolidMapping[Position[0]+1 - 1, Position[1]+1]) {
                        Position[0] -= 1;
                    }
                    break;
                case 4:
                    if (!GerantCarte.SolidMapping[Position[0]+1 + 1, Position[1]+1]) {
                        Position[0] += 1;
                    }
                    break;
            }
        }
    }
}
