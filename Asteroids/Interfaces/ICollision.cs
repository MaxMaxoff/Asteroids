using System.Drawing;

namespace Asteroids.Interfaces
{
    /// <summary>
    /// Interface for calculation collisions
    /// </summary>
    public interface ICollision
    {
        bool Collision(ICollision obj);

        Rectangle Rect { get; }
    }
}
