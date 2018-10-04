using System.Drawing;

namespace Asteroids
{
    class SplashScreenLabels : BaseObject
    {
        /// <summary>
        /// default parameters of object
        /// </summary>
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        public SplashScreenLabels(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// overrided Method Draw
        /// </summary>
        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawString("Автор: Максим Торопов", new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular), new SolidBrush(Color.Aqua), 500, 10);}

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
