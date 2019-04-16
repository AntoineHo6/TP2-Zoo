using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Zoo.Personne {
    public class Concierge : Personne {

        int Frais { get; set; }

        public Concierge(params int[] Position) : base(Position) {
            this.Position = Position;
            Frais = 2;
        }
    }
}
