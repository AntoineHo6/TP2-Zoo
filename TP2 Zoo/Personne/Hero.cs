using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Zoo.Personne {
    public class Hero : Personne {
        int Argent { get; set; }

        public Hero(params int[] Position) : base(Position) {
            this.Position = Position;
            Argent = 100;
        }
    }
}
