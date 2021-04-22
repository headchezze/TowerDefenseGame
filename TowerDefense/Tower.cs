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
        private PictureBox range;
        private PictureBox picture;
        public int Damage //Урон который башня наносит
        {
            get { return damage; }
            set { damage = value; }
        }
        public PictureBox Picture //Картинка башни
        {
            get { return picture; }
            set { picture = value; }
        }
        public PictureBox Range //Расстояние с которого башня может наносить урон
        {
            get { return range; }
            set { range = value; }
        }
        public Tower()
        {
            Damage = 50;
            //range можно сделать лучше, наверное
            range = new PictureBox();
            range.Size = new Size(120, 120);
            range.Location = new Point(40 * 11, 40 * 7); //Башня создаётся по пикселям
            picture = new PictureBox();
            picture.BackColor = Color.Blue;
            picture.Size = new Size(40, 40); //Размер клетки в пикселях
            picture.Location = new Point(40 * 11, 40 * 7); //Башня создаётся по пикселям
        }
        //На будущие(завтра): сделать перегузку метода
        //public tower(int x, int y) //Создание точки поворота с полными данными
        //{
        //    Damage = 50;
        //    Range = 120;
        //    picture = new PictureBox();
        //    picture.BackColor = Color.Blue;
        //    picture.Size = new Size(40, 40); //Размер клетки в пикселях
        //    picture.Location = new Point(40 * x, 40 * y); //Точка создаётся по пикселям
        //}
    }
}
