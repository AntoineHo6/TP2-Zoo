using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2_Zoo.Animaux {
    public abstract class Animal {

        static Random r = new Random();

        public int[] Position { get; set; }
        public String Type { get; set; }
        public int Genre { get; set; }   // 0: masculin; 1: feminin
        public bool EstEnceinte { get; set; }
        public int Prix { get; set; }
        public List<Bitmap> Sprites { get; set; }
        public int NbrJours { get; set; }
        public int NbrJoursGestation { get; set; }
        public int JoursPasNourri { get; set; }
        public bool EstAdulte { get; set; }
        public int Enclos { get; set; }

        public Animal(bool estAdulte, int enclos, params int[] position) {
            this.EstAdulte = estAdulte;
            NbrJours = 0;
            JoursPasNourri = 0;
            this.Position = position;
            Genre = r.Next(0, 2);
            EstEnceinte = false;
            Sprites = new List<Bitmap>();
            this.Enclos = enclos;
            Ai.Ai.OccuperTuile(position[0], position[1]);
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
