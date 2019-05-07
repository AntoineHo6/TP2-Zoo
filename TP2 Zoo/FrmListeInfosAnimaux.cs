using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP2_Zoo.Etat;

namespace TP2_Zoo
{
    public partial class FrmListeInfosAnimaux : Form
    {
        FrmEtatJeu etatJeu;

        public FrmListeInfosAnimaux(FrmEtatJeu etatJeu)
        {
            InitializeComponent();
            this.etatJeu = etatJeu;
        }
    }
}
