using System.Drawing;

namespace Asteroids.Objects
{
    class Circle : BaseObject
    {
        /// <summary>
        /// Default ctor for Circle
        /// </summary>
        /// <param name="pos">position</param>
        /// <param name="dir">direction</param>
        /// <param name="size">size of object</param>
        public Circle(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// overrided Method Draw
        /// </summary>
        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
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
