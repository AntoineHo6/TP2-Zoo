﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Zoo.Animal {
    public class Mouton : Animal {
        
        public Mouton(params int[] Position) : base(Position) {
            Prix = 20;
            Type = "Mouton";
        }

        public override void Crier() {
            SoundPlayer Son = new SoundPlayer(TP2_Zoo.Properties.Resources.mouton);
            Son.Play();
        }


    }
}
