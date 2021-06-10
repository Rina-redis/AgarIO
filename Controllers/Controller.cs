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
        Actor dependent;
        public Controller(Actor Dependent)
        {
            dependent = Dependent;
        }
        public virtual float speed { get; } = 0.05f; //must change with changing radius    

        public void Eat<T>(T objectToEat, List<T> listObjects)
        {
            listObjects.Remove(objectToEat);
            //IncreaseRadius(objectToEat as EatableObject);
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
    }
}
