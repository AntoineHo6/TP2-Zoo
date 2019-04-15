using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Zoo.Animal {
    class Licorne : Animal {

        public Licorne(int Position, String Type, String Genre, String Faim, String Age, bool Enceinte) : 
            base(Position, Type, Genre, Faim, Age, Enceinte) {

        }

        public override void Crier() {
            
        }
    }
}
