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
        Form1 MainForm;
        public Timer spawnTimer = new Timer(); //Таймер для спавна
        public Timer stepTimer = new Timer(); //Таймер для шагов

        List<Enemy> enemies = new List<Enemy>();
        List<Waypoint> waypoints = new List<Waypoint>();
        Base base1;
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
        }
        public void SpawnEnemy(object sender, EventArgs e) //Создание противников
        {
            enemies.Add(new Enemy());
            MainForm.Controls.Add(enemies[counter].Picture);
            counter++;
        }
        public void MakeStep(object sender, EventArgs e) //Делает шаг
        {
            foreach (Enemy enemy in enemies) //Все противники
            {
                enemy.Move();
                enemy.EntityIntersection(waypoints, base1);
            }
        }
    }
}
