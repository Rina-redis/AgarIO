
using AgarIO.Units;
using AgarIO.Utilits;
using SFML.System;
using System.Collections.Generic;

namespace AgarIO.Core
{
     class AIController : Controller
    {
        public new float speed = 0.5f;
        public override Vector2f DirectionToMove(Powel currentPowel, List<Food> foodPieces, List<Powel> players)
        {
            Food nearestFood = NearestFood(currentPowel, foodPieces);
            if (nearestFood != null)
            {
                return nearestFood.shape.Position;
                //Move(nearestFood.shape.Position);
                //TryEat(foodPieces);
                //// TryEat(players);
            }
            else
            {
                return new Vector2f(0,0);
                //Move(RandomVector());
            }
        }

        public Food NearestFood(Powel currentPowel, List<Food> foodPieces)
        {
            Food nearestFood = null;
            float nearestFoodDistance = 2500; //patamushta tak nada
            foreach (Food food in foodPieces)
            {
                float tempNearestFoodDistance = MathHelper.DistanceToPoint(food.shape.Position, currentPowel.shape.Position);
                if (tempNearestFoodDistance <= nearestFoodDistance && tempNearestFoodDistance > currentPowel.shape.Radius)
                {
                    nearestFood = food;
                    nearestFoodDistance = tempNearestFoodDistance;
                }
            }
            return nearestFood;
        }
    }
}