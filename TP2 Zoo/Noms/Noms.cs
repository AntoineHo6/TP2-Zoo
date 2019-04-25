using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Zoo.Noms {
    public static class Noms {

        public static List<String> NomsMasculins { get; set; }
        public static List<String> NomsFeminins { get; set; }

        static Noms() {
            NomsMasculins = new List<string>();
            NomsFeminins = new List<string>();
        }

        public static void LoadNames() {
                                                                                                        // encoding français
            string[] nomsFichierMasc = System.IO.File.ReadAllLines(@"..\..\Noms\NomsMasculins.txt", Encoding.GetEncoding("iso-8859-1"));
            foreach (String nom in nomsFichierMasc) {
                NomsMasculins.Add(nom);
            }

            string[] nomsFichierFem = System.IO.File.ReadAllLines(@"..\..\Noms\NomsFeminins.txt", Encoding.GetEncoding("iso-8859-1"));
            foreach(String nom in nomsFichierFem) {
                NomsFeminins.Add(nom);
            }
        }
    }
}
