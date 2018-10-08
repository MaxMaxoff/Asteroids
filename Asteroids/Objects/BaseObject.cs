using System.Drawing;

namespace Asteroids
{
    public abstract class BaseObject
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
        public abstract void Draw();

        /// <summary>
        /// virtual Method Update
        /// </summary>
        public abstract void Update();
    }
}
