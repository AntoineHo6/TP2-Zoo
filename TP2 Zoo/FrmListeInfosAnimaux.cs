using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP2_Zoo.Animaux;
using TP2_Zoo.Etat;

namespace TP2_Zoo {
    public partial class FrmListeInfosAnimaux : Form {
        FrmEtatJeu _etatJeu;
        UsrCtrlInfosAnimaux _usrCtrlInfosAnimaux;

        public FrmListeInfosAnimaux(FrmEtatJeu etatJeu, List<Animal> listeAnimaux) {
            InitializeComponent();
            this._etatJeu = etatJeu;
            AfficherInfosAnimaux(listeAnimaux);
        }

        /// <summary>
        ///     Méthode qui affiche une liste de tous les informations des animaux dans le jeu.
        /// </summary>
        /// <param name="listeAnimaux">La liste de tous les animaux</param>
        public void AfficherInfosAnimaux(List<Animal> listeAnimaux) {
            foreach (Animal animal in listeAnimaux) {
                _usrCtrlInfosAnimaux = new UsrCtrlInfosAnimaux(_etatJeu);
                _usrCtrlInfosAnimaux.InfosUserControl(animal);
                FlpListeInfosAnimaux.Controls.Add(_usrCtrlInfosAnimaux);
            }
        }
    }
}
