using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Zoo.Animal {
    public abstract class Animal {

        static Random r = new Random();

        public int[] Position { get; set; }
        public String Type { get; set; }
        public int Genre { get; set; }   // 0: male; 1: femelle
        public bool Faim { get; set; }
        public bool Enceinte { get; set; }
        public int Prix { get; set; }
        public List<Bitmap> Sprites { get; set; }

        public Animal(params int[] Position) {
            this.Position = Position;
            this.Genre = r.Next(0, 2);
            Faim = false;
            Enceinte = false;
        }

        public void Deplacer() {

        }

        public void Manger() {

        }

        abstract public void Crier();
    }
}
