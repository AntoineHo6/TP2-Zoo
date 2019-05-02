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

        public void Setup(String enclosTypeAnimal, int Enclos, List<Animal> ListeAnimaux, int x, int y) {

            Animal animal = TrouverAnimal(ListeAnimaux, x, y);
           
            switch (enclosTypeAnimal) {
                case "Mouton":
                    PctrBoxAnimal.BackgroundImage = Properties.Resources.Mouton;
                    LblTypeAnimal.Text = "Mouton";
                    LblGenreAnimal.Text = TrouverGenreAnimal(animal);
                    LblCroissanceAnimal.Text = TrouverCroissanceAnimal(animal);
                    LblFaimAnimal.Text = TrouverFaimAnimal(animal);
                    LblEnceinteAnimal.Text = TrouverEnceinteAnimal(animal);
                    break;
                case "Lion":
                    PctrBoxAnimal.BackgroundImage = Properties.Resources.Lion;
                    LblTypeAnimal.Text = "Lion";
                    LblGenreAnimal.Text = TrouverGenreAnimal(animal);
                    LblCroissanceAnimal.Text = TrouverCroissanceAnimal(animal);
                    LblEnceinteAnimal.Text = TrouverEnceinteAnimal(animal);
                    break;
                case "Licorne":
                    PctrBoxAnimal.BackgroundImage = Properties.Resources.Licorne;
                    LblTypeAnimal.Text = "Licorne";
                    LblGenreAnimal.Text = TrouverGenreAnimal(animal);
                    LblCroissanceAnimal.Text = TrouverCroissanceAnimal(animal);
                    LblEnceinteAnimal.Text = TrouverEnceinteAnimal(animal);
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
            if (animal.Genre == 0) {
                return "Mâle";
            }
            else {
                return "Femelle";
            }
        }

        private String TrouverCroissanceAnimal(Animal animal) {
            if (animal.EstAdulte) {
                return "Adulte";
            }
            else {
                return "Enfant";
            }
        }

        private string TrouverFaimAnimal(Animal animal) {
            if (animal.JoursPasNourri > 0) {
                return "Oui";
            }
            else {
                return "Non";
            }
        }

        private string TrouverEnceinteAnimal(Animal animal) {
            if (animal.Genre == 0) {
                return "Non";
            }
            else {
                if (animal.Enceinte) {
                    return "Oui";
                }
                else {
                    return "Non";
                }
            }
        }
    }
}
