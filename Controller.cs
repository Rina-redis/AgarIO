using System.Collections.Generic;
using SFML.System;
using System;
using AgarIO.Utilits;
using SFML.Graphics;
using AgarIO.Units;

namespace AgarIO
{
    class Controller 
    {
        public virtual float speed { get; } = 0.1f; //must change with changing radius    

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
       
        public virtual void Cycle(Powel currentPowel, List<Food> foodPieces, List<Powel> players)
        {
        }    
        public virtual Vector2f DirectionToMove (Powel currentPowel, List<Food> foodPieces, List<Powel> players)
        {
            return new Vector2f(0, 0);
        }
    }
}
