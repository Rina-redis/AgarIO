﻿using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;
using SFML.Graphics;
using SFML.System;


namespace AgarIO
{
    class Bot: PlayableObject
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
        public void Cycle(List<EatableObject> foodPieces)
        {
            EatableObject nearestFood = NearestFood(foodPieces);
            Move(nearestFood.shape.Position);//mde
            TryEatNearestFood(nearestFood, foodPieces);
        }   
        
         public void TryEatNearestFood(EatableObject nearestFood, List<EatableObject> foodPieces)
        {          
            bool intersect = MathHelper.CheckIntersectionCircleVsCircle(nearestFood, this);
            if (intersect)
            {
                foodPieces.Remove(nearestFood);
                IncreaseRadius();
            }       
        }

        public EatableObject NearestFood(List<EatableObject> foodPieces)
        {
            EatableObject nearestFood = new EatableObject();
            float nearestFoodDistance = 2000;
            foreach (EatableObject food in foodPieces)
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
      
    }
}