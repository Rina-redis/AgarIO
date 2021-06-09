
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace AgarIO
{
    public class EatableObject
    {
        public CircleShape shape;

        public EatableObject()
        {
            shape = new CircleShape();
        }
        public Vector2f GetCenter()
        {
            return new Vector2f(shape.Position.X + shape.Radius, shape.Position.Y + shape.Radius);
        }
    }
}
