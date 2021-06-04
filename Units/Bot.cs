using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;
using SFML.Graphics;
using SFML.System;


namespace AgarIO
{
    class Bot: Actor
    {        
        public Bot()
        {
            Random rand = new Random();   
            shape.Position = new Vector2f(rand.Next(1, 1500), rand.Next(1, 900));
            shape.FillColor = new Color((byte)rand.Next(1, 255), (byte)rand.Next(1, 255), (byte)rand.Next(1, 255));
            shape.Radius = 25;
            speed = 0.05f;
        }
        public void Cycle(List<EatableObject> foodPieces, List<EatableObject> players)
        {
            EatableObject nearestFood = NearestFood(foodPieces);
            if(nearestFood!= null)
            {
                Move(nearestFood.shape.Position);//mde
                TryEatNearestFood(nearestFood, foodPieces);
            }
            else
            {
                Move(RandomVector());
            }

            EatableObject nearestPlayer = NearestFood(players);
            if (nearestFood != null)
            {
                Move(nearestFood.shape.Position);//mde
                TryEatNearestFood(nearestFood, foodPieces);
            }
            else
            {
                Move(RandomVector());
            }
        }   
        
         public void TryEatNearestFood(EatableObject nearestFood, List<EatableObject> foodPieces)
        {          
            bool intersect = MathHelper.CheckIntersectionCircleVsCircle(nearestFood, this);
            if (intersect)
            {
                foodPieces.Remove(nearestFood);
                IncreaseRadius(nearestFood);
            }       
        }

        public EatableObject NearestFood(List<EatableObject> foodPieces)
        {
            EatableObject nearestFood = null;
            float nearestFoodDistance = 2000;
            foreach (EatableObject food in foodPieces)
            {
                float tempNearestFoodDistance = MathHelper.DistanceToPoint(food.shape.Position, shape.Position);
                if (tempNearestFoodDistance <= nearestFoodDistance && tempNearestFoodDistance > shape.Radius)
                {
                    nearestFood = food;
                    nearestFoodDistance = tempNearestFoodDistance;
                }
            }
            return nearestFood;
        }
      
    }
}
