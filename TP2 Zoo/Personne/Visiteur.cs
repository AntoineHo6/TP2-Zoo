using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Zoo.Personne
{
    class Visiteur : Personne
    {
        String Nom { get; set; }
        String Sexe { get; set; }
        int NbrJours { get; set; }
        int NbrDechets { get; set; }
        int PrixEntree { get; } = 2;

        public Visiteur(int Position, String Nom, String Sexe, int NbrJours, int PrixEntree) : base(Position)
        {
            this.Position = Position;
            this.Nom = Nom;
            this.Sexe = Sexe;
            this.NbrJours = NbrJours;
            this.PrixEntree = PrixEntree;
        }

    }
}
