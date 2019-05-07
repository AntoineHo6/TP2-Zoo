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
        private bool EstAnimalClique;

        public UsrCtrlInfosAnimaux(FrmEtatJeu EtatJeu) {
            InitializeComponent();
            this.EtatJeu = EtatJeu;
        }

        public void InfosAnimalClick(String EnclosTypeAnimal, int Enclos, List<Animal> ListeAnimaux, int PositionX, int PositionY) {

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

            UpdateInfosAnimal(unAnimal);
            EstAnimalClique = true;
        }

        public void InfosTousAnimaux(String EnclosTypeAnimal, List<Animal> ListeAnimaux)
        {
            switch (EnclosTypeAnimal)
            {
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

            UpdateInfosTousAnimaux(ListeAnimaux);
        }

        public void UpdateInfosTousAnimaux(List<Animal> ListeAnimaux)
        {
            for (int i = 0; i < ListeAnimaux.Count; i++)
            {
                LblGenreAnimal.Text = TrouverGenreAnimal(ListeAnimaux.ElementAt(i));
                LblCroissanceAnimal.Text = TrouverCroissanceAnimal(ListeAnimaux.ElementAt(i));
                LblFaimAnimal.Text = TrouverFaimAnimal(ListeAnimaux.ElementAt(i));
                LblEnceinteAnimal.Text = TrouverEnceinteAnimal(ListeAnimaux.ElementAt(i));
            }
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

        private void UpdateInfosAnimal(Animal unAnimal) {
            LblGenreAnimal.Text = TrouverGenreAnimal(unAnimal);
            LblCroissanceAnimal.Text = TrouverCroissanceAnimal(unAnimal);
            LblFaimAnimal.Text = TrouverFaimAnimal(unAnimal);
            LblEnceinteAnimal.Text = TrouverEnceinteAnimal(unAnimal);
        }

        private void UsrCtrlInfosAnimaux_Paint(object sender, PaintEventArgs e)
        {
            if (EstAnimalClique)
            {
                BorderStyle = BorderStyle.None;
                ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Red, ButtonBorderStyle.Solid);
            }
        }
    }
}
