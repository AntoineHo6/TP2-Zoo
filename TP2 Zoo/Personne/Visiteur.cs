﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Zoo;
using TP2_Zoo.Ai;

namespace TP2_Zoo.Personne {
    public abstract class Visiteur : Personne {

        public String Nom { get; set; }
        public int Sexe { get; set; }   // 0: masculin; 1: feminin
        public int NbrJours { get; set; }
        public int NbrDechets { get; set; }
        public int PrixEntree { get; set; }
        public bool PeutQuitter { get; set; }

        static Random r = new Random();

        public Visiteur() {
            Position = new int[] {19, 0 };
            Ai.Ai.OccuperTuile(19, 0);
            PrixEntree = 2;
            NbrJours = 0;
            PeutQuitter = false;
        }
        

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


        public void Deplacer(int[] positionHero) {
            Ai.Ai.ChoixDirectionAleatoire(Position, positionHero);
        }
    }
}
