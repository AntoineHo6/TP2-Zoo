using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tileSetZoo;
using TP2_Zoo.Etat;
using TP2_Zoo.Personne;

namespace TP2_Zoo {
    public partial class FrmInfosVisiteurs : UserControl {

        FrmEtatJeu EtatJeu;
        private Visiteur VisiteurTemp;

        public FrmInfosVisiteurs(FrmEtatJeu EtatJeu) {
            InitializeComponent();
            this.EtatJeu = EtatJeu;
        }

        public void Setup(List<Visiteur> ListeVisiteurs, int PositionX, int PositionY) {

            Visiteur unVisiteur = TrouverVisiteur(ListeVisiteurs, PositionX, PositionY);

            switch (unVisiteur.Type) {
                case "Pépé":
                    LblNomVisiteur.Text = "Pépé";
                    break;
                case "Monsieur":

                    break;
                case "Fillette":
                    LblNomVisiteur.Text = "Fillette";
                    break;
                case "Dame":
                    break;
            }
        }

        private Visiteur TrouverVisiteur(List<Visiteur> ListeVisiteurs, int PositionX, int PositionY) {
            foreach (var Visiteur in ListeVisiteurs) {
                if (Visiteur.Position[0] == PositionX && Visiteur.Position[1] == PositionY) {
                    VisiteurTemp = Visiteur;
                }
            }
            return VisiteurTemp;
        }
    }
}
