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
        public bool EstAnimalClique = false;

        public UsrCtrlInfosAnimaux(FrmEtatJeu EtatJeu) {
            InitializeComponent();
            this.EtatJeu = EtatJeu;
        }

        public void InfosTousAnimaux(Animal animal) {
            switch (animal.Type) {
                case "Mouton":
                    PctrBoxAnimal.BackgroundImage = Properties.Resources.Mouton;
                    LblTypeAnimal.Text = animal.Type.ToString();
                    break;
                case "Lion":
                    PctrBoxAnimal.BackgroundImage = Properties.Resources.Lion;
                    LblTypeAnimal.Text = animal.Type.ToString();
                    break;
                case "Licorne":
                    PctrBoxAnimal.BackgroundImage = Properties.Resources.Licorne;
                    LblTypeAnimal.Text = animal.Type.ToString();
                    break;
            }

        }

        public void InfosUserControl(Animal animal) {
            InfosTousAnimaux(animal);
            LblGenreAnimal.Text = TrouverGenreAnimal(animal);
            LblCroissanceAnimal.Text = TrouverCroissanceAnimal(animal);
            LblFaimAnimal.Text = TrouverFaimAnimal(animal);
            LblEnceinteAnimal.Text = TrouverEnceinteAnimal(animal);
        }

        private Animal TrouverAnimal(List<Animal> ListeAnimaux, int PostionX, int PositionY) {
            foreach (Animal animal in ListeAnimaux) {
                if (animal.Position[0] == PostionX && animal.Position[1] == PositionY) {
                    AnimalTemp = animal;
                    EstAnimalClique = true;
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

        private void UsrCtrlInfosAnimaux_Paint(object sender, PaintEventArgs e)
        {
            if (EstAnimalClique) {
                BorderStyle = BorderStyle.None;
                ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Red, ButtonBorderStyle.Solid);
            }
        }
    }
}
