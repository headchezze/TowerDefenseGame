using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefense
{
    public partial class Form1 : Form
    {
        private const int windowWidth = 900;
        private const int windowHeight = 800;
        private const int cellSize = 40;
        public Timer SpawnTimer = new Timer();
        public Label Score;
        public Label ScoreBoard;
        public Form1()
        {
            InitializeComponent();
            this.Width = windowWidth;
            this.Height = windowHeight;
            GenerateMap();
            globalTimer.Tick += new EventHandler(Update);
            globalTimer.Interval = 500;
            globalTimer.Start();
            Score = new Label();
            ScoreBoard = new Label();
            Score.Location = new Point(830, 100);
            ScoreBoard.Location = new Point(800, 100);
            ScoreBoard.Text = "Score:";
            Score.Text = "0";
            this.Controls.Add(Score);
            this.Controls.Add(ScoreBoard);
        }
        private void GenerateMap()
        {
            for (int i = 0; i < windowWidth / cellSize; ++i)
            {
                PictureBox line = new PictureBox();
                line.BackColor = Color.Black;
                line.Location = new Point(0, cellSize * i);
                line.Size = new Size(windowWidth - 100, 1);
                this.Controls.Add(line);
            }
            for (int i = 0; i <= windowHeight / cellSize; ++i)
            {
                PictureBox line = new PictureBox();
                line.BackColor = Color.Black;
                line.Location = new Point(cellSize * i, 0); ;
                line.Size = new Size(1, windowHeight);
                this.Controls.Add(line);
            }
        }
        private void Update(object sender, EventArgs e)
        {
            //newEnemy.Move();
            //Intersection();
        }
        private void Spawn(object sender, EventArgs e)
        {
            
        }
        /*private void Intersection()
        {
            for (int i = 0; i < waypoints.Length; ++i)
                if (newEnemy.Picture.Location == waypoints[i].Picture.Location)
                    newEnemy.Direction = (Game.Directions)waypoints[i].Direction;
        }*/
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
