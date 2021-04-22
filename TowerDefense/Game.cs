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
            up = 0,
            down = 1,
            left = 2,
            right = 4,
            still = 5
        }
        Form1 MainForm;
        Timer spawnTimer = new Timer(); //Таймер для спавна
        Timer stepTimer = new Timer(); //Таймер для шагов
        Timer dmgTimer = new Timer();

        List<Enemy> enemies = new List<Enemy>();
        List<Waypoint> waypoints = new List<Waypoint>();
        List<Tower> towers = new List<Tower>();
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
            dmgTimer.Tick += dealDamage;
            dmgTimer.Interval = 500;
            dmgTimer.Start();
            spawnTimer.Start(); //Спавнит каждые 2 секунды
            CreateWaypoints();
            Application.Run(MainForm);
            
        }
        public void CreateWaypoints()
        {
            //Создаёт точки поворота влево, вверх и влево
            waypoints = new List<Waypoint>() { new Waypoint(10, 10, Directions.left), new Waypoint(7, 10, Directions.up), new Waypoint(7, 4, Directions.left) };
            foreach (Waypoint waypoint in waypoints) //Все точки поворота получают картинку
                MainForm.Controls.Add(waypoint.Picture);
            //Создаёт башни
            towers = new List<Tower>() { new Tower() };
            foreach (Tower tower in towers) //Все башни получают картинку
                MainForm.Controls.Add(tower.Picture);
        }
        public void SpawnEnemy(object sender, EventArgs e) //Создание противников
        {
            enemies.Add(new Enemy());
            MainForm.Controls.Add(enemies[counter].Picture);
            counter++;
            //CheckDeath(enemies);
        }
        public void MakeStep(object sender, EventArgs e) //Делает шаг
        {
            foreach (Enemy enemy in enemies) //Все противники
            {
                enemy.Move();
                foreach (Waypoint waypoint in waypoints)
                {
                    enemy.WaypointIntersection(waypoint);
                }
            }
            //CheckDeath(enemies);
        }
        //Надо найти способ показывать на экране когда этот метод действует
        public void dealDamage(object sender, EventArgs e) //Наносит урон противникам в радиусе башен
        {
            foreach (Enemy enemy in enemies) //Все противники
            {
                foreach (Tower tower in towers) //Все башни
                {
                    //я не уверен что это правильно работает
                    if ((enemy.Picture.Location.X <= tower.Range.Location.X + 120) && (enemy.Picture.Location.Y <= tower.Range.Location.Y + 120)) //Если противник находится в дистанции 120 на 120 от башни
                        enemy.Health -= 50; //противник получает урон
                }
            }
        }
        //Не работает правильно, убирая противника из листа происходит ошибка, не уверен как можно исправить
        //public void CheckDeath(List<Enemy> enemies) //Убивает противников которые достигают 0 Health
        //{

        //    foreach (Enemy enemy in enemies)
        //    {
        //        if (enemy.Health == 0)
        //            enemies.Remove(enemy);
        //    }
        //}

    }
}
