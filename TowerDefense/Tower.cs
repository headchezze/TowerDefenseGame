using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TowerDefense
{
    public class Tower : Entity
    {
        private int damage;
        private Area towerArea;
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        public Tower(int x, int y) : base(x, y)
        {
            Picture = new PictureBox();
            Picture.BackgroundImage = Properties.Resources.unnamed;
            Picture.Location = new Point(x * 40, y * 40);
            Picture.Size = new Size(40, 40);
            Picture.BackgroundImageLayout = ImageLayout.Stretch;
            Damage = 101;
            towerArea = new Area(Picture.Location.X - 40, Picture.Location.Y - 40, 120, 120);
        }
        public bool AreIntersected(Point point)
        {
            return (point.X < towerArea.Right && point.X > towerArea.Left) && (point.Y > towerArea.Top && point.Y < towerArea.Bottom);
        }
    }
}
