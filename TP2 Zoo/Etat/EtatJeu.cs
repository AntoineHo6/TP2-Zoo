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
using TP2_Zoo.Animaux;

namespace TP2_Zoo.Etat {
    public partial class FrmEtatJeu : UserControl {
        static Random r = new Random();
        Zoo FormePrincipale;
        int NbrAnimaux;
        int NbrDechets;
        int SecondesJeu;

        public Heros heros;
        public Animal AnimalEnceinte;

        public List<Animal> ListeAnimaux;
        public ChoixAnimal ChoixAnimal;
        public UsrCtrlInfosAnimaux InfosAnimaux;

        List<Visiteur> listeVisiteurs;
        public UsrCtrlInfosVisiteurs InfosVisiteurs;

        public FrmEtatJeu(Zoo formPrincipale) {
            InitializeComponent();
            DoubleBuffered = true;

            NbrAnimaux = 0;
            NbrDechets = 0;
            SecondesJeu = 0;

            this.FormePrincipale = formPrincipale;
            heros = new Heros();
            ListeAnimaux = new List<Animal>();
            listeVisiteurs = new List<Visiteur>();
            InitChoixAnimal();
            InitInfosAnimaux();
            InitInfosVisiteurs();
        }

        /// <summary>
        ///     Prépare le user control qui permet de choisir le type d'animal à créer dans un nouvel enclos.
        /// </summary>
        private void InitChoixAnimal() {
            ChoixAnimal = new ChoixAnimal(this);
            ChoixAnimal.Location = new Point(345, 239);
            this.Controls.Add(ChoixAnimal);
            ChoixAnimal.Visible = false;
        }

        /// <summary>
        ///     Préparer le user control qui permet d'afficher les informations de tous les animaux présents dans le parc.
        /// </summary>
        private void InitInfosAnimaux() {
            InfosAnimaux = new UsrCtrlInfosAnimaux(this);
            InfosAnimaux.Location = new Point(345, 239);
            this.Controls.Add(InfosAnimaux);
            InfosAnimaux.Visible = false;
        }

        /// <summary>
        /// Préparer le User Control qui permet d'afficher les informations d'un visiteur sélectionné.
        /// </summary>
        private void InitInfosVisiteurs() {
            InfosVisiteurs = new UsrCtrlInfosVisiteurs(this);
            InfosVisiteurs.Location = new Point(345, 239);
            this.Controls.Add(InfosVisiteurs);
            InfosVisiteurs.Visible = false;
        }

        /// <summary>
        ///     Peinture la map, le hero et finalement les AIs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EtatJeu_Paint(object sender, PaintEventArgs e) {
            GerantCarte.PeintureMap(e);
            heros.Peinturer(e, heros.Touche);
            PeinturerAI(e);
        }


        /// <summary>
        ///     Peintures les AIs (les animaux et visiteurs).
        /// </summary>
        /// <param name="e"></param>
        private void PeinturerAI(PaintEventArgs e) {
            foreach (var animal in ListeAnimaux) {
                animal.Peinturer(e, 0);
            }
            foreach (var visiteur in listeVisiteurs) {
                visiteur.Peinturer(e, 0);
            }
        }


        /// <summary>
        ///     Permet de déplacer le heros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EtatJeu_KeyDown(object sender, KeyEventArgs e) {
            heros.Deplacer(e);
            this.Refresh();
        }


        /// <summary>
        ///     Gère les cliques de souris du joueur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EtatJeu_MouseClick(object sender, MouseEventArgs e) {
            Point p = this.PointToClient(Cursor.Position);
            int pX = p.X / 32;
            int pY = p.Y / 32;

            int enclos = GerantCarte.SurfaceEnclosMap[pX, pY];  // 0: pas dans un enclos.
            String enclosTypeAnimal = GerantCarte.AnimalEnclos[enclos];

            if (e.Button == MouseButtons.Left) {
                if (HerosAdjacent(pX, pY)) {

                    // Si clique dans un enclos sur une tuile vide
                    if (enclos != 0 && !GerantCarte.OccupeAiMap[pX, pY] && (pX != heros.Position[0] || pY != heros.Position[1])) {
                        // Si aucun animal dans l'enclos
                        if (enclosTypeAnimal == null) {
                            ChoixAnimal.Setup(heros.Argent, enclos, pX, pY);
                            ChoixAnimal.Visible = true;
                        }
                        else {
                            CreerAnimal(enclosTypeAnimal, enclos, pX, pY);
                        }
                    }
                    // Si clique sur un animal
                    else if (enclos != 0 && GerantCarte.OccupeAiMap[pX, pY]) {
                        if (heros.Argent >= 1) {
                            NourrirAnimal(pX, pY);
                        }
                    }
                    // si clique sur un dechet
                    else if (GerantCarte.PosDechetsMap[pX, pY]) {
                        GerantCarte.PosDechetsMap[pX, pY] = false;
                        DecNbrDechet();
                        Refresh();
                    }
                }
            }
            else if (e.Button == MouseButtons.Right) {
                // Si clique sur un animal
                if (enclos != 0 && GerantCarte.OccupeAiMap[pX, pY]) {
                    InfosAnimaux.Setup(enclosTypeAnimal, enclos, ListeAnimaux, pX, pY);
                    InfosAnimaux.Visible = true;
                }

                // Si je clique sur un visiteur
                else if (GerantCarte.OccupeAiMap[pX,pY]) 
                {
                    InfosVisiteurs.Setup(listeVisiteurs, pX, pY);
                    InfosVisiteurs.Visible = true;
                }
            }
        }


        /// <summary>
        ///     Créé un nouvel animal à une position précise.
        /// </summary>
        /// <param name="animal"> Le type d'animal à créé </param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void CreerAnimal(String animal, int enclos, int x, int y) {
            bool animalCree = false;

            switch (animal) {
                case "Mouton":
                    if (heros.Argent >= 20) {
                        DeduireArgentHeros(20);
                        ListeAnimaux.Add(new Mouton(true, enclos, x, y));
                        animalCree = true;
                    }
                    break;
                case "Lion":
                    if (heros.Argent >= 35) {
                        DeduireArgentHeros(35);
                        ListeAnimaux.Add(new Lion(true, enclos, x, y));
                        animalCree = true;
                    }
                    break;
                case "Licorne":
                    if (heros.Argent >= 50) {
                        DeduireArgentHeros(50);
                        ListeAnimaux.Add(new Licorne(true, enclos, x, y));
                        animalCree = true;
                    }
                    break;
            }

            if (animalCree) {
                CreerVisiteur();
                IncNbrAnimaux();
                Refresh();
            }
        }


        /// <summary>
        ///     Créé un nouveau visiteur de type aléatoire.
        /// </summary>
        void CreerVisiteur() {
            int typeVisiteur = r.Next(0, 4);

            switch (typeVisiteur) {
                case 0:
                    listeVisiteurs.Add(new Pepe());
                    break;
                case 1:
                    listeVisiteurs.Add(new Dame());
                    break;
                case 2:
                    listeVisiteurs.Add(new Fillette());
                    break;
                case 3:
                    listeVisiteurs.Add(new Monsieur());
                    break;
            }

            AjouterArgentHeros(2);
        }


        /// <summary>
        ///     Déduit de l'argent du héros.
        /// </summary>
        /// <param name="montant"> Le montant d'argent à déduire. </param>
        private void DeduireArgentHeros(double montant) {
            heros.Argent -= montant;
            FormePrincipale.LblArgent.Text = "Argent : " + heros.Argent + "$";
        }


        /// <summary>
        ///     Ajoute de l'argent au héros.
        /// </summary>
        /// <param name="montant"> Le montant d'argent à ajouter. </param>
        private void AjouterArgentHeros(double montant) {
            heros.Argent += montant;
            FormePrincipale.LblArgent.Text = "Argent : " + heros.Argent + "$";
        }


        /// <summary>
        ///     Vérifie si le héros est adjacent à la tuile cliquée.
        /// </summary>
        /// <param name="iX"> Coordonnée X de la tuile cliquée </param>
        /// <param name="iY"> Coordonnée Y de la tuile cliquée </param>
        /// <returns></returns>
        private bool HerosAdjacent(int iX, int iY) {
            bool heroAdjacent = false;

            // parcours les tuiles autour du héros.
            for (int y = -1; y < 2; y++) {
                for (int x = -1; x < 2; x++) {
                    if ((heros.Position[0] == iX + x) && (heros.Position[1] == iY + y)) {
                        heroAdjacent = true;
                    }
                }
            }
            return heroAdjacent;
        }


        /// <summary>
        ///     Incrémente la variable du nombre d'animaux.
        /// </summary>
        private void IncNbrAnimaux() {
            NbrAnimaux++;
            FormePrincipale.LblNbrAnimaux.Text = "Nombre d'animaux : " + NbrAnimaux;
        }


        /// <summary>
        ///     Nourri un animal. Coûte 1$ au héros.
        /// </summary>
        /// <param name="x"> La position X de l'animal </param>
        /// <param name="y"> La position Y de l'animal </param>
        private void NourrirAnimal(int x, int y) {
            foreach (var animal in ListeAnimaux) {
                if (animal.Position[0] == x && animal.Position[1] == y) {
                    DeduireArgentHeros(1);
                    animal.Manger();
                }
            }
        }

        private void AccoucherBebeAnimal(int enclos, Animal AnimalFeminin) {
            if (AnimalFeminin.Enceinte) {
                switch (AnimalFeminin.Type) {
                    case "Mouton":
                        AnimalFeminin.NbrJoursGestation = 150;
                        if (AnimalFeminin.NbrJoursGestation == 150) {
                            CreerBebe(enclos);
                        }
                        break;
                    case "Lion":
                        if (AnimalFeminin.NbrJoursGestation == 110) {
                            CreerBebe(enclos);
                        }
                        break;
                    case "Licorne":
                        if (AnimalFeminin.NbrJoursGestation == 360) {
                            CreerBebe(enclos);
                        }
                        break;
                }
            }
        }

        private void CreerBebe(int enclos) {
            String enclosTypeAnimal = GerantCarte.AnimalEnclos[enclos];

            int pX = PosAleatoireX(enclos);
            int pY = PosAleatoireY(enclos);

            if (enclos != 0 && !GerantCarte.OccupeAiMap[pX, pY] && (pX != heros.Position[0] || pY != heros.Position[1]) && AnimalEnceinte.Enceinte) {
                CreerAnimalBebe(enclosTypeAnimal, enclos, pX, pY);
            }
        }

        private void CreerAnimalBebe(string enclosTypeAnimal, int enclos, int pX, int pY) {
            bool animalCree = false;

            switch (enclosTypeAnimal) {
                case "Mouton":
                        ListeAnimaux.Add(new Mouton(false, enclos, pX, pY));
                        animalCree = true;
                    break;
                case "Lion":
                        ListeAnimaux.Add(new Lion(false, enclos, pX, pY));
                        animalCree = true;
                    break;
                case "Licorne":
                        ListeAnimaux.Add(new Licorne(false, enclos, pX, pY));
                        animalCree = true;
                    break;
            }

            if (animalCree) {
                CreerVisiteur();
                IncNbrAnimaux();
                Refresh();
            }
        }

        /// <summary>
        ///     Mets à jours tous les AIs et paie le joueur à chaque minute dépendamment du nombre d'animaux et de déchets.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e) {
            TickVisiteurs();
            TickAnimaux();
            TickAnimauxEnceinte();

            SecondesJeu++;

            if (SecondesJeu % 60 == 0) {
                AjouterArgentHeros(NbrAnimaux * NbrAnimaux); // chaque visiteur repaie 1$ pour chaque animal présent, et pour chaque animal, il y a un visiteur.
                DeduireArgentHeros(NbrDechets * 0.10);
            }

            this.Refresh();
        }
        

        /// <summary>
        ///     Mets à jour chaque visiteur et ils se déplacent.
        /// </summary>
        private void TickVisiteurs() {
            foreach (var visiteur in listeVisiteurs) {
                visiteur.NbrJours++;
                ChanceProduireDechet(visiteur);
                visiteur.Deplacer(heros.Position);
                visiteur.VerifierPeutQuit();

                // temp
                // a tester
                if (VisiteurPeuxTuQuitter(visiteur)) {
                    listeVisiteurs.Remove(visiteur);
                }
            }
        }


        /// <summary>
        ///     Vérifie si un visiteur peut quitter.
        /// </summary>
        /// <param name="visiteur"> Le visiteur a verifier. </param>
        /// <returns></returns>
        private bool VisiteurPeuxTuQuitter(Visiteur visiteur) {
            return visiteur.droitQuitter && ((visiteur.Position[0] == 19 || visiteur.Position[0] == 20) && visiteur.Position[1] == 25);
        }


        /// <summary>
        ///     Mets à jours tous les animaux et ils se déplacent.
        /// </summary>
        private void TickAnimaux() {
            foreach (var animal in ListeAnimaux) {
                animal.NbrJoursAdulte++;
                animal.JoursPasNourri++;

                if (animal.JoursPasNourri > 120) {
                    animal.JoursPasNourri = 0;
                    Contravention();
                }

                switch (animal.Type) {
                    case "Mouton":
                        if (animal.NbrJoursAdulte == 150) {
                            animal.EstAdulte = true;
                        }
                        break;
                    case "Lion":
                        if (animal.NbrJoursAdulte == 110) {
                            animal.EstAdulte = true;
                        }
                        break;
                    case "Licorne":
                        if (animal.NbrJoursAdulte == 360) {
                            animal.EstAdulte = true;
                        }
                        break;
                }

                animal.Deplacer(heros.Position);
            }
        }

        private void TickAnimauxEnceinte() {
            for (int i = 1; i < 5; i++) {
                switch (i) {
                    case 1:
                        VerifierAnimalEnceinte(1);
                        break;
                    case 2:
                        VerifierAnimalEnceinte(2);
                        break;
                    case 3:
                        VerifierAnimalEnceinte(3);
                        break;
                    case 4:
                        VerifierAnimalEnceinte(4);
                        break;
                }
            }
        }

        private void VerifierAnimalEnceinte(int enclos) {
            bool PresenceMasculin = TrouverPresenceM(enclos);
            bool PresenceFeminin = TrouverPresenceF(enclos);
            Animal AnimalFeminin = TrouverAnimalF(enclos);

            if (PresenceFeminin && PresenceMasculin) {
                ChanceAnimauxEnceinte(AnimalFeminin);
                AccoucherBebeAnimal(enclos, AnimalFeminin);
            }
        }

        private Animal TrouverAnimalF(int enclos) {
            foreach (var animal in ListeAnimaux) {
                if (animal.Genre == 1 && animal.Enclos == enclos && !animal.Enceinte) {
                    return AnimalEnceinte = animal;
                }
            }
            return AnimalEnceinte;
        }

        private bool TrouverPresenceF(int enclos) {
            bool PresenceFeminin = false;

            foreach (var animal in ListeAnimaux) {
                if (animal.Genre == 1 && animal.Enclos == enclos) {
                    return PresenceFeminin = true;
                }
            }
            return PresenceFeminin;
        }

        private bool TrouverPresenceM(int enclos) {
            bool PresenceMasculin = false;

            foreach (var animal in ListeAnimaux) {
                if (animal.Genre == 0 && animal.Enclos == enclos) {
                    return PresenceMasculin = true;
                }
            }
            return PresenceMasculin;
        }

        private void ChanceAnimauxEnceinte(Animal AnimalFeminin) {
            if (r.Next(100) < 99) {
                AnimalFeminin.Enceinte = true;
                AnimalFeminin.NbrJoursGestation++;
            } else {
                AnimalFeminin.Enceinte = false;
                AnimalFeminin.NbrJoursGestation = 0;
            }
        }

        private int PosAleatoireY(int enclos) {
            int Position = 0;
            switch (enclos) {
                case 1:
                    Position = r.Next(7, 11);
                    break;
                case 2:
                    Position = r.Next(7, 11);
                    break;
                case 3:
                    Position = r.Next(15, 19);
                    break;
                case 4:
                    Position = r.Next(15, 19);
                    break;
            }
            return Position;
        }

        private int PosAleatoireX(int enclos) {
            int Position = 0;
            switch (enclos) {
                case 1:
                    Position = r.Next(8, 18);
                    break;
                case 2:
                    Position = r.Next(22, 32);
                    break;
                case 3:
                    Position = r.Next(8, 18);
                    break;
                case 4:
                    Position = r.Next(22, 32);
                    break;
            }
            return Position;
        }

        /// <summary>
        ///     Le visiteur a 3% chance de laisser tomber un dechet.
        /// </summary>
        /// <param name="visiteur"> Le visiteur qui a la chance de faire tomber un dechet. </param>
        private void ChanceProduireDechet(Visiteur visiteur) {
            //                     |              pas de dechet sur un autre dechet.                    |
            if (r.Next(100) < 3 && !GerantCarte.PosDechetsMap[visiteur.Position[0], visiteur.Position[1]]) {
                visiteur.LaisserDechet();
                IncNbrDechet();
            }
        }

        /// <summary>
        ///     Incrémente le nombre de déchets.
        /// </summary>
        private void IncNbrDechet() {
            NbrDechets++;
            FormePrincipale.LblNbrDechets.Text = "Nombre de dechets : " + NbrDechets;
        }


        /// <summary>
        ///     Décremente le nombre de déchets.
        /// </summary>
        private void DecNbrDechet() {
            NbrDechets--;
            FormePrincipale.LblNbrDechets.Text = "Nombre de dechets : " + NbrDechets;
        }


        /// <summary>
        ///     Déduit 2$ du joueur.
        /// </summary>
        private void Contravention() {
            DeduireArgentHeros(2);
        }
    }
}
