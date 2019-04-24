using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Zoo.Noms {
    public static class Noms {

        public static List<String> noms;

        static Noms() {
            noms = new List<string>();

            // load names in txt file to list<>
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");
        }
    }
}
