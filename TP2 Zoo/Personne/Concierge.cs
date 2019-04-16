using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Zoo.Personne {
    class Concierge : Personne {

        int Frais { get; } = 2;
        public Concierge(int[] Position) : base(Position) {
            this.Position = Position;
        }
    }
}
