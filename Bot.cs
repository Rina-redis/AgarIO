using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;
using SFML.Graphics;
using SFML.System;


namespace AgarIO
{
    class Bot:Circle
    {
        public Bot()
        {
            Random rand = new Random();
            shape = new CircleShape();
            shape.Position = new Vector2f(rand.Next(1, 1500), rand.Next(1, 900));
            shape.FillColor = new Color((byte)rand.Next(1, 255), (byte)rand.Next(1, 255), (byte)rand.Next(1, 255));
            shape.Radius = 25;
        }
        public void TryEatFood(List<Food> foodPieces)
        {

        }
        public Food NearestFood(List<Food> foodPieces)
        {
            Food nearestFood = new Food(0,0);
            float nearestFoodDistance = 2000;
            foreach (Food food in foodPieces)
            {
               float tempNearestFoodDistance = MathHelper.DistanceToPoint(shape.Position, food.shape.Position);
                if (tempNearestFoodDistance <= nearestFoodDistance)
                {
                    nearestFood = food;
                    nearestFoodDistance = tempNearestFoodDistance;
                }                  
            }
            return nearestFood;
        }
        public void MoveToNearestFood(Food nearestFood)
        {

        }
    }
}
