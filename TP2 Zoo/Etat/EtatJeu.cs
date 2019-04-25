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
using System.Threading;
using TP2_Zoo.Animal;

namespace TP2_Zoo.Etat {
    public partial class EtatJeu : UserControl {
        static Random r = new Random();
        Zoo formPrincipale;
        int nbrAnimaux;

        public Heros heros;
        public int touche;
        public List<Mouton> listeMouton;
        public List<Lion> listeLion;
        public List<Licorne> listeLicorne;
        public ChoixAnimal choixAnimal;

        List<Pepe> listePepe;
        List<Dame> listeDame;
        List<Fillette> listeFillette;

        public EtatJeu(Zoo formPrincipale) {
            InitializeComponent();
            DoubleBuffered = true;

            nbrAnimaux = 0;
            this.formPrincipale = formPrincipale;
            heros = new Heros();
            InitListeAI();
            InitChoixAnimal();

            Noms.Noms.LoadNames();
        }


        private void InitChoixAnimal() {
            choixAnimal = new ChoixAnimal(this);
            choixAnimal.Location = new Point(345, 239);
            this.Controls.Add(choixAnimal);
            choixAnimal.Visible = false;
        }


        private void InitListeAI() {
            listeMouton = new List<Mouton>();
            listeLion = new List<Lion>();
            listeLicorne = new List<Licorne>();

            listePepe = new List<Pepe>();
            listeDame = new List<Dame>();
            listeFillette = new List<Fillette>();
        }

        private void InitListeAnimaux() {
        }

        private void EtatJeu_Paint(object sender, PaintEventArgs e) {
            GerantCarte.PeintureMap(e);

            heros.Peinturer(e, touche);

            // Paint les animaux
            foreach (var mouton in listeMouton) {
                mouton.Peinturer(e, 0);
            }
            foreach (var lion in listeLion) {
                lion.Peinturer(e, 0);
            }
            foreach (var licorne in listeLicorne) {
                licorne.Peinturer(e, 0);
            }

            // Paint les visiteurs
            foreach (var pepe in listePepe) {
                pepe.Peinturer(e, 0);
            }

            foreach (var dame in listeDame) {
                dame.Peinturer(e, 0);
            }

            foreach (var fillette in listeFillette) {
                fillette.Peinturer(e, 0);
            }
        }


        /// <summary>
        ///     Permet de déplacer le heros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EtatJeu_KeyDown(object sender, KeyEventArgs e) {
            touche = heros.Deplacer(e);
            this.Refresh();
        }


        private void EtatJeu_MouseClick(object sender, MouseEventArgs e) {
            Point p = this.PointToClient(Cursor.Position);
            int pX = p.X / 32;
            int pY = p.Y / 32;

            if (e.Button == MouseButtons.Left) {
                if (HerosAdjacent(pX, pY)) {
                    int enclos = GerantCarte.SurfaceEnclosMap[pX, pY];  // 0: pas dans un enclos.
                    String enclosTypeAnimal = GerantCarte.animalEnclos[enclos];

                    // Si clique dans un enclos sur une tuile vide
                    if (enclos != 0 && !GerantCarte.OccupeAiMap[pX, pY] && (pX != heros.Position[0] || pY != heros.Position[1])) {
                        // Si aucun animal dans l'enclos
                        if (enclosTypeAnimal == null) {
                            choixAnimal.Setup(heros.Argent, enclos, pX, pY);
                            choixAnimal.Visible = true;
                        }
                        else {
                            CreerAnimal(enclosTypeAnimal, pX, pY);
                        }
                    }
                    // Si clique sur un animal
                    else if (enclos != 0 && GerantCarte.OccupeAiMap[pX, pY]) {
                        if (heros.Argent >= 1) {
                            NourrirAnimal(enclosTypeAnimal, pX, pY);
                        }
                    }
                }
            }
            else if (e.Button == MouseButtons.Right) {
                int enclos = GerantCarte.SurfaceEnclosMap[pX, pY];  // 0: pas dans un enclos.
                if (enclos != 0 && GerantCarte.OccupeAiMap[pX, pY]) {
                    Console.WriteLine("C'est un animal!");
                }
            }
        }

        public void CreerAnimal(String animal, int x, int y) {
            switch (animal) {
                case "Mouton":
                    if (heros.Argent >= 20) {
                        CreerMouton(x, y);
                    }
                    break;
                case "Lion":
                    if (heros.Argent >= 35) {
                        CreerLion(x, y);
                    }
                    break;
                case "Licorne":
                    if (heros.Argent >= 50) {
                        CreerLicorne(x, y);
                    }
                    break;
            }

            UpdateLblNbrAnimaux();

            // temp?
            CreerVisiteur(r.Next(0, 3));
        }

        public void CreerMouton(int x, int y) {
            DeduireArgentHero(20);
            listeMouton.Add(new Mouton(true, x, y));
            nbrAnimaux++;
            Refresh();
        }

        public void CreerLion(int x, int y) {
            DeduireArgentHero(35);
            listeLion.Add(new Lion(true, x, y));
            nbrAnimaux++;
            Refresh();
        }

        public void CreerLicorne(int x, int y) {
            DeduireArgentHero(50);
            listeLicorne.Add(new Licorne(true, x, y));
            nbrAnimaux++;
            Refresh();
        }


        void CreerVisiteur(int typeVisiteur) {
            switch(typeVisiteur) {
                case 0:
                    listePepe.Add(new Pepe());
                    break;
                case 1:
                    listeDame.Add(new Dame());
                    break;
                case 2:
                    listeFillette.Add(new Fillette());
                    break;
            }
        }


        public void DeduireArgentHero(int montant) {
            heros.Argent -= montant;
            formPrincipale.LblArgent.Text = "Argent : " + heros.Argent + "$";
        }

        /// <summary>
        ///     Verifie si le heros est adjacent à la tuile cliquée.
        /// </summary>
        /// <param name="iX"> Coordonnée X de la tuile cliquée </param>
        /// <param name="iY"> Coordonnée Y de la tuile cliquée </param>
        /// <returns></returns>
        private bool HerosAdjacent(int iX, int iY) {
            bool heroAdjacent = false;

            for (int y = -1; y < 2; y++) {
                for (int x = -1; x < 2; x++) {
                    if ((heros.Position[0] == iX + x) && (heros.Position[1] == iY + y)) {
                        heroAdjacent = true;
                    }
                }
            }
            return heroAdjacent;
        }


        void UpdateLblNbrAnimaux() {
            formPrincipale.LblNbrAnimaux.Text = "Nombre d'animaux : " + nbrAnimaux;
        }


        private void NourrirAnimal(String typeAnimal, int x, int y) {
            switch (typeAnimal) {
                case "Mouton":
                    foreach (var mouton in listeMouton) {
                        if (mouton.Position[0] == x && mouton.Position[1] == y) {
                            NourrirMouton(mouton);
                        }
                    }
                    break;
                case "Lion":
                    foreach (var lion in listeLion) {
                        if (lion.Position[0] == x && lion.Position[1] == y) {
                            NourrirLion(lion);
                        }
                    }
                    break;
                case "Licorne":
                    foreach (var licorne in listeLicorne) {
                        if (licorne.Position[0] == x && licorne.Position[1] == y) {
                            NourrirLicorne(licorne);
                        }
                    }
                    break;
            }
        }


        private void NourrirMouton(Mouton mouton) {
            DeduireArgentHero(1);
            mouton.Manger();
        }


        private void NourrirLion(Lion lion) {
            DeduireArgentHero(1);
            lion.Manger();
        }


        private void NourrirLicorne(Licorne licorne) {
            DeduireArgentHero(1);
            licorne.Manger();
        }


        private void Timer_Tick(object sender, EventArgs e) {
            // Tick les visiteurs
            foreach (var pepe in listePepe) {
                PepeTick(pepe);
            }
            foreach(var dame in listeDame) {
                DameTick(dame);
            }
            foreach (var fillette in listeFillette) {
                FilletteTick(fillette);
            }

            // Tick les animaux
            foreach (var mouton in listeMouton) {
                MoutonTick(mouton);
            }
            foreach (var lion in listeLion) {
                LionTick(lion);
            }
            foreach (var licorne in listeLicorne) {
                LicorneTick(licorne);
            }

            this.Refresh();
        }


        private void PepeTick(Pepe pepe) {
            pepe.NbrJours++;
            pepe.Deplacer(heros.Position);

            if (pepe.NbrJours > 60) {
                pepe.PeutQuitter = true;
            }
        }

        private void DameTick(Dame dame) {
            dame.NbrJours++;
            dame.Deplacer(heros.Position);

            if (dame.NbrJours > 60) {
                dame.PeutQuitter = true;
            }
        }

        private void FilletteTick(Fillette fillette) {
            fillette.NbrJours++;
            fillette.Deplacer(heros.Position);

            if (fillette.NbrJours > 60) {
                fillette.PeutQuitter = true;
            }
        }


        private void MoutonTick(Mouton mouton) {
            mouton.NbrJours++;
            mouton.JoursPasNourri++;

            if (mouton.JoursPasNourri > 120) {
                mouton.Faim = false;
                Contravention();
            }

            mouton.Deplacer(heros.Position);
        }


        private void LionTick(Lion lion) {
            lion.NbrJours++;
            lion.JoursPasNourri++;

            if (lion.JoursPasNourri > 120) {
                lion.Faim = false;
                Contravention();
            }

            lion.Deplacer(heros.Position);
        }


        private void LicorneTick(Licorne licorne) {
            licorne.NbrJours++;
            licorne.JoursPasNourri++;

            if (licorne.JoursPasNourri > 180) {
                licorne.Faim = false;
                Contravention();
            }

            licorne.Deplacer(heros.Position);
        }

        private void Contravention() {
            DeduireArgentHero(2);
        }
    }
}
