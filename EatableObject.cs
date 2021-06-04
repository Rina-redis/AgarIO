using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using Game.Interfaces;
using SFML.Window;
using SFML.Graphics;

namespace AgarIO
{
    public class EatableObject : IEatable
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
        public void CenterPosition(Vector2f position)
        {
            shape.Position = new Vector2f((position.X - shape.Radius), (position.Y - shape.Radius));
        }
    }
}
