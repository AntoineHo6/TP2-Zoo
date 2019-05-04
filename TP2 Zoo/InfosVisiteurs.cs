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
using TP2_Zoo.Personne;
using tileSetZoo;

namespace TP2_Zoo {
    public partial class UsrCtrlInfosVisiteurs : UserControl {
        FrmEtatJeu EtatJeu;
        private Visiteur VisiteurTemp;

        public UsrCtrlInfosVisiteurs(FrmEtatJeu EtatJeu) {
            InitializeComponent();
            this.EtatJeu = EtatJeu;
        }

        public void Setup(List<Visiteur> ListeVisiteurs, int PositionX, int PositionY) {

            Visiteur UnVisiteur = TrouverVisiteur(ListeVisiteurs, PositionX, PositionY);

            switch (UnVisiteur.Type) {
                case "Pépé":
                    PctrBoxVisiteur.BackgroundImage = HumainTileSetImageGenerator.GetTile(0);
                    LblNomVisiteur.Text = UnVisiteur.Nom;
                    LblSexeVisiteur.Text = TrouverSexeVisiteur(UnVisiteur);
                    LblDureeVisiteur.Text = UnVisiteur.NbrJours.ToString() + " jour(s)";
                    break;
                case "Monsieur":
                    PctrBoxVisiteur.BackgroundImage = HumainTileSetImageGenerator.GetTile(12);
                    LblNomVisiteur.Text = UnVisiteur.Nom;
                    LblSexeVisiteur.Text = TrouverSexeVisiteur(UnVisiteur);
                    LblDureeVisiteur.Text = UnVisiteur.NbrJours.ToString() + " jour(s)";
                    break;
                case "Fillette":
                    PctrBoxVisiteur.BackgroundImage = HumainTileSetImageGenerator.GetTile(8);
                    LblNomVisiteur.Text = UnVisiteur.Nom;
                    LblSexeVisiteur.Text = TrouverSexeVisiteur(UnVisiteur);
                    LblDureeVisiteur.Text = UnVisiteur.NbrJours.ToString() + " jour(s)";
                    break;
                case "Dame":
                    PctrBoxVisiteur.BackgroundImage = HumainTileSetImageGenerator.GetTile(4);
                    LblNomVisiteur.Text = UnVisiteur.Nom;
                    LblSexeVisiteur.Text = TrouverSexeVisiteur(UnVisiteur);
                    LblDureeVisiteur.Text = UnVisiteur.NbrJours.ToString() + " jour(s)";
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

        private string TrouverSexeVisiteur(Visiteur unVisiteur) {
            if (unVisiteur.Sexe == 0) {
                return "Masculin";
            } else {
                return "Féminin";
            }
        }
    }
}
