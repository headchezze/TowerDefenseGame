using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    public static class Controller
    {
        public static List<Enemy> enemies = new List<Enemy>() ;
        public static List<Waypoint> waypoints = new List<Waypoint>() { new Waypoint(10, 10, Game.Directions.Left), new Waypoint(7, 10, Game.Directions.Up), new Waypoint(7, 4, Game.Directions.Left) };
        public static List<Tower> towers = new List<Tower>();
        public static List<Entity> highgrounds = new List<Entity>() { new Entity(7, 3), new Entity(6, 6), new Entity(9, 8) };
        public static Base base1 = new Base();

        public static void KillEnemy(Enemy enemy)
        {
            enemy.Picture.Dispose();
            Controller.enemies.Remove(enemy);
            Game.score += 100;
            Game.counter++;
            Game.UpdateScore();
        }

        public static void AddTower(Entity entity)
        {
            if (Game.score >= 300)
            {
                Controller.towers.Add(new Tower(entity.Picture.Location.X / 40, entity.Picture.Location.Y / 40));
                entity.Picture.Dispose();
                Controller.highgrounds.Remove(entity);
                Game.score -= 300;
                Game.UpdateScore();
            }
        }
        public static void MakeStep(object sender, EventArgs e) //Делает шаг
        {
            for (int i = 0; i < Controller.enemies.Count; i++) //Все противники
            {
                Controller.enemies[i].Move();
                Controller.enemies[i].EntityIntersection(Controller.waypoints, Controller.towers, Controller.base1);
            }
            Game.DrawTowers();
        }
        public static void SpawnEnemy(object sender, EventArgs e) //Создание противников
        {
            Controller.enemies.Add(new Enemy(Game.counter));
            for (int i = 0; i < Controller.enemies.Count; i++)
            {
                if (Controller.enemies[i] != null)
                    Game.MainForm.Controls.Add(Controller.enemies[i].Picture);
            }
        }
    }
}
