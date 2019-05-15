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

        public UsrCtrlInfosAnimaux(FrmEtatJeu etatJeu) {
            InitializeComponent();
            this.EtatJeu = etatJeu;
        }

        /// <summary>
        ///     Méthode qui affiche l'image et le nom de l'animal.
        /// </summary>
        /// <param name="animal"></param>
        public void InfoAnimal(Animal animal) {
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

        /// <summary>
        ///     Méthode qui affiche les informations de l'animal.
        /// </summary>
        /// <param name="animal"></param>
        public void InfosUserControl(Animal animal) {
            InfoAnimal(animal);
            LblGenreAnimal.Text = TrouverGenreAnimal(animal);
            LblCroissanceAnimal.Text = TrouverCroissanceAnimal(animal);
            LblFaimAnimal.Text = TrouverFaimAnimal(animal);
            LblEnceinteAnimal.Text = TrouverEnceinteAnimal(animal);
        }

        /// <summary>
        ///     Méthode qui retourne le genre de l'animal donné.
        /// </summary>
        /// <param name="unAnimal"></param>
        /// <returns></returns>
        private String TrouverGenreAnimal(Animal unAnimal) {
            if (unAnimal.Genre == 0) {
                return "Masculin";
            }
            else {
                return "Féminin";
            }
        }

        /// <summary>
        ///     Méthode qui retourne l'état de la croissance d'un animal donné.
        /// </summary>
        /// <param name="unAnimal"></param>
        /// <returns></returns>
        private String TrouverCroissanceAnimal(Animal unAnimal) {
            if (unAnimal.EstAdulte) {
                return "Adulte";
            }
            else {
                return "Enfant";
            }
        }

        /// <summary>
        ///     Méthode qui retourne l'état de la faim d'un animal donné.
        /// </summary>
        /// <param name="unAnimal"></param>
        /// <returns></returns>
        private string TrouverFaimAnimal(Animal unAnimal) {
            if (unAnimal.JoursPasNourri > 0) {
                return "Oui";
            }
            else {
                return "Non";
            }
        }

        /// <summary>
        ///     Méthode qui retourne l'état de grossesse d'un animal donné.
        /// </summary>
        /// <param name="unAnimal"></param>
        /// <returns></returns>
        private string TrouverEnceinteAnimal(Animal unAnimal) {
            if (unAnimal.Genre == 0) {
                return "Non";
            }
            else {
                if (unAnimal.EstEnceinte) {
                    return "Oui";
                }
                else {
                    return "Non";
                }
            }
        }
    }
}
