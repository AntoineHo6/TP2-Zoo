using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Zoo.Animal {
    public abstract class Animal {

        static Random r = new Random();

        public int[] Position { get; set; }
        public String Type { get; set; }
        public String Genre { get; set; }
        public String Faim { get; set; }
        public String Age { get; set; }
        public bool Enceinte { get; set; }
        public int Prix { get; set; }

        public Animal(int Prix, String Type, String Genre, String Faim, String Age, bool Enceinte, params int[] Position) {
            this.Position = Position;
            this.Type = Type;
            this.Genre = Genre;
            this.Faim = Faim;
            this.Age = Age;
            this.Enceinte = Enceinte;
        }

        public void Deplacer() {

        }
        public void Manger() {

        }

        abstract public void Crier();

        public String GenreAleatoire() {
            int nombre = r.Next(0, 2);
            String genre;

            if (nombre == 0) {
                genre = "Male";
            }
            else {
                genre = "Femelle";
            }

            return genre;
        }
    }
}
