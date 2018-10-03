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
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y,
                Size.Width, Size.Height);
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

            if (Pos.X <= 0 || Pos.X >= Game.Width || Pos.Y <= 0 || Pos.Y >= Game.Height)
            {
                Pos.X = Game.Width / 2 + Game.rnd.Next(0, 3);
                Pos.Y = Game.Height / 2 + Game.rnd.Next(0, 3);
                Dir.X = Game.rnd.Next(0, Game.Speed + 1) - Game.Speed / 2;
                Dir.Y = Game.rnd.Next(0, Game.Speed + 1) - Game.Speed / 2;
            }
        }

    }
}
