
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace AgarIO
{
    class Circle
    {
     
        public CircleShape shape;
        public Circle()
        {
            shape = new CircleShape();
        }
        public Vector2f GetCenter()
        {
            return new Vector2f(shape.Position.X / 2, shape.Position.Y / 2);
        }
        public void CenterPosition(Vector2f position)
        {
            shape.Position = new Vector2f(position.X - shape.Radius, position.Y - shape.Radius);
        }
    }
}
