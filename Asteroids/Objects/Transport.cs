using System.CodeDom;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids.Objects
{
    class Transport : BaseObject
    {

        static Image transport = Asteroids.Properties.Resources.transport;
        private static int MoveX, MoveY;
        public static int positionX, positionY;

        public static int PositionX
        {
            set { positionX = value; }
        }

        public static int PositionY
        {
            set { positionY = value; }

        }

        public Transport(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawImage(transport, Pos.X, Pos.Y);
        }

        public override void Update()
        {
            Pos.X = MoveX;
            Pos.Y = MoveY;
            positionX = Pos.X;
            positionY = Pos.Y;

            //if (Pos.X <= 0) Pos.X = 1;
            //if (Pos.Y <= 0) Pos.Y = 1;
            //if (Pos.X >= SplashScreen.Width) Pos.X = SplashScreen.Width - 65;
            //if (Pos.Y >= SplashScreen.Height) Pos.Y = SplashScreen.Height - 65;
        }

        public static void UpdateOnKeyPress(System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    MoveY -= 10;
                    break;
                case Keys.Down:
                    MoveY += 10;
                    break;
                case Keys.Left:
                    MoveX -= 10;
                    break;
                case Keys.Right:
                    MoveX += 10;
                    break;
                case Keys.Space:
                    SplashScreen._objsBullets.Add(new Bullet(new Point(Transport.positionX + 65, Transport.positionY + 32),
                            new Point(Transport.positionX + 65, Transport.positionY + 32), new Size(3, 3)));
                    break;
                default:
                    break;
            }

            if (MoveX <= 0) MoveX = 1;
            if (MoveY <= 0) MoveY = 1;
            if (MoveX >= SplashScreen.Width - 40) MoveX = SplashScreen.Width - 41;
            if (MoveY >= SplashScreen.Height - 40) MoveY = SplashScreen.Height - 41;
        }
    }
}
