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

        enum Jour { Janvier=1, Fevrier, Mars, Avril, Mai, Juin, Juillet, Aout,
        Septembre, Octobre, Novembre, Decembre };
        public Zoo() {
            InitializeComponent();
        }

        private void Zoo_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar.Equals(Keys.W)) {
                MessageBox.Show("Tu as cliqué sur W!");
            }
            else if (e.KeyChar.Equals(Keys.A)) {

            }
            else if (e.KeyChar.Equals(Keys.S)) {

            }
            else if (e.KeyChar.Equals(Keys.D)) {

            }
        }
    }
}
