using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefense
{
    public class Game
    {
        public enum Directions
        {
            Up = 0,
            Down = 1,
            Left = 2,
            Right = 4
        }
        static Form1 MainForm;
        public Timer spawnTimer = new Timer(); //Таймер для спавна
        public Timer stepTimer = new Timer(); //Таймер для шагов

        List<Enemy> enemies = new List<Enemy>();
        List<Waypoint> waypoints = new List<Waypoint>();
        List<Tower> towers = new List<Tower>();
        List<Entity> highgrounds;
        Base base1;
        private int score = 0;
        public int counter = 0;
        public void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new Form1();
            spawnTimer.Tick += SpawnEnemy; 
            spawnTimer.Interval = 2000;
            spawnTimer.Start(); //Спавнит каждые 2 секунды
            stepTimer.Tick += MakeStep; 
            stepTimer.Interval = 500;
            stepTimer.Start();  //Двигается каждые пол секунды
            DrawImages();
            Application.Run(MainForm);
        }
        public void DrawImages()
        {
            //Создаёт точки поворота влево, вверх и влево
            waypoints = new List<Waypoint>() { new Waypoint(10, 10, Directions.Left), new Waypoint(7, 10, Directions.Up), new Waypoint(7, 4, Directions.Left) };
            foreach (Waypoint waypoint in waypoints) //Все точки поворота получают картинку
                MainForm.Controls.Add(waypoint.Picture);

            base1 = new Base();
            MainForm.Controls.Add(base1.Picture);

            highgrounds = new List<Entity>() { new Entity(7, 3), new Entity(6, 6), new Entity(9, 8) };
            foreach (Entity highground in highgrounds)
                MainForm.Controls.Add(highground.Picture);
        }
        public void SpawnEnemy(object sender, EventArgs e) //Создание противников
        {
            enemies.Add(new Enemy());
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] != null)
                    MainForm.Controls.Add(enemies[i].Picture);
            }
        }
        public void MakeStep(object sender, EventArgs e) //Делает шаг
        {
            for (int i = 0; i < enemies.Count; i++) //Все противники
            {
                enemies[i].Move();
                enemies[i].EntityIntersection(waypoints, towers, base1);
            }
            DrawTowers();
        }
        public void DrawTowers()
        {
            foreach (Tower tower in towers)
                MainForm.Controls.Add(tower.Picture);
        }
        public void TimeStop()
        {
            this.stepTimer.Enabled = false;
            this.spawnTimer.Enabled = false;
        }
        public void AddTower(Entity entity)
        {
            towers.Add(new Tower(entity.Picture.Location.X / 40, entity.Picture.Location.Y / 40));
            entity.Picture.Dispose();
            highgrounds.Remove(entity);
        }
        public void KillEnemy(Enemy enemy)
        {
            enemy.Picture.Dispose();
            enemies.Remove(enemy);
            score += 100;
            MainForm.Score.Text = score.ToString();
            MainForm.Score.Update();
        }
    }
}
