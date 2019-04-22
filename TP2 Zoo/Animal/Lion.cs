using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using tileSetZoo;

namespace TP2_Zoo.Animal {
    public class Lion : Animal {

        public Lion(bool EstAdulte, params int[] Position) : base(EstAdulte, Position) {
            Prix = 35;
            Type = "Lion";

            Sprites.Add(AnimalTileSetImageGenerator.GetTile(1));
        }
        public override void Crier() {
            SoundPlayer Son = new SoundPlayer(TP2_Zoo.Properties.Resources.lion_son);
            Son.Play();
        }

        
    }
}
