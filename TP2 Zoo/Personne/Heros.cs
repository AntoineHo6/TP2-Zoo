using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Zoo.Personne {
    class Heros : Personne {
        int Argent { get; set; } = 100;

        public Heros(int[] Position) : base(Position) {
            this.Position = Position;
        }
    }
}
