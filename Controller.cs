using System.Collections.Generic;
using SFML.System;
using System;
using AgarIO.Utilits;
using SFML.Graphics;

namespace AgarIO
{
    class Controller : EatableObject
    {
        public float speed = 3f; //must change with changing radius    

        public Controller(CircleShape shape) : base(shape)
        {
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
                    Vector2f newPos = shape.Position;            
                    newPos += directionTemp;
                    shape.Position = newPos;
                }
            }
        }
        public void Eat<T>(T objectToEat, List<T> listObjects)
        {
            listObjects.Remove(objectToEat);
            IncreaseRadius(objectToEat as EatableObject);
        }
        public Vector2f RandomVector()
        {
            Random random = new Random();
            Vector2f randomDirection = new Vector2f((float)random.NextFloat(-1,1), (float)random.NextFloat(-1, 1));
            return randomDirection;
        }
        public void TryEat<T>(List<T> objektsInGame)
        {         
            for (int index = 0; index < objektsInGame.Count - 1; index++)
            {
                bool intersect = MathHelper.IsIntersectsCircleVsCircle(objektsInGame[index] as EatableObject, this); //need to check radius of objeckt
                if (intersect)
                {            
                    Eat(objektsInGame[index], objektsInGame);                                    
                }
            }
        }
       
        public void IncreaseRadius(EatableObject objectWhichWasEaten)
        {
            shape.Radius += objectWhichWasEaten.shape.Radius/3;
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
