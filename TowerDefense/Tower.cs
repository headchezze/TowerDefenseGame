using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TowerDefense
{
    public class Tower
    {
        private int damage;
        private Area towerArea;
        private PictureBox picture;
        public PictureBox Picture
        {
            get { return picture; }
            set { picture = value; }
        }
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        public Tower(int x, int y)
        {
            picture = new PictureBox(); //Картинка для башни
            picture.BackgroundImage = Properties.Resources.unnamed;
            picture.Location = new Point(x * 40, y * 40);
            picture.Size = new Size(40, 40);
            picture.BackgroundImageLayout = ImageLayout.Stretch;
            towerArea = new Area(picture.Location.X - 40, picture.Location.Y - 40, 120, 120); //Создание зоны в которой башня будет наносить урон
            Damage = 99;
        }
        public bool AreIntersected(Point point) //Проверка на противника в зоне
        {
            return (towerArea.Left + towerArea.Width - point.X >= 0) && ((towerArea.Width + point.Y) >= (towerArea.Left + towerArea.Width - point.X))
                && (towerArea.Top + towerArea.Height - point.X >= 0) && ((towerArea.Height + point.Y) >= (towerArea.Top + towerArea.Height - point.X));
        }
    }
}
