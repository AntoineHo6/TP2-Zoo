﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tileSetZoo;

namespace TP2_Zoo {
    public partial class Zoo : Form {
        
        enum Mois { Janvier=1, Fevrier, Mars, Avril, Mai, Juin, Juillet, Aout,
        Septembre, Octobre, Novembre, Decembre };
        
        DateTime dateNow;

        public Zoo() {
            InitializeComponent();
            
            dateNow = DateTime.Now;
            LblDate.Text = "Date : " + dateNow.Day + "  " + (Mois)dateNow.Month + "  " + dateNow.Year;
        }

        private void Timer1_Tick(object sender, EventArgs e) {
            dateNow = dateNow.AddDays(1);
            LblDate.Text = "Date : " + dateNow.Day + "  " + (Mois)dateNow.Month + "  " + dateNow.Year;
        }

        private void Zoo_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                etatJeu.choixAnimal.Visible = false;
                etatJeu.Focus();
            }
        }
    }
}
