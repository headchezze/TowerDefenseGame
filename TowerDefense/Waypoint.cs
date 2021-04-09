using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TowerDefense
{
    public class Waypoint
    {
        private PictureBox picture;
        public PictureBox Picture
        {
            get { return picture; }
            set { picture = value; }
        }
        private Game.Directions direction;
        public Game.Directions Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        public Waypoint()
        {
            Random rnd = new Random();
            picture = new PictureBox();
            picture.BackColor = Color.Red;
            picture.Size = new Size(40, 40);
            picture.Location = new Point(40 * rnd.Next(0, 20), 40 * rnd.Next(0, 20));
            direction = (Game.Directions)rnd.Next(0, 4);
        }
        public Waypoint(int x, int y, Game.Directions direction)
        {
            Random rnd = new Random();
            picture = new PictureBox();
            picture.BackColor = Color.Red;
            picture.Size = new Size(40, 40);
            picture.Location = new Point(40 * x, 40 * y);
            this.direction = direction;
        }
    }
}
