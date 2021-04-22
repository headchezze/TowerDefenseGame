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
            picture.BackgroundImage = Properties.Resources.LnvkNyzKNA8; //Добавляет картинку для противника
            picture.Location = new Point(400, 40); //Начальная точка где спавниться противник(11-я клетка слева, 3-я сверху)
            picture.Size = new Size(40, 40); //Размер рамки для картинки
            picture.BackgroundImageLayout = ImageLayout.Stretch; //Картинка меняет свой размер чтобы входить в рамку
            this.Direction = Game.Directions.down;
        }
        public void Move()
        {
 
                switch (direction) //Движение по направлению, заданному через точки поворота
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
                    default:
                        break;
                }
            
        }
        public void WaypointIntersection(Waypoint waypoint) //Изменение движения через точки поворота
        {
            if (this.Picture.Location == waypoint.Picture.Location)
            {
                Direction = waypoint.Direction;
                //Убрать проверку на смерть отсюда на метод действующий каждый фрейм
                Die(); //Убивает при достижении точки перехода
            }
        }
        public void Die() //Противник "умирает"
        {
            if (this.Health <= 0) //Если здоровье меньше или равно 0 то противник выносится за экран и перестаёт двигаться
            {
                this.Direction = Game.Directions.still;
                this.Picture.Location = new Point(-100, -100);
                
            }
        }
    }
}
