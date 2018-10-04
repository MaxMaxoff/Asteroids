using System.Drawing;

namespace Asteroids
{
    class BaseObject
    {
        /// <summary>
        /// default parameters of object
        /// </summary>
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="pos">position</param>
        /// <param name="dir">direction</param>
        /// <param name="size">size of object</param>
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        /// <summary>
        /// virtual Method Draw
        /// </summary>
        public virtual void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// virtual Method Update
        /// </summary>
        public virtual void Update()
        {
            //Pos.X = Pos.X + Dir.X;
            //Pos.Y = Pos.Y + Dir.Y;
            //if (Pos.X <= 0) Dir.X = -Dir.X;
            //if (Pos.X >= (Game.Width - Size.Width - 20)) Dir.X = -Dir.X;
            //if (Pos.Y <= 0) Dir.Y = -Dir.Y;
            //if (Pos.Y >= (Game.Height - Size.Height - 40)) Dir.Y = -Dir.Y;

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
