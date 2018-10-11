using System;
using System.Drawing;

namespace Asteroids.Objects
{
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {}

        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X += 20;
            
            if (Pos.X >= SplashScreen.Width) SplashScreen._objsBullets.RemoveAt(SplashScreen._objsBullets.IndexOf(this));
        }
    }
}
