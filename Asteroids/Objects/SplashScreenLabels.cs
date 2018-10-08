using System.Drawing;

namespace Asteroids
{
    class SplashScreenLabels : BaseObject
    {
        public SplashScreenLabels(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// overrided Method Draw
        /// </summary>
        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawString("Автор: Максим Торопов", new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular), new SolidBrush(Color.Aqua), 500, 10);
        }

        public override void Update()
        {}
    }
}
