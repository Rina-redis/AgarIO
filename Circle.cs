
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace AgarIO
{
    class Circle
    {
     
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
        public void Move()
        {
            if (direction != null)
            {
            
                //Vector2f PosToMove = new Vector2f( time * direction.X,  time * direction.Y);
                //shape.Position = PosToMove; 

                CenterPosition(direction); // пока сойдёт
            }
        }
    }
}
