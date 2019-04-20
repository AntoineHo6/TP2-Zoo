using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Zoo.Animal {
    public class Licorne : Animal {

        public Licorne(params int[] Position) : base(Position) {
            Prix = 50;
            Type = "Licorne";
        }

        public override void Crier() {
            SoundPlayer Son = new SoundPlayer(TP2_Zoo.Properties.Resources.licorne);
            Son.Play();
        }
    }
}
