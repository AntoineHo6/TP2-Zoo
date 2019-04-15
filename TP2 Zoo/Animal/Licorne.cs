using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Zoo.Animal {
    class Licorne : Animal {

        public Licorne(int Position, String Type, String Genre, String Faim, String Age, bool Enceinte) : 
            base(Position, Type, Genre, Faim, Age, Enceinte) {
            Type = "Licorne";
            Genre = GenreAleatoire();
            Faim = "Nourri";
            this.Age = Age;
            Enceinte = false;
        }

        public override void Crier() {
            SoundPlayer Son = new SoundPlayer(TP2_Zoo.Properties.Resources.licorne);
            Son.Play();
        }
    }
}
