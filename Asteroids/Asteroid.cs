using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Asteroid : BaseObject
    {
        static Image image = Asteroids.Properties.Resources._3rQK96czs_NJxy4PjmC1hQ;

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// overrided Method Draw
        /// </summary>
        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;

            if (Pos.X <= 0 || Pos.X >= SplashScreen.Width || Pos.Y <= 0 || Pos.Y >= SplashScreen.Height)
            {
                Pos.X = SplashScreen.StartX;
                Pos.Y = SplashScreen.StartY;
                do
                {
                    Dir.X = SplashScreen.rnd.Next(-SplashScreen.Speed, SplashScreen.Speed);
                    Dir.Y = SplashScreen.rnd.Next(-SplashScreen.Speed, SplashScreen.Speed);    
                } while (Dir.X == 0 && Dir.Y == 0);
                
            }
        }
    }
}
