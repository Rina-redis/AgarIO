using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;
using SFML.Graphics;
using SFML.System;


namespace AgarIO
{
    class Bot : Actor
    {
        public Bot()
        {
            Random rand = new Random();
            shape.Position = new Vector2f(rand.Next(1, 1500), rand.Next(1, 900));
            shape.FillColor = new Color((byte)rand.Next(1, 255), (byte)rand.Next(1, 255), (byte)rand.Next(1, 255));
            shape.Radius = 25;
            speed = 0.05f;
        }
        public void Cycle(List<Food> foodPieces, List<Player> players)
        {
            Food nearestFood = NearestFood(foodPieces);
            if (nearestFood != null)
            {
                Move(nearestFood.shape.Position);//mde
                TryEatFood(foodPieces);
            }
            else
            {
                Move(RandomVector());
            }    
        }

        public Food NearestFood(List<Food> foodPieces)
        {
            Food nearestFood = null;
            float nearestFoodDistance = 2000;
            foreach (Food food in foodPieces)
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
