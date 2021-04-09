using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TowerDefense
{
    public class Enemy
    {
        private int health;
        private PictureBox picture;
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
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
        public Enemy()
        {
            Health = 100;
            picture = new PictureBox();
            picture.BackgroundImage = Image.FromFile(@"C:\Users\headchezze\Desktop\MixedPresentAkitainu-size_restricted.gif");
            picture.Location = new Point(400, 40);
            picture.Size = new Size(40, 40);
            picture.BackgroundImageLayout = ImageLayout.Stretch;
            this.Direction = Game.Directions.down;
        }
        public void Move()
        {
            switch (direction)
            {
                case Game.Directions.down:
                    this.picture.Location = new Point(picture.Location.X, picture.Location.Y + 40);
                    break;
                case Game.Directions.up:
                    this.picture.Location = new Point(picture.Location.X, picture.Location.Y - 40);
                    break;
                case Game.Directions.right:
                    this.picture.Location = new Point(picture.Location.X + 40, picture.Location.Y);
                    break;
                case Game.Directions.left:
                    this.picture.Location = new Point(picture.Location.X - 40, picture.Location.Y);
                    break;
            }
        }

    }
}
