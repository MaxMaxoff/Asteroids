using System.Drawing;
using Asteroids.Interfaces;

namespace Asteroids
{
    class Healthy : BaseObject
    {
        /// <summary>
        /// static images
        /// </summary>
        static Image healthy1 = Asteroids.Properties.Resources.health;

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="pos">position</param>
        /// <param name="dir">direction</param>
        /// <param name="size">size</param>
        public Healthy(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// Overrided Method Draw
        /// </summary>
        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawImage(healthy1, Pos.X, Pos.Y);
        }

        /// <summary>
        /// Overrided Method Update
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            
            if (Pos.X <= 0 || Pos.X >= SplashScreen.Width)
            {
                Pos.X = SplashScreen.StartX;
                Pos.Y = SplashScreen.StartY;
                do
                {
                    Dir.X = SplashScreen.rnd.Next(-SplashScreen.Speed, SplashScreen.Speed);
                } while (Dir.X == 0 && Dir.Y == 0);
                
            }
        }
    }
}
