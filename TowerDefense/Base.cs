using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TowerDefense
{
    public class Base
    {
        private int health;
        private PictureBox picture;

        public int Health
        {
            get { return health; }
            set 
            {
                if (value <= 0)
                {
                    MessageBox.Show("GAME OVER");
                }
                health = value;
            }
        }

        public PictureBox Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        public Base()
        {
            Health = 5;
            picture = new PictureBox();
            picture.BackgroundImage = Properties.Resources.png_clipart_drawing_castle_sand_art_and_play_coloring_book_castle_angle_text;
            picture.Location = new Point(40, 160);
            picture.Size = new Size(40, 40);
            picture.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
