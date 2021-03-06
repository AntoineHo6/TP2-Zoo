﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Zoo;
using TP2_Zoo.Ai;

namespace TP2_Zoo.Personne {
    public abstract class Visiteur : Personne {

        static Random r = new Random();

        public String Nom { get; set; }
        public int Sexe { get; set; }   // 0: masculin; 1: feminin
        public String Type { get; set; }
        public int NbrJours { get; set; }
        public int NbrDechets { get; set; }
        public bool droitQuitter { get; set; }

        public Visiteur() {
            Position = new int[] {19, 0 };
            Ai.Ai.OccuperTuile(19, 0);
            NbrJours = 0;
            droitQuitter = false;
        }
        
        /// <summary>
        ///     Méthode qui permet d'assigner un nom à un visiteur.
        /// </summary>
        /// <param name="sexe">Le sexe de la personne</param>
        /// <returns></returns>
        public String AssignerNom(int sexe) {
            if (sexe == 0) {
                int indexM = r.Next(0, Noms.Noms.NomsMasculins.Count);
                return Noms.Noms.NomsMasculins[indexM];
            }
            else {
                int indexF = r.Next(0, Noms.Noms.NomsFeminins.Count);
                return Noms.Noms.NomsFeminins[indexF];
            }
        }

        /// <summary>
        ///     Méthode qui permet aux visiteurs de quitter après un certain temps.
        /// </summary>
        public void VerifierPeutQuit() {
            if (NbrJours > 60) {
                droitQuitter = true;
            }
        }

        /// <summary>
        ///     Méthode qui permet de laisser un déchet à une position donnée.
        /// </summary>
        public void LaisserDechet() {
            GerantCarte.PosDechetsMap[Position[0], Position[1]] = true;
        }

        /// <summary>
        ///     Méthode qui permet le déplacement du visiteur.
        /// </summary>
        /// <param name="positionHero"></param>
        public void Deplacer(int[] positionHero) {
            Ai.Ai.ChoixDirectionAleatoire(Position, positionHero);
        }
    }
}
