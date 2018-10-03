using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class UFO : BaseObject
    {
        public UFO(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// overrided Method Draw
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// overrided Method Update
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X + Game.rnd.Next(0, 10);;
            Pos.Y = Pos.Y + Dir.Y + Game.rnd.Next(0, 10);;

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
