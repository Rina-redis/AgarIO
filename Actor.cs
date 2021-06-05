using System.Collections.Generic;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
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
                    newPos += directionTemp;
                    shape.Position = newPos;
                }
            }
        }
        public void EatFood(Food objectToEat, List<Food> allFood)
        {
            allFood.Remove(objectToEat);
            IncreaseRadius(objectToEat);
        }
        public Vector2f RandomVector()
        {
            Random random = new Random();
            Vector2f randomDirection = new Vector2f((float)random.NextFloat(-1,1), (float)random.NextFloat(-1, 1));
            return randomDirection;
        }
        public void TryEatFood(List<Food> allFoodInGame)
        {
            for (int indexOfFood = 0; indexOfFood < allFoodInGame.Count - 1; indexOfFood++)
            {
                bool intersect = MathHelper.CheckIntersectionCircleVsCircle(allFoodInGame[indexOfFood], this); //need to check radius of objeckt
                if (intersect)
                {
                    EatFood(allFoodInGame[indexOfFood], allFoodInGame);
                }
            }
        }
       
        public void IncreaseRadius(EatableObject objectWhichWasEaten)
        {
            shape.Radius += objectWhichWasEaten.shape.Radius/3;
        }
        
    }
}
