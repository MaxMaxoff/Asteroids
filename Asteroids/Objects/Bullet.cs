using System.Drawing;
using Asteroids.Interfaces;

namespace Asteroids.Objects
{
    class Bullet : BaseObject
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {}

        /// <summary>
        /// method Draw
        /// </summary>
        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawEllipse(Pens.Red, Pos.X, Pos.Y, Size.Width, Size.Height);
            SplashScreen.Buffer.Graphics.FillEllipse(Brushes.Aqua, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Method Update
        /// </summary>
        public override void Update()
        {
            Pos.X += 20;
            
            if (Pos.X >= SplashScreen.Width) SplashScreen._objsBullets.RemoveAt(SplashScreen._objsBullets.IndexOf(this));
        }
    }
}
