using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;
using SFML.Graphics;
using SFML.System;


namespace AgarIO
{
    class Bot:Food
    {
        float speed = 0.5f;
        Controller controller;
        public Bot()
        {
            Random rand = new Random();
            shape = new CircleShape();
            shape.Position = new Vector2f(rand.Next(1, 1500), rand.Next(1, 900));
            shape.FillColor = new Color((byte)rand.Next(1, 255), (byte)rand.Next(1, 255), (byte)rand.Next(1, 255));
            shape.Radius = 25;
            controller = new Controller(this);
        }
        public void Cycle(List<Food> foodPieces)
        {
            Food nearestFood = NearestFood(foodPieces);
            MoveToNearestFood(nearestFood, foodPieces);
        }    

        public Food NearestFood(List<Food> foodPieces)
        {
            Food nearestFood = new Food();
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
        public void MoveToNearestFood(Food nearestFood, List<Food> foodPieces)
        {          
               float distance = MathHelper.DistanceToPoint(direction, GetCenter());
               if (distance > 2)
                {
                    Vector2f directionTemp = new Vector2f(speed  * (nearestFood.shape.Position.X - GetCenter().X) / distance,
                                      speed  * (nearestFood.shape.Position.Y - GetCenter().Y) / distance);
                    shape.Position += directionTemp;
                    controller.TryEatFood(foodPieces);
                }
            
        }
    }
}
