using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TowerDefense
{
    public class Enemy : IDisposable
    {
        private int health;
        private PictureBox picture;
        private Dictionary<int, int> Level = new Dictionary<int, int>()
        {
            { 1, 1 },
            { 5, 2 },
            { 15, 3 },
            { 30, 4 }
        };

        private static int multiplyer = 1;
        public int Health
        {
            get { return health; }
            set 
            {
                if (value <= 0)
                {
                    Program.game.KillEnemy(this);
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
        public Enemy(int level)
        {
            if (Level.ContainsKey(level))
                multiplyer = Level[level];
            Health = 100 * multiplyer;
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
        public void EntityIntersection(List<Waypoint> waypoints, List<Tower> towers, Base base1) //Изменение движения через точки поворота
        {
            foreach (Tower tower in towers)
            {
                if (tower.AreIntersected(this.picture.Location))
                    Health -= tower.Damage;
            }

            foreach (Waypoint waypoint in waypoints)
            {
                if (this.Picture.Location == waypoint.Picture.Location)
                    Direction = waypoint.Direction;
            }

            if (this.Picture.Location == base1.Picture.Location)
            {
                base1.Health -= 1;
                this.Health = 0;
            }
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(true);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    disposed = true;

                }
                disposed = true;
            }
        }

        ~Enemy()
        {
            Dispose(false);
        }
    }
}
