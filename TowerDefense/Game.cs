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
            right = 4
        }
        Form1 MainForm;
        Timer spawnTimer = new Timer();
        Timer stepTimer = new Timer();

        List<Enemy> enemies = new List<Enemy>(3);
        List<Waypoint> waypoints = new List<Waypoint>();
        public int counter = 0;
        public void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new Form1();

            spawnTimer.Tick += SpawnEnemy;
            spawnTimer.Interval = 1000;
            spawnTimer.Start();
            stepTimer.Tick += MakeStep;
            stepTimer.Interval = 500;
            stepTimer.Start();

            Application.Run(MainForm);
        }
        public void SpawnEnemy(object sender, EventArgs e)
        {
            enemies.Add(new Enemy());
            MainForm.Controls.Add(enemies[counter].Picture);
            counter++;
        }
        public void MakeStep(object sender, EventArgs e)
        {
            foreach (Enemy enemy in enemies)
                enemy.Move();
        }
    }
}
