using System.Drawing;
using Asteroids.Interfaces;

namespace Asteroids
{
    public abstract class BaseObject: ICollision
    {
        /// <summary>
        /// default parameters of object
        /// </summary>
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        /// <summary>
        /// Property Position
        /// </summary>
        public Point Position
        {
            get { return Pos; }
            set { Pos = value; }

        }

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

        public Rectangle Rect => new Rectangle(Pos, Size);

        /// <summary>
        /// Method Collision for calculation collision
        /// </summary>
        /// <param name="obj">Object </param>
        /// <returns></returns>
        public bool Collision(ICollision obj)
        {
            return obj.Rect.IntersectsWith(this.Rect);
        }

        /// <summary>
        /// virtual Method Draw
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// virtual Method Update
        /// </summary>
        public abstract void Update();
    }
}
