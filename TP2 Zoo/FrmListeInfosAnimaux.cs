using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP2_Zoo.Animaux;
using TP2_Zoo.Etat;

namespace TP2_Zoo
{
    public partial class FrmListeInfosAnimaux : Form
    {
        FrmEtatJeu etatJeu;
        UsrCtrlInfosAnimaux infosAnimaux;

        public FrmListeInfosAnimaux(FrmEtatJeu etatJeu, UsrCtrlInfosAnimaux infosAnimaux, List<Animal> listeAnimaux)
        {
            InitializeComponent();
            this.etatJeu = etatJeu;
            this.infosAnimaux = infosAnimaux;
            CreerInfosAnimaux(listeAnimaux);
        }

        public void CreerInfosAnimaux(List<Animal> listeAnimaux)
        {
            FlpListeInfosAnimaux.Controls.Add(infosAnimaux);
        }
    }
}
