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
                    Eat(objektsInGame[index], objektsInGame);
                    IncreaseRadius(objektsInGame[index] as EatableObject);
                }
            }
        }
        public void Eat<T>(T objectToEat, List<T> listObjects)
        {
            listObjects.Remove(objectToEat);
            //IncreaseRadius(objectToEat as EatableObject);
        }
        public void ChangeBody(Actor destination)
        {
            Controller tempController = powelController;
            powelController = destination.powelController;
            destination.powelController = tempController;
        }
    }
}
