using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using tileSetZoo;

namespace TP2_Zoo.Animal {
    public class Mouton : Animal {
        
        public Mouton(bool EstAdulte, params int[] Position) : base(EstAdulte, Position) {
            Prix = 20;
            Type = "Mouton";

            // temp
            Sprites.Add(AnimalTileSetImageGenerator.GetTile(0));
        }

        public override void Crier() {
            SoundPlayer Son = new SoundPlayer(TP2_Zoo.Properties.Resources.mouton_son);
            Son.Play();
        }


    }
}
