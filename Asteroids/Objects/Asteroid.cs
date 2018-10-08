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
        /// <summary>
        /// static images
        /// </summary>
        static Image aster1 = Asteroids.Properties.Resources.aster1;
        static Image aster2 = Asteroids.Properties.Resources.aster2;
        static Image aster3 = Asteroids.Properties.Resources.aster3;
        static Image aster4 = Asteroids.Properties.Resources.aster4;

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="pos">position</param>
        /// <param name="dir">direction</param>
        /// <param name="size">size</param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// Overrided Method Draw
        /// </summary>
        public override void Draw()
        {
            switch (SplashScreen.rnd.Next(1, 5))
            {
                    case 1: SplashScreen.Buffer.Graphics.DrawImage(aster1, Pos.X, Pos.Y);
                        break;
                    case 2: SplashScreen.Buffer.Graphics.DrawImage(aster2, Pos.X, Pos.Y);
                        break;
                    case 3: SplashScreen.Buffer.Graphics.DrawImage(aster3, Pos.X, Pos.Y);
                        break;
                    default: SplashScreen.Buffer.Graphics.DrawImage(aster4, Pos.X, Pos.Y);
                        break;
            }
        }

        /// <summary>
        /// Overrided Method Update
        /// </summary>
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
