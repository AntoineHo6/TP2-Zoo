using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Zoo.Animal {
    public class Lion : Animal {

        public Lion(int Prix, String Type, String Genre, String Faim, String Age, bool Enceinte, params int[] Position) :
            base(Prix, Type, Genre, Faim, Age, Enceinte, Position) {
            this.Position = Position;
            Prix = 35;
            Type = "Lion";
            Genre = GenreAleatoire();
            Faim = "Nourri";
            this.Age = Age;
            Enceinte = false;
        }
        public override void Crier() {
            SoundPlayer Son = new SoundPlayer(TP2_Zoo.Properties.Resources.lion);
            Son.Play();
        }

        
    }
}
