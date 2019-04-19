using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TP2_Zoo.Personne {
    public abstract class Personne {

        public int[] Position { get; set; }
        public List<Bitmap> Sprites { get; set; }

        public Personne() {
            Sprites = new List<Bitmap>();
        }


        public void Peinturer(PaintEventArgs e, int index) {
            e.Graphics.DrawImage(Sprites[index], Position[0] * 32, Position[1] * 32);
        }

    }
}
