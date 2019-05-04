using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileSetZoo;

namespace TP2_Zoo.Personne {
    class Monsieur : Visiteur {
        public Monsieur() {
            for (int i = 12; i < 16; i++) {
                Sprites.Add(HumainTileSetImageGenerator.GetTile(i));
            }
            Type = "Monsieur";

            Sexe = 0;

            Nom = AssignerNom(Sexe);
        }
    }
}
