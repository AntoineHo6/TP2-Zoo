using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileSetZoo;

namespace TP2_Zoo.Personne {
    public class Pepe : Visiteur {

        public Pepe(String nom){
            for (int i = 0; i < 10; i++) {
                Sprites.Add(VisiteurTileSetImageGenerator.GetTile(i));
            }

            Sexe = "Homme";
        }
    }
}
