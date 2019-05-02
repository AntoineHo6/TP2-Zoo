using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP2_Zoo.Etat;
using TP2_Zoo.Animaux;

namespace TP2_Zoo {
    public partial class InfosAnimaux : UserControl {
        EtatJeu etatJeu;
        public Animal animalTemp;

        public InfosAnimaux(EtatJeu etatJeu) {
            InitializeComponent();
            this.etatJeu = etatJeu;
        }

        public void Setup(String enclosTypeAnimal, List<Animal> listeAnimaux, int x, int y) {

            Animal animal = TrouverAnimal(listeAnimaux, x, y);

            Console.WriteLine("L'animal cliqué: " + animal);
           
            switch (enclosTypeAnimal) {
                case "Mouton":
                    PctrBoxAnimal.BackgroundImage = Properties.Resources.Mouton;
                    LblTypeAnimal.Text = "Mouton";
                    LblGenreAnimal.Text = TrouverGenreAnimal(animal);
                    LblCroissanceAnimal.Text = TrouverCroissanceAnimal(animal);
                    break;
                case "Lion":
                    PctrBoxAnimal.BackgroundImage = Properties.Resources.Lion;
                    LblTypeAnimal.Text = "Lion";
                    LblGenreAnimal.Text = TrouverGenreAnimal(animal);
                    LblCroissanceAnimal.Text = TrouverCroissanceAnimal(animal);
                    break;
                case "Licorne":
                    PctrBoxAnimal.BackgroundImage = Properties.Resources.Licorne;
                    LblTypeAnimal.Text = "Licorne";
                    LblGenreAnimal.Text = TrouverGenreAnimal(animal);
                    LblCroissanceAnimal.Text = TrouverCroissanceAnimal(animal);
                    break;
            }
        }

        private Animal TrouverAnimal(List<Animal> ListeAnimaux, int PostionX, int PositionY) {
            foreach (var animal in ListeAnimaux) {
                if (animal.Position[0] == PostionX && animal.Position[1] == PositionY) {
                    animalTemp = animal;
                }
            }
            return animalTemp;
        }

        private String TrouverGenreAnimal(Animal animal) {
            String GenreAnimal;

            if (animal.Genre.Equals("0")) {
                GenreAnimal = "Mâle";
            }
            else {
                GenreAnimal = "Femelle";
            }

            return GenreAnimal;
        }

        private String TrouverCroissanceAnimal(Animal animal) {
            String CroissanceAnimal;

            bool b = false;

            if (b) {
                CroissanceAnimal = "Adulte";
            }
            else {
                CroissanceAnimal = "Enfant";
            }

            return CroissanceAnimal;
        }

    }
}
