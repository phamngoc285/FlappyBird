using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.Models
{
    public class Pipe
    {
        public Bitmap bm;
        public Point Location;
        public int Height = 204;
        public int Width = 80;

        public Pipe()
        {
        }

        public Pipe(Point location)
        {
            this.Location = location;
        }

        public void MoveToLeft()
        {
            Location.X -= 20;
        }

        public bool IsPast()
        {
            if (Location.X + Height <= 0)
            {
                return true;
            }
            return false;
        }
    }
}
