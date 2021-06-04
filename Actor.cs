using System.Collections.Generic;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using Game.Interfaces;
using System;

namespace AgarIO
{
    class Actor : EatableObject
    {
        public float speed = 3f; //must change with changing radius       
          
        public void Move(Vector2f direction)
        {
            if (direction != new Vector2f(0, 0))
            {
                float distance = MathHelper.DistanceToPoint(direction, GetCenter());
                if (distance > 2)
                {
                    Vector2f directionTemp = new Vector2f(speed * (direction.X - GetCenter().X) / distance,
                                                          speed * (direction.Y - GetCenter().Y) / distance);
                    Vector2f newPos = shape.Position;
                    if (newPos.X < 0 || newPos.Y < 0)
                    {
                        newPos += RandomVector();
                    }
                    else
                     {
                        newPos += directionTemp;
                     }
                    shape.Position = newPos;
                }
            }
        }
        public Vector2f RandomVector()
        {
            Random random = new Random();
            Vector2f randomDirection = new Vector2f((float)random.NextFloat(-1,1), (float)random.NextFloat(-1, 1));
            return randomDirection;
        }
        public virtual void TryEat(List<Food> foodPieces)
        {
            for (int i = 0; i < foodPieces.Count - 1; i++)
            {
                bool intersect = MathHelper.CheckIntersectionCircleVsCircle(foodPieces[i], this); //need to check radius of objeckt
                if (intersect)
                {
                    foodPieces.Remove(foodPieces[i]);
                    IncreaseRadius(foodPieces[i]);
                }
            }
        }
       
        public void IncreaseRadius(EatableObject objectWhichWasEaten)
        {
            shape.Radius += objectWhichWasEaten.shape.Radius/3;
        }
        
    }
}
