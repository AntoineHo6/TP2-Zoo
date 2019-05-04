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
    public partial class UsrCtrlInfosAnimaux : UserControl {
        FrmEtatJeu EtatJeu;
        private Animal AnimalTemp;

        public UsrCtrlInfosAnimaux(FrmEtatJeu EtatJeu) {
            InitializeComponent();
            this.EtatJeu = EtatJeu;
        }

        public void Setup(String EnclosTypeAnimal, int Enclos, List<Animal> ListeAnimaux, int PositionX, int PositionY) {

            Animal unAnimal = TrouverAnimal(ListeAnimaux, PositionX, PositionY);
           
            switch (EnclosTypeAnimal) {
                case "Mouton":
                    PctrBoxAnimal.BackgroundImage = Properties.Resources.Mouton;
                    LblTypeAnimal.Text = EnclosTypeAnimal;
                    break;
                case "Lion":
                    PctrBoxAnimal.BackgroundImage = Properties.Resources.Lion;
                    LblTypeAnimal.Text = EnclosTypeAnimal;
                    break;
                case "Licorne":
                    PctrBoxAnimal.BackgroundImage = Properties.Resources.Licorne;
                    LblTypeAnimal.Text = EnclosTypeAnimal;
                    break;
            }

            UpdateInfoAnimal(unAnimal);
        }

        private Animal TrouverAnimal(List<Animal> ListeAnimaux, int PostionX, int PositionY) {
            foreach (var Animal in ListeAnimaux) {
                if (Animal.Position[0] == PostionX && Animal.Position[1] == PositionY) {
                    AnimalTemp = Animal;
                }
            }
            return AnimalTemp;
        }

        private String TrouverGenreAnimal(Animal unAnimal) {
            if (unAnimal.Genre == 0) {
                return "Masculin";
            }
            else {
                return "Féminin";
            }
        }

        private String TrouverCroissanceAnimal(Animal unAnimal) {
            if (unAnimal.EstAdulte) {
                return "Adulte";
            }
            else {
                return "Enfant";
            }
        }

        private string TrouverFaimAnimal(Animal unAnimal) {
            if (unAnimal.JoursPasNourri > 0) {
                return "Oui";
            }
            else {
                return "Non";
            }
        }

        private string TrouverEnceinteAnimal(Animal unAnimal) {
            if (unAnimal.Genre == 0) {
                return "Non";
            }
            else {
                if (unAnimal.Enceinte) {
                    return "Oui";
                }
                else {
                    return "Non";
                }
            }
        }

        private void UpdateInfoAnimal(Animal unAnimal) {
            LblGenreAnimal.Text = TrouverGenreAnimal(unAnimal);
            LblCroissanceAnimal.Text = TrouverCroissanceAnimal(unAnimal);
            LblFaimAnimal.Text = TrouverFaimAnimal(unAnimal);
            LblEnceinteAnimal.Text = TrouverEnceinteAnimal(unAnimal);
        }
    }
}
