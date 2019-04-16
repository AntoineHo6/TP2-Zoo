using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Zoo.Personne {
    abstract class Personne {

        public int[] Position;

        public Personne(int[] Position) {
            this.Position = Position;
        }

    }
}
