using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TowerDefense
{
    public class Entity : IDisposable
    {
        private PictureBox picture;
        public PictureBox Picture
        {
            get { return picture; }
            set { picture = value; }
        }
        public Entity(int x, int y, PictureBox picture)
        {
            this.picture = new PictureBox();
            picture.BackgroundImage = Properties.Resources.highground;
            this.picture.Location = new Point(x * 40, y * 40);
            this.picture.Size = new Size(40, 40);
            this.picture.BackgroundImageLayout = ImageLayout.Stretch;
            this.picture.Click += Entity_Click;
        }
        public Entity(int x, int y)
        {
            this.picture = new PictureBox();
            picture.BackgroundImage = Properties.Resources.highground;
            this.picture.Location = new Point(x * 40, y * 40);
            this.picture.Size = new Size(40, 40);
            this.picture.BackgroundImageLayout = ImageLayout.Stretch;
            this.picture.Click += Entity_Click;
        }
        public void Entity_Click(object sender, EventArgs e)
        {
            Program.game.AddTower(this);
        }
        public void Dispose() { }
    }
}
