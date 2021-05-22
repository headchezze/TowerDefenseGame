using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefense
{
    public static class Game
    {
        public enum Directions
        {
            Up = 0,
            Down = 1,
            Left = 2,
            Right = 4
        }
        public static Form1 MainForm;
        public static Timer spawnTimer = new Timer(); //Таймер для спавна
        public static Timer stepTimer = new Timer(); //Таймер для шагов

        public static int score = 300;
        public static int counter = 1;
        public static void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new Form1();
            spawnTimer.Tick += Controller.SpawnEnemy; 
            spawnTimer.Interval = 2000;
            spawnTimer.Start(); //Спавнит каждые 2 секунды
            stepTimer.Tick += Controller.MakeStep; 
            stepTimer.Interval = 500;
            stepTimer.Start();  //Двигается каждые пол секунды
            DrawImages();
            UpdateScore();
            Application.Run(MainForm);
        }
        public static void DrawImages()
        {
            //Создаёт точки поворота влево, вверх и влево
            foreach (Waypoint waypoint in Controller.waypoints) //Все точки поворота получают картинку
                MainForm.Controls.Add(waypoint.Picture);

            MainForm.Controls.Add(Controller.base1.Picture);

            foreach (Entity highground in Controller.highgrounds)
                MainForm.Controls.Add(highground.Picture);
        }

        public static void DrawTowers()
        {
            foreach (Tower tower in Controller.towers)
                MainForm.Controls.Add(tower.Picture);
        }
        public static void TimeStop()
        {
            stepTimer.Enabled = false;
            spawnTimer.Enabled = false;
        }

        public static void UpdateScore()
        {
            MainForm.Score.Text = score.ToString();
            MainForm.Score.Update();
        }
    }
}
