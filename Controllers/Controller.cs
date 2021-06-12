using System.Collections.Generic;
using SFML.System;
using System;
using AgarIO.Utilits;
using SFML.Graphics;
using AgarIO.Units;

namespace AgarIO.Controllers
{
    class Controller
    {
        public virtual float speed { get; } = 0.05f;
        protected Actor dependent;
        CircleShape shape;
        public Controller(Actor Dependent)
        {
            dependent = Dependent;
            shape = Dependent.shape;
        }
         //must change with changing radius    

      
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

        public virtual Vector2f CalculateDirectionToMove(Actor currentPowel, List<Food> foodPieces, List<Actor> players)
        {
            return new Vector2f(0, 0);
        }

        public virtual void Cycle(List<Food> foodPieces, List<Actor> players)
        {
           // Vector2f directionToMove = CalculateDirectionToMove(dependent, foodPieces, players);
          //  Move(directionToMove);
           // dependent.TryEat(foodPieces);
        }
    }
}
