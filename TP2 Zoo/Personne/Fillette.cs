using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileSetZoo;

namespace TP2_Zoo.Personne {
    class Fillette : Visiteur {

        public Fillette() {
            for (int i = 8; i < 12; i++) {
                Sprites.Add(HumainTileSetImageGenerator.GetTile(i));
            }
            Type = "Fillette";

            Sexe = 1;

            Nom = AssignerNom(Sexe);
        }
    }
}
