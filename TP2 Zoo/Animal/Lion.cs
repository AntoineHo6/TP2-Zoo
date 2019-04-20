using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Zoo.Animal {
    public class Lion : Animal {

        public Lion(params int[] Position) : base(Position) {
            Prix = 35;
            Type = "Lion";
        }
        public override void Crier() {
            SoundPlayer Son = new SoundPlayer(TP2_Zoo.Properties.Resources.lion);
            Son.Play();
        }

        
    }
}
