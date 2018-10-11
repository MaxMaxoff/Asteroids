using System.Drawing;
using Asteroids.Interfaces;

namespace Asteroids
{
    class UFO : BaseObject
    {
        public UFO(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// overrided Method Draw
        /// </summary>
        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width * 2, Size.Height / 2);
            SplashScreen.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width * 2, Size.Height / 2);
            SplashScreen.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X + Size.Width / 2, Pos.Y - Size.Height / 4 * 3, Size.Height, Size.Width);
        }

        /// <summary>
        /// overrided Method Update
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X + SplashScreen.rnd.Next(-5, 5);
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
