using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileSetZoo;

namespace TP2_Zoo.Personne {
    class Dame : Visiteur {

        public Dame() {
            for (int i = 4; i < 8; i++) {
                Sprites.Add(HumainTileSetImageGenerator.GetTile(i));
            }
            Type = "Dame";
            Sexe = 1;
            Nom = AssignerNom(Sexe);
        }
    }
}
