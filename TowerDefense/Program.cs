using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefense
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 
        public static Game game;
        [STAThread]
        static void Main()
        {
            game = new Game();
            game.Start();
        }
        public static void GameOver()
        {
            game.TimeStop();
        }
    }
}
