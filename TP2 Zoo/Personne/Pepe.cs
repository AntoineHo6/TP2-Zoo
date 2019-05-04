using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileSetZoo;

namespace TP2_Zoo.Personne {
    public class Pepe : Visiteur {

        public Pepe(){
            for (int i = 0; i < 4; i++) {
                Sprites.Add(HumainTileSetImageGenerator.GetTile(i));
            }
            Type = "Pépé";

            Sexe = 0;

            Nom = AssignerNom(Sexe);
        }
    }
}
