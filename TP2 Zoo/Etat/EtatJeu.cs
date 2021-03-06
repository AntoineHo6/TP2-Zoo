﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TP2_Zoo.Animaux;
using TP2_Zoo.Personne;

/// <summary>
///     Auteurs : Antoine Ho et Kevin Li.
///     
///     Hiver 2019.
/// 
///     Date de remise: Le mardi 14 mai 2019.
/// </summary>

namespace TP2_Zoo.Etat {
    public partial class FrmEtatJeu : UserControl {
        static Random r = new Random();
        Zoo FormePrincipale;
        int _nbrAnimaux;
        int _nbrDechets;
        int _secondesJeu;

        public Heros Heros;
        public Animal AnimalEnceinte;

        public List<Animal> ListeAnimaux;
        List<Visiteur> ListeVisiteurs;
        List<Concierge> ListeConcierges;

        public ChoixAnimal ChoixAnimal;
        public UsrCtrlInfosAnimaux InfosAnimaux;
        public FrmListeInfosAnimaux ListeInfosAnimaux;

        public UsrCtrlInfosVisiteurs InfosVisiteurs;

        public FrmEtatJeu(Zoo formPrincipale) {
            InitializeComponent();
            DoubleBuffered = true;

            _nbrAnimaux = 0;
            _nbrDechets = 0;
            _secondesJeu = 0;

            this.FormePrincipale = formPrincipale;
            Heros = new Heros();
            ListeAnimaux = new List<Animal>();
            ListeVisiteurs = new List<Visiteur>();
            ListeConcierges = new List<Concierge>();
            InitChoixAnimal();
            InitInfosVisiteurs();
        }

        /// <summary>
        ///     Prépare le user control qui permet de choisir le type d'animal à créer dans un nouvel enclos.
        /// </summary>
        private void InitChoixAnimal() {
            ChoixAnimal = new ChoixAnimal(this);
            ChoixAnimal.Location = new Point(345, 239);
            ChoixAnimal.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(ChoixAnimal);
            ChoixAnimal.Visible = false;
        }

        /// <summary>
        ///     Prépare le User Control qui permet d'afficher les informations d'un visiteur sélectionné.
        /// </summary>
        private void InitInfosVisiteurs() {
            InfosVisiteurs = new UsrCtrlInfosVisiteurs(this);
            InfosVisiteurs.Location = new Point(510, 239);
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
            Heros.Peinturer(e, Heros.Sprite);
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
            foreach (var visiteur in ListeVisiteurs) {
                visiteur.Peinturer(e, 0);
            }
            foreach (var concierge in ListeConcierges) {
                concierge.Peinturer(e, 0);
            }
        }


        /// <summary>
        ///     Permet de déplacer le héros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EtatJeu_KeyDown(object sender, KeyEventArgs e) {
            Heros.Deplacer(e);
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
                    if (enclos != 0 && !GerantCarte.PosAiMap[pX, pY] && (pX != Heros.Position[0] || pY != Heros.Position[1])) {
                        // Si aucun animal dans l'enclos
                        if (enclosTypeAnimal == null) {
                            ChoixAnimal.Setup(Heros.Argent, enclos, pX, pY);
                            ChoixAnimal.Visible = true;
                        }
                        else {
                            CreerAnimal(enclosTypeAnimal, enclos, pX, pY);
                        }
                    }
                    // Si clique sur un animal
                    else if (enclos != 0 && GerantCarte.PosAiMap[pX, pY]) {
                        if (Heros.Argent >= 1) {
                            NourrirAnimal(pX, pY);
                        }
                    }
                    // si clique sur un déchet

                    else if (GerantCarte.PosDechetsMap[pX, pY]) {
                        GerantCarte.PosDechetsMap[pX, pY] = false;
                        DecNbrDechet(1);
                        Refresh();
                    }
                }
            }
            else if (e.Button == MouseButtons.Right) {
                // Si clique sur un animal
                if (enclos != 0 && GerantCarte.PosAiMap[pX, pY]) {
                    ListeInfosAnimaux = new FrmListeInfosAnimaux(this, ListeAnimaux);
                    ListeInfosAnimaux.Show();
                }

                // Si je clique sur un visiteur
                else if (GerantCarte.PosAiMap[pX, pY]) {
                    InfosVisiteurs.Setup(ListeVisiteurs, pX, pY);
                    InfosVisiteurs.Visible = true;
                }
            }
        }


        /// <summary>
        ///     Crée un nouvel animal à une position précise.
        /// </summary>
        /// <param name="animal">Le type d'animal à créer</param>
        /// <param name="x">La position X du clique</param>
        /// <param name="y">La position Y du clique</param>
        public void CreerAnimal(String animal, int enclos, int x, int y) {
            bool animalCree = false;

            switch (animal) {
                case "Mouton":
                    if (Heros.Argent >= 20) {
                        DeduireArgentHeros(20);
                        ListeAnimaux.Add(new Mouton(true, enclos, x, y));
                        animalCree = true;
                    }
                    break;
                case "Lion":
                    if (Heros.Argent >= 35) {
                        DeduireArgentHeros(35);
                        ListeAnimaux.Add(new Lion(true, enclos, x, y));
                        animalCree = true;
                    }
                    break;
                case "Licorne":
                    if (Heros.Argent >= 50) {
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
        private void CreerVisiteur() {
            int typeVisiteur = r.Next(0, 4);

            switch (typeVisiteur) {
                case 0:
                    ListeVisiteurs.Add(new Pepe());
                    break;
                case 1:
                    ListeVisiteurs.Add(new Dame());
                    break;
                case 2:
                    ListeVisiteurs.Add(new Fillette());
                    break;
                case 3:
                    ListeVisiteurs.Add(new Monsieur());
                    break;
            }

            AjouterArgentHeros(_nbrAnimaux * 2);
            Refresh();
        }


        /// <summary>
        ///     Création d'un concierge
        /// </summary>
        public void CreerConcierge() {
            ListeConcierges.Add(new Concierge());
            Refresh();
        }


        /// <summary>
        ///     Déduit de l'argent du héros.
        /// </summary>
        /// <param name="montant"> Le montant d'argent à déduire. </param>
        private void DeduireArgentHeros(double montant) {
            Heros.Argent -= montant;
            Heros.Profit -= montant;
            FormePrincipale.LblArgent.Text = "Argent : " + Heros.Argent + "$";
        }


        /// <summary>
        ///     Ajoute de l'argent au héros.
        /// </summary>
        /// <param name="montant"> Le montant d'argent à ajouter. </param>
        private void AjouterArgentHeros(double montant) {
            Heros.Argent += montant;
            Heros.Profit += montant;
            FormePrincipale.LblArgent.Text = "Argent : " + Heros.Argent + "$";
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
                    if ((Heros.Position[0] == iX + x) && (Heros.Position[1] == iY + y)) {
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
            _nbrAnimaux++;
            FormePrincipale.LblNbrAnimaux.Text = "Nombre d'animaux : " + _nbrAnimaux;
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

        /// <summary>
        ///     Méthode qui vérifie si l'animal femelle est enceinte et donne naissance
        ///     à un bébé après un certain nombre de jours de gestation.
        /// </summary>
        /// <param name="enclos"> Le numéro de l'enclos </param>
        /// <param name="AnimalFeminin">L'animal femelle</param>
        private void AccoucherBebeAnimal(int enclos, Animal AnimalFeminin) {
            if (AnimalFeminin.EstEnceinte) {
                switch (AnimalFeminin.Type) {
                    case "Mouton":
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

        /// <summary>
        ///     Méthode qui donne naissance à un bébé dans une position aléatoire de l'enclos respectif.
        /// </summary>
        /// <param name="enclos">L'indice de l'enclos</param>
        private void CreerBebe(int enclos) {
            String enclosTypeAnimal = GerantCarte.AnimalEnclos[enclos];

            int pX = PosAleatoireXEnclos(enclos);
            int pY = PosAleatoireY(enclos);

            while (!GerantCarte.PosAiMap[pX, pY] && (pX != Heros.Position[0] && pY != Heros.Position[1])) {
                pX = PosAleatoireXEnclos(enclos);
                pY = PosAleatoireY(enclos);
            }

            if (enclos != 0 && AnimalEnceinte.EstEnceinte) {
                CreerAnimalBebe(enclosTypeAnimal, enclos, pX, pY);
            }
        }

        /// <summary>
        ///     Méthode qui crée le bébé de l'animal femelle. 
        /// </summary>
        /// <param name="enclosTypeAnimal">Le type d'un animal dans un enclos</param>
        /// <param name="enclos">L'indice de l'enclos</param>
        /// <param name="pX">La position aléatoire X dans l'enclos.</param>
        /// <param name="pY">La position aléatoire Y dans l'enclos.</param>
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
            TickConcierges();

            TickAnimauxEnceinte();

            _secondesJeu++;

            if (_secondesJeu % 60 == 0) {
                AjouterArgentHeros(_nbrAnimaux * _nbrAnimaux); // chaque visiteur repaie 1$ pour chaque animal présent, et pour chaque animal, il y a un visiteur.
                DeduireArgentHeros(_nbrDechets * 0.10);
            }

            this.Refresh();
        }


        /// <summary>
        ///     Mets à jour chaque visiteur et ils se déplacent.
        /// </summary>
        private void TickVisiteurs() {
            foreach (var visiteur in ListeVisiteurs) {
                visiteur.NbrJours++;
                ChanceProduireDechet(visiteur);
                visiteur.Deplacer(Heros.Position);
                visiteur.VerifierPeutQuit();

                // a tester
                if (VisiteurPeuxTuQuitter(visiteur)) {
                    ListeVisiteurs.Remove(visiteur);
                }
            }
        }

        /// <summary>
        ///     Mets à jour chaque concierge et ils se déplacent.
        /// </summary>
        private void TickConcierges() {
            foreach (var concierge in ListeConcierges) {
                concierge.Deplacer(Heros.Position);
                int nbrDechetsRammase = concierge.RamasserDechetsAdjacent();
                DecNbrDechet(nbrDechetsRammase);
                concierge.NbrJours++;

                if (concierge.NbrJours % 60 == 0) {
                    DeduireArgentHeros(2);
                }
            }
        }

        /// <summary>
        ///     Vérifie si un visiteur peut quitter.
        /// </summary>
        /// <param name="visiteur"> Le visiteur à verifier. </param>
        /// <returns></returns>
        private bool VisiteurPeuxTuQuitter(Visiteur visiteur) {
            return visiteur.droitQuitter && ((visiteur.Position[0] == 19 || visiteur.Position[0] == 20) && visiteur.Position[1] == 25);
        }

        /// <summary>
        ///     Mets à jours tous les animaux et ils se déplacent.
        /// </summary>
        private void TickAnimaux() {
            foreach (var animal in ListeAnimaux) {
                animal.NbrJours++;
                animal.JoursPasNourri++;

                if (animal.JoursPasNourri > 120) {
                    animal.JoursPasNourri = 0;
                    Contravention();
                }

                switch (animal.Type) {
                    case "Mouton":
                        if (animal.NbrJours == 150) {
                            animal.EstAdulte = true;
                        }
                        break;
                    case "Lion":
                        if (animal.NbrJours == 110) {
                            animal.EstAdulte = true;
                        }
                        break;
                    case "Licorne":
                        if (animal.NbrJours == 360) {
                            animal.EstAdulte = true;
                        }
                        break;
                }

                animal.Deplacer(Heros.Position);
            }
        }

        /// <summary>
        ///     Méthode qui vérifie si un animal femelle peut devenir enceinte dans 
        ///     chaque enclos.
        /// </summary>
        private void TickAnimauxEnceinte() {
            for (int enclos = 1; enclos < 5; enclos++) {
                VerifierAnimalEnceinte(enclos);
            }
        }

        /// <summary>
        ///     Méthode qui vérifie s'il y a la présence d'un animal mâle et d'un
        ///     animal femelle dans un enclos donné.
        /// </summary>
        /// <param name="enclos"></param>
        private void VerifierAnimalEnceinte(int enclos) {
            bool PresenceMasculin = TrouverPresenceMale(enclos);
            bool PresenceFeminin = TrouverPresenceFemelle(enclos);
            Animal AnimalFeminin = TrouverAnimalFemelle(enclos);

            if (PresenceFeminin && PresenceMasculin) {
                ChanceAnimauxEnceinte(AnimalFeminin);
                AccoucherBebeAnimal(enclos, AnimalFeminin);
            }
        }

        /// <summary>
        ///     Méthode qui retourne l'animal femelle de l'enclos donné.
        /// </summary>
        /// <param name="enclos">L'indice de l'enclos</param>
        /// <returns></returns>
        private Animal TrouverAnimalFemelle(int enclos) {
            foreach (var animal in ListeAnimaux) {
                if (animal.Genre == 1 && animal.Enclos == enclos && !animal.EstEnceinte) {
                    return AnimalEnceinte = animal;
                }
            }
            return AnimalEnceinte;
        }

        /// <summary>
        ///     Méthode qui retourne un booléen indiquant la présence d'un animal
        ///     femelle dans un enclos donné.
        /// </summary>
        /// <param name="enclos"></param>
        /// <returns></returns>
        private bool TrouverPresenceFemelle(int enclos) {
            bool PresenceFeminin = false;

            foreach (var animal in ListeAnimaux) {
                if (animal.Genre == 1 && animal.Enclos == enclos) {
                    PresenceFeminin = true;
                }
            }
            return PresenceFeminin;
        }

        /// <summary>
        ///     Méthode qui retourne un booléen indiquant la présence d'un animal
        ///     mâle dans un enclos donné.
        /// </summary>
        /// <param name="enclos">L'indice de l'enclos</param>
        /// <returns></returns>
        private bool TrouverPresenceMale(int enclos) {
            bool PresenceMasculin = false;

            foreach (var animal in ListeAnimaux) {
                if (animal.Genre == 0 && animal.Enclos == enclos) {
                    PresenceMasculin = true;
                    break;
                }
            }
            return PresenceMasculin;
        }

        /// <summary>
        ///     Méthode qui indique le nombre de chances (1%) qu'un animal femelle
        ///     peut devenir enceinte. 
        /// </summary>
        /// <param name="animalFeminin">L'animal femelle</param>
        private void ChanceAnimauxEnceinte(Animal animalFeminin) {
            if (r.Next(100) < 1) {
                animalFeminin.EstEnceinte = true;
                animalFeminin.NbrJoursGestation++;
            }
            else {
                animalFeminin.EstEnceinte = false;
                animalFeminin.NbrJoursGestation = 0;
            }
        }

        /// <summary>
        ///     Méthode qui génère une position aléatoire Y dans un enclos donné.
        /// </summary>
        /// <param name="enclos"></param>
        /// <returns></returns>
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

        /// <summary>
        ///     Méthode qui génère une position aléatoire X dans un enclos donné.
        /// </summary>
        /// <param name="enclos">L'indice de l'enclos</param>
        /// <returns></returns>
        private int PosAleatoireXEnclos(int enclos) {
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
        ///     Le visiteur a 3% chance de laisser tomber un déchet.
        /// </summary>
        /// <param name="visiteur"> Le visiteur qui a la chance de faire tomber un déchet. </param>
        private void ChanceProduireDechet(Visiteur visiteur) {
            //                     |              Pas de déchet sur un autre déchet.                    |
            if (r.Next(100) < 3 && !GerantCarte.PosDechetsMap[visiteur.Position[0], visiteur.Position[1]]) {
                visiteur.LaisserDechet();
                IncNbrDechet();
            }
        }

        /// <summary>
        ///     Incrémente le nombre de déchets.
        /// </summary>
        private void IncNbrDechet() {
            _nbrDechets++;
            FormePrincipale.LblNbrDechets.Text = "Nombre de déchets : " + _nbrDechets;
        }


        /// <summary>
        ///     Décremente le nombre de déchets.
        /// </summary>
        private void DecNbrDechet(int nbrDechetsRamasse) {
            _nbrDechets -= nbrDechetsRamasse;
            FormePrincipale.LblNbrDechets.Text = "Nombre de déchets : " + _nbrDechets;
        }


        /// <summary>
        ///     Déduit 2$ du joueur.
        /// </summary>
        private void Contravention() {
            DeduireArgentHeros(2);
        }
    }
}
