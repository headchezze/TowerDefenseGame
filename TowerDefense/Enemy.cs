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
            set 
            {
                if (value <= 0)
                {
                    picture.Location = new Point(400, 40);
                    health = 100;
                    this.Direction = Game.Directions.Down;
                }
                else
                    health = value;
            }
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
            picture.BackgroundImage = Properties.Resources.LnvkNyzKNA8; //Добавляет картинку для противника
            picture.Location = new Point(400, 40); //Начальная точка где спавниться противник(11-я клетка слева, 3-я сверху)
            picture.Size = new Size(40, 40); //Размер рамки для картинки
            picture.BackgroundImageLayout = ImageLayout.Stretch; //Картинка меняет свой размер чтобы входить в рамку
            this.Direction = Game.Directions.Down;
        }
        public void Move()
        {
            switch (direction) //Движение по направлению, заданному через точки поворота
            {
                case Game.Directions.Down:
                    this.picture.Location = new Point(picture.Location.X, picture.Location.Y + 40);
                    break;
                case Game.Directions.Up:
                    this.picture.Location = new Point(picture.Location.X, picture.Location.Y - 40);
                    break;
                case Game.Directions.Right:
                    this.picture.Location = new Point(picture.Location.X + 40, picture.Location.Y);
                    break;
                case Game.Directions.Left:
                    this.picture.Location = new Point(picture.Location.X - 40, picture.Location.Y);
                    break;
            }
        }
        public void EntityIntersection(List<Waypoint> waypoints, Base base1, Tower tower) //Проверка позиции
        {
            foreach (Waypoint waypoint in waypoints) //Проверка на пересечение точки поворота
            {
                if (this.Picture.Location == waypoint.Picture.Location)
                    Direction = waypoint.Direction; //Изменение направления движения
            }

            if (this.Picture.Location == base1.Picture.Location) //Проверка на достижения базы
            {
                base1.Health -= 1; //Наносит урон
                this.Health = 0; //Умирает после
            }

            if (tower.AreIntersected(this.picture.Location)) //Если возле башние
                Health -= tower.Damage; //Получает урон от башни
        }
    }
}
