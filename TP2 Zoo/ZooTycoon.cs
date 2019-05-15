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

namespace TP2_Zoo {
    public partial class Zoo : Form {
        
        enum Mois { Janvier=1, Fevrier, Mars, Avril, Mai, Juin, Juillet, Aout,
        Septembre, Octobre, Novembre, Decembre };
        
        DateTime _dateNow;
        FrmEtatJeu _etatJeu;
        FrmQuitter _quitter;

        public Zoo() {
            InitializeComponent();
            InitEtatJeu();
            InitFrmQuitter();

            _dateNow = DateTime.Now;
            LblDate.Text = " " + _dateNow.Day + "  " + (Mois)_dateNow.Month + "  " + _dateNow.Year;

            Noms.Noms.LoadNames();
            this.ControlBox = false;    // Cacher le bouton Cancel
        }

        /// <summary>
        ///     Méthode qui instancie la form du jeu.
        /// </summary>
        private void InitEtatJeu() {
            _etatJeu = new FrmEtatJeu(this);
            _etatJeu.Location = new Point(0, 112);
            this.Controls.Add(_etatJeu);
        }

        /// <summary>
        ///     Méthode qui initialise la form Quitter.
        /// </summary>
        private void InitFrmQuitter() {
            _quitter = new FrmQuitter(_etatJeu);
            _quitter.Visible = false;
        }

        /// <summary>
        ///     Méthode qui affiche la date.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e) {
            _dateNow = _dateNow.AddDays(1);
            LblDate.Text = " " + _dateNow.Day + "  " + (Mois)_dateNow.Month + "  " + _dateNow.Year;
        }

        /// <summary>
        ///     Méthode qui gère le clique de l'escape pour fermer les User Control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Zoo_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                _etatJeu.ChoixAnimal.Visible = false;
                _etatJeu.InfosVisiteurs.Visible = false;
                _etatJeu.Focus();
            }
        }

        /// <summary>
        ///     Bouton qui permet de faire quitter le jeu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemQuitter_Click(object sender, EventArgs e) {
            _quitter.AfficherProfitTotal();
            _quitter.Visible = true;
        }

        /// <summary>
        ///     Bouton pour faire engager un concierge.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EngagerConcierge_Click(object sender, EventArgs e) {
            _etatJeu.CreerConcierge();
            _etatJeu.Focus();
        }
    }
}
