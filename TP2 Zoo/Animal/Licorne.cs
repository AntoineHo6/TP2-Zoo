using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using tileSetZoo;

namespace TP2_Zoo.Animal {
    public class Licorne : Animal {

        public Licorne(bool EstAdulte, params int[] Position) : base(EstAdulte, Position) {
            Prix = 50;
            Type = "Licorne";

            Sprites.Add(AnimalTileSetImageGenerator.GetTile(0));
        }

        public override void Crier() {
            SoundPlayer Son = new SoundPlayer(TP2_Zoo.Properties.Resources.licorne);
            Son.Play();
        }
    }
}
