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
        private Visiteur _visiteurTemp;

        public UsrCtrlInfosVisiteurs(FrmEtatJeu etatJeu) {
            InitializeComponent();
            this.EtatJeu = etatJeu;
        }

        /// <summary>
        ///     Méthode qui permet de  les informations du visiteur cliqué.
        /// </summary>
        /// <param name="listeVisiteurs">La liste de tous les visiteurs</param>
        /// <param name="pX">La position X du visiteur cliqué</param>
        /// <param name="pY">La position Y du visiteur cliqué</param>
        public void Setup(List<Visiteur> listeVisiteurs, int pX, int pY) {

            Visiteur UnVisiteur = TrouverVisiteur(listeVisiteurs, pX, pY);

            switch (UnVisiteur.Type) {
                case "Pépé":
                    PctrBoxVisiteur.BackgroundImage = HumainTileSetImageGenerator.GetTile(0);
                    break;
                case "Monsieur":
                    PctrBoxVisiteur.BackgroundImage = HumainTileSetImageGenerator.GetTile(12);
                    break;
                case "Fillette":
                    PctrBoxVisiteur.BackgroundImage = HumainTileSetImageGenerator.GetTile(8);
                    break;
                case "Dame":
                    PctrBoxVisiteur.BackgroundImage = HumainTileSetImageGenerator.GetTile(4);
                    break;
            }

            UpdateInfoVisiteur(UnVisiteur);
        }

        /// <summary>
        ///     Méthode qui met à jour l'affichage des informations du visiteur cliqué.
        /// </summary>
        /// <param name="unVisiteur">Le visiteur cliqué</param>
        private void UpdateInfoVisiteur(Visiteur unVisiteur) {
            LblNomVisiteur.Text = unVisiteur.Nom;
            LblSexeVisiteur.Text = TrouverSexeVisiteur(unVisiteur);
            LblDureeVisiteur.Text = unVisiteur.NbrJours.ToString() + " jour(s)";
        }

        /// <summary>
        ///     Méthode qui trouve le visiteur cliqué. Elle retourne le visiteur.
        /// </summary>
        /// <param name="listeVisiteurs">La liste de tous les visiteurs</param>
        /// <param name="pX">La position X du visiteur cliqué</param>
        /// <param name="pY">La position Y du visiteur cliqué</param>
        /// <returns></returns>
        private Visiteur TrouverVisiteur(List<Visiteur> listeVisiteurs, int pX, int pY) {
            foreach (var Visiteur in listeVisiteurs) {
                if (Visiteur.Position[0] == pX && Visiteur.Position[1] == pY) {
                    _visiteurTemp = Visiteur;
                }
            }
            return _visiteurTemp;
        }

        /// <summary>
        ///     Méthode pour identifier le sexe du visiteur cliqué. Elle retourne le 
        ///     sexe du visiteur.
        /// </summary>
        /// <param name="unVisiteur">Le visiteur cliqué</param>
        /// <returns></returns>
        private string TrouverSexeVisiteur(Visiteur unVisiteur) {
            if (unVisiteur.Sexe == 0) {
                return "Masculin";
            } 
            return "Féminin";
        }
    }
}
