using System.Drawing;

namespace Asteroids
{
    class SplashScreenLabels : BaseObject
    {
        /// <summary>
        /// default Ctor
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public SplashScreenLabels(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// overrided Method Draw
        /// </summary>
        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawString("Автор: Максим Торопов", new Font(FontFamily.GenericSansSerif, 9, FontStyle.Regular), new SolidBrush(Color.Aqua), 10, SplashScreen.Height - 40);
            SplashScreen.Buffer.Graphics.DrawString($"Score: {SplashScreen.score}", new Font(FontFamily.GenericSansSerif, 9, FontStyle.Regular), new SolidBrush(Color.Aqua), 10, SplashScreen.Height - 30);
            SplashScreen.Buffer.Graphics.DrawString($"Health: {SplashScreen.health}", new Font(FontFamily.GenericSansSerif, 9, FontStyle.Regular), new SolidBrush(Color.Aqua), 10, SplashScreen.Height - 20);
        }

        /// <summary>
        /// Method Update
        /// </summary>
        public override void Update()
        {}
    }
}
