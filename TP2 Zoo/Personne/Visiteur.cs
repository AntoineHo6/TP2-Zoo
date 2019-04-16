using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Zoo.Personne {
    public class Visiteur : Personne {

        String Nom { get; set; }
        String Sexe { get; set; }
        int NbrJours { get; set; }
        int NbrDechets { get; set; }
        int PrixEntree { get; set; }

        public Visiteur(String Nom, String Sexe, int NbrJours, params int[] Position) : base(Position) {
            this.Position = Position;
            this.Nom = Nom;
            this.Sexe = Sexe;
            this.NbrJours = NbrJours;
            this.PrixEntree = 2;
        }

    }
}
