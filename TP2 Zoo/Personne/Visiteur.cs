using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Zoo;
using TP2_Zoo.Ai;

namespace TP2_Zoo.Personne {
    public abstract class Visiteur : Personne {

        public String Nom { get; set; }
        public String Sexe { get; set; }
        public int NbrJours { get; set; }
        public int NbrDechets { get; set; }
        public int PrixEntree { get; set; }
        // static Random r = new Random();

        public Visiteur() {
            Position = new int[] {19, 0 };
            Ai.Ai.OccuperTuile(19, 0);
            PrixEntree = 2;
        }



        public void Deplacer(int[] positionHero) {
            Ai.Ai.ChoisirDirection(Position, positionHero);
        }
    }
}
