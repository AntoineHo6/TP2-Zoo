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
        public bool Faim { get; set; } // True: Faim ; False: Pas faim
        public bool Enceinte { get; set; }
        public int Prix { get; set; }
        public List<Bitmap> Sprites { get; set; }
        public int NbrJours { get; set; }
        public int JoursPasNourri { get; set; }
        public bool EstAdulte { get; set; } // True : Adulte

        public Animal(bool EstAdulte, params int[] Position) {
            this.EstAdulte = EstAdulte;
            NbrJours = 0;
            JoursPasNourri = 0;
            this.Position = Position;
            Genre = r.Next(0, 2);
            Faim = false;
            Enceinte = false;
            Sprites = new List<Bitmap>();
            Ai.Ai.OccuperTuile(Position[0], Position[1]);
        }

        public void Deplacer(int[] positionHero) {
            Ai.Ai.ChoixDirectionAleatoire(Position, positionHero);
        }

        public void Manger() {
            JoursPasNourri = 0;
            Crier();
        }

        public void Peinturer(PaintEventArgs e, int index) {
            e.Graphics.DrawImage(Sprites[index], Position[0] * 32, Position[1] * 32);
        }

        abstract public void Crier();
    }
}
