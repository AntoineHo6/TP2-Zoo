using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TP2_Zoo.Personne {
    public abstract class Personne {

        public int[] Position { get; set; }
        public Bitmap[] Sprites { get; set; }

        public Personne(int[] Position) {
            this.Position = Position;
        }

    }
}
