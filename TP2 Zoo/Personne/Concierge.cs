using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileSetZoo;

namespace TP2_Zoo.Personne {
    public class Concierge : Personne {

        public int Frais { get; set; }
        public int NbrJours { get; set; }

        public Concierge() {
            for (int i = 16; i < 20; i++) {
                Sprites.Add(HumainTileSetImageGenerator.GetTile(i));
            }
            Position = new int[] { 38, 5 };
            Frais = 2;
        }

        public void Deplacer(int[] positionHero) {
            Ai.Ai.ChoixDirectionAleatoire(Position, positionHero);
        }

        /// <summary>
        ///     Méthode qui permet de ramasser les déchets adjacents.
        /// </summary>
        /// <returns></returns>
        public int RamasserDechetsAdjacent() {
            int nbrDechetRamasse = 0;
            int tuileAVerifierX;
            int tuileAVerifierY;

            for (int y = -1; y < 2; y++) {
                for (int x = -1; x < 2; x++) {
                    tuileAVerifierX = Position[0] + x;
                    tuileAVerifierY = Position[1] + y;

                    try {
                        if (GerantCarte.PosDechetsMap[tuileAVerifierX, tuileAVerifierY]) {
                            GerantCarte.PosDechetsMap[tuileAVerifierX, tuileAVerifierY] = false;
                            nbrDechetRamasse++;
                        }
                    }
                    catch (IndexOutOfRangeException e) {
                        continue;
                    }
                }
            }
            return nbrDechetRamasse;
        }
    }
}
