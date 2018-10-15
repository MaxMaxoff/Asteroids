using System.Drawing;
using System.Windows.Forms;
using Asteroids.Interfaces;

namespace Asteroids.Objects
{
    class Transport : BaseObject
    {
        /// <summary>
        /// Image for transport
        /// </summary>
        static Image transport = Asteroids.Properties.Resources.transport;

        /// <summary>
        /// Direction (Vector)
        /// </summary>
        private static int MoveX, MoveY;

        /// <summary>
        /// Position of Transport for Bullets
        /// </summary>
        public static int positionX, positionY;

        /// <summary>
        /// Default Ctor
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Transport(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// Method draw
        /// </summary>
        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawImage(transport, Pos.X, Pos.Y);
        }

        /// <summary>
        /// Method Update
        /// </summary>
        public override void Update()
        {
            Pos.X += MoveX;
            Pos.Y += MoveY;
            positionX = Pos.X;
            positionY = Pos.Y;

            if (Pos.X <= 0) Pos.X = 1;
            if (Pos.Y <= 0) Pos.Y = 1;
            if (Pos.X >= SplashScreen.Width - 40) Pos.X = SplashScreen.Width - 41;
            if (Pos.Y >= SplashScreen.Height - 40) Pos.Y = SplashScreen.Height - 41;
        }

        /// <summary>
        /// Method for KeyDown event
        /// </summary>
        /// <param name="e">KeyEventArgs</param>
        public static void UpdateOnKeyDown(object sender, KeyEventArgs e)
        {
            int speed = 10;
            
            switch (e.KeyData)
            {
                case Keys.Up:
                    MoveY = -speed;
                    break;
                case Keys.Down:
                    MoveY = speed;
                    break;
                case Keys.Left:
                    MoveX = -speed;
                    break;
                case Keys.Right:
                    MoveX = speed;
                    break;
                case Keys.Space:
                    SplashScreen._objsBullets.Add(new Bullet(new Point(Transport.positionX + 65, Transport.positionY + 32),
                            new Point(Transport.positionX + 65, Transport.positionY + 32), new Size(3, 3)));
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Method for KeyUp event
        /// </summary>
        /// <param name="e">KeyEventArgs</param>
        public static void UpdateOnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Up:
                    MoveY = 0;
                    break;
                case Keys.Down:
                    MoveY = 0;
                    break;
                case Keys.Left:
                    MoveX = 0;
                    break;
                case Keys.Right:
                    MoveX = 0;
                    break;
                default:
                    break;
            }
        }

        public void Die()
        {
            MessageDie?.Invoke();
        }

        public static event Message MessageDie;
    }
}
