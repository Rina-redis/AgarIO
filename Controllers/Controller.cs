using System.Collections.Generic;
using SFML.System;
using System;
using AgarIO.Utilits;
using SFML.Graphics;
using AgarIO.Units;
using AgarIO.Core;

namespace AgarIO.Controllers
{
    class Controller : IUpdatable
    {
        public virtual float speed { get; } = 0.05f;
        protected Puppet dependent;
        CircleShape shape;
        public Controller(Puppet Dependent)
        {
            dependent = Dependent;
            shape = Dependent.shape;
        }
     
        public void Move(Vector2f direction)
        {
            if (direction != new Vector2f(0, 0))
            {
                float distance = MathHelper.DistanceToPoint(direction, dependent.GetCenter());
                if (distance > 2)
                {
                    Vector2f directionTemp = new Vector2f(speed * (direction.X - dependent.GetCenter().X) / distance,
                                                          speed * (direction.Y - dependent.GetCenter().Y) / distance);
                    Vector2f newPos = shape.Position;
                    newPos += directionTemp;
                    shape.Position = newPos;
                }
            }
        }
        public Vector2f RandomVector()
        {
            Random random = new Random();
            Vector2f randomDirection = new Vector2f((float)random.NextFloat(-1, 1), (float)random.NextFloat(-1, 1));
            return randomDirection;
        }

        public virtual Vector2f CalculateDirectionToMove(Puppet currentPowel, List<Food> foodPieces, List<Puppet> players)
        {
            return new Vector2f(0, 0);
        }
        public CircleShape GetShape() => shape;
        public virtual void Update(List<Food> foodPieces, List<Puppet> players)
        {
           //get direction
           //move
           //try eat food
        }
    }
}
