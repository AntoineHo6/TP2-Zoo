﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP2_Zoo.Etat;

namespace TP2_Zoo {
    public partial class FrmQuitter : Form {
        FrmEtatJeu _etatJeu;

        public FrmQuitter(FrmEtatJeu etatJeu) {
            InitializeComponent();
            this._etatJeu = etatJeu;
        }

        /// <summary>
        ///     Méthode qui affiche le profit total du joueur.
        /// </summary>
        public void AfficherProfitTotal() {
            LblMontantTotal.Text = _etatJeu.Heros.Profit.ToString() + "$";
        }

        /// <summary>
        ///     Méthode qui gère la fin du jeu. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmQuitter_FormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
        }
    }
}
