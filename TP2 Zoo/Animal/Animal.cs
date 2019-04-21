using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public int Jours { get; set; }

    public Animal(params int[] Position) {
            this.Jours = 0;
            this.Position = Position;
            this.Genre = r.Next(0, 2);
            Faim = false;
            Enceinte = false;
            Sprites = new List<Bitmap>();
            Ai.Ai.OccuperTuile(Position[0], Position[1]);
        }

        public void Deplacer(int[] positionHero) {
            Ai.Ai.ChoisirDirection(Position, positionHero);
        }

        public void Manger() {

        }

        public void Peinturer(PaintEventArgs e, int index) {
            e.Graphics.DrawImage(Sprites[index], Position[0] * 32, Position[1] * 32);
        }

        abstract public void Crier();
    }
}
