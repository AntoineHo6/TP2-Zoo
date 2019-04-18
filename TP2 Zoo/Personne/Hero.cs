using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2_Zoo.Personne {
    public class Hero : Personne {
        int Argent { get; set; }

        public Hero(params int[] Position) : base(Position) {
            this.Position = Position;
            Argent = 100;
        }

        public void Peinturer(PaintEventArgs e) {
            e.Graphics.DrawImage(Properties.Resources.bas1, Position[0]*32, Position[1]*32);
        }
    }
}
