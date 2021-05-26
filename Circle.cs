
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace AgarIO
{
    class Circle
    {
        float speed = 2f; //must change with changing radius
        public CircleShape shape;
        public Vector2f direction;
        public Circle()
        {
            shape = new CircleShape();
        }
        public Vector2f GetCenter()
        {
            return new Vector2f(shape.Position.X + shape.Radius, shape.Position.Y + shape.Radius);
        }
        public void CenterPosition(Vector2f position)
        {
            shape.Position = new Vector2f((position.X - shape.Radius), (position.Y - shape.Radius));
        }
        public void Move(Vector2f direction)
        {
            if (direction != new Vector2f(0, 0))
            {
                float distance = MathHelper.DistanceToPoint(direction, GetCenter());
                if (distance > 2)
                {
                    Vector2f directionTemp = new Vector2f(speed * (direction.X - GetCenter().X) / distance,
                                      speed * (direction.Y - GetCenter().Y) / distance);
                    shape.Position += directionTemp;
                }
            }
        }
    }
}
