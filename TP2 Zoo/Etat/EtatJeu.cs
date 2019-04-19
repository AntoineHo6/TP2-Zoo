using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tileSetZoo;
using TP2_Zoo.Personne;


namespace TP2_Zoo.Etat {
    public partial class EtatJeu : UserControl {

        Hero hero;
        int nbrAnimaux;
        int nbrVisiteurs;
        List<Pepe> listePepe;

        public EtatJeu() {
            InitializeComponent();
            DoubleBuffered = true;

            hero = new Hero();
            nbrAnimaux = 0;
            listePepe = new List<Pepe>();
            
            // temp -----------
            //nbrVisiteurs = 0;
            nbrVisiteurs = 1;
            listePepe.Add(new Pepe("Bernard"));
            // -----------------

            // Testing purposes
            GerantCarte.PrintSolidMapping();
        }

        private void EtatJeu_Paint(object sender, PaintEventArgs e) {
            // temp
            //GerantCarte.PaintTileFloorMapping(e);

            GerantCarte.PeintureGazon(e);
            GerantCarte.PeintureCheminSable(e);
            GerantCarte.PeintureEnclos(e);
            GerantCarte.PeintureMaison(e);

            hero.Peinturer(e, 0);
            listePepe[0].Peinturer(e, 0);

            // FIN ; Cadrier toujours à la fin pour qu'il soit visible.
            GerantCarte.PeintureCadriage(e);
        }

        // Pour bouger le perso
        private void EtatJeu_KeyPress(object sender, KeyPressEventArgs e) {
            
        }

        private void Timer_Tick(object sender, EventArgs e) {
            listePepe[0].Deplacer();
            this.Refresh();
        }
    }
}
