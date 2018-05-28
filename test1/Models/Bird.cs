using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1.Models
{
    public class Bird
    {
        public Bitmap bm = new Bitmap(@"Resources/BirdSprite.png");
        public int Index = 0;
        public int Width = 44;
        public int Height = 36;

        private int TimeUp = 0;

        public Point Location;
        //public int x = 0, y = 20;
        public bool IsDied = false;

        public Bird()
        {
            Width = Height = 0;
        }

        public Bird(Point location)
        {
            this.Location = location;
        }

        public Bird(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void Set(int width, int height)
        {
            Width = width;
            Height = height;
        }

   

        public void Up()
        {
            if (IsDied) return;
            
            Location.Y -= 100;
            Index = 0;
            SoundPlayer sound = new SoundPlayer(test1.Properties.Resources.tap);
            sound.Play();
        }

        public void Down()
        {
            if (IsDied) return;
           
            Location.Y += 20;
        }

        public void Die()
        {
            if (IsDied) return ;

            IsDied = true;

            SoundPlayer sound = new SoundPlayer(test1.Properties.Resources.gameover);
            sound.Play();
        }
    }
}

