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

namespace TP2_Zoo {
    public partial class InfosAnimaux : UserControl {
        EtatJeu etatJeu;

        public InfosAnimaux(EtatJeu etatJeu) {
            InitializeComponent();
            this.etatJeu = etatJeu;
        }

        public void Setup(String enclosTypeAnimal) {

            switch (enclosTypeAnimal) {
                case "Mouton":
                    PctrBoxAnimal.BackgroundImage = Properties.Resources.Mouton;
                    LblNomAnimal.Text = "Mouton";
                    break;
                case "Lion":

                    break;
                case "Licorne":

                    break;
            }
        }
    }
}
