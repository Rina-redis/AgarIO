using System.Collections.Generic;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using System;
using AgarIO.Utilits;
using AgarIO.Controllers;

namespace AgarIO.Units
{
    class Actor : EatableObject
    {
        public Controller powelController;
        
        public Actor()
        {
            Random rand = new Random();
           // powelController = PowelController;
            shape = new CircleShape();
            shape.Radius = 30;
            shape.Position = new Vector2f(rand.Next(1, 1500), rand.Next(1, 900));
            shape.FillColor = new Color((byte)rand.Next(1, 255), (byte)rand.Next(1, 255), (byte)rand.Next(1, 255));
        }
       
        public int GetRadius() => (int)shape.Radius;

        public void Move(Vector2f direction)
        {
            if (direction != new Vector2f(0, 0))
            {
                float distance = MathHelper.DistanceToPoint(direction, GetCenter());
                if (distance > 2)
                {
                    Vector2f directionTemp = new Vector2f(powelController.speed * (direction.X - GetCenter().X) / distance,
                                                          powelController.speed * (direction.Y - GetCenter().Y) / distance);
                    Vector2f newPos = shape.Position;
                    newPos += directionTemp;
                    shape.Position = newPos;
                }
            }
        }
        public void IncreaseRadius(EatableObject objectWhichWasEaten)
        {
            shape.Radius += objectWhichWasEaten.shape.Radius / 3;
        }
        public void TryEat<T>(List<T> objektsInGame)
        {
            for (int index = 0; index < objektsInGame.Count - 1; index++)
            {
                bool intersect = MathHelper.IsIntersectsCircleVsCircle(objektsInGame[index] as EatableObject, this); //need to check radius of objeckt
                if (intersect)
                {
                    powelController.Eat(objektsInGame[index], objektsInGame);
                    IncreaseRadius(objektsInGame[index] as EatableObject);
                }
            }
        }
        public void ChangeBody(Actor destination)
        {
            Controller tempController = powelController;
            powelController = destination.powelController;
            destination.powelController = tempController;
        }
    }
}
