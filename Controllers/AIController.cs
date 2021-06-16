using AgarIO.Units;
using AgarIO.Utilits;
using SFML.System;
using System.Collections.Generic;

namespace AgarIO.Controllers
{
    class AIController : Controller
    {
        public new float speed = 0.5f;
        public AIController(Puppet Dependent) : base(Dependent)
        {
        }

        public override Vector2f CalculateDirectionToMove(Puppet currentPowel, List<Food> foodPieces, List<Puppet> players)
        {
            Food nearestFood = NearestFood(currentPowel, foodPieces);
            if (nearestFood != null)
            {
                return nearestFood.shape.Position;
            }
            else
            {
                return new Vector2f(0, 0);
            }
        }

        public Food NearestFood(Puppet currentPowel, List<Food> foodPieces)
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
        public override void Update(List<Food> foodPieces, List<Puppet> players)
        {
            Vector2f directionToMove = CalculateDirectionToMove(dependent, foodPieces, players);
            Move(directionToMove);
            dependent.TryEat(foodPieces);
        }
    }
}