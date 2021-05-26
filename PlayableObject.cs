﻿using System.Collections.Generic;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace AgarIO
{
    class PlayableObject : EatableObject
    {
        public float speed = 3f; //must change with changing radius       
          
        public void Move(Vector2f direction)
        {
            if (direction != new Vector2f(0, 0))
            {
                float distance = MathHelper.DistanceToPoint(direction, GetCenter());
                if (distance > 2)
                {
                    Vector2f directionTemp = new Vector2f(speed * (direction.X - GetCenter().X) / distance,
                                                          speed * (direction.Y - GetCenter().Y) / distance);
                    Vector2f newPos = shape.Position + directionTemp;
                    if(newPos.X < 0 || newPos.Y < 0)
                    {
                        
                    }
                      shape.Position = newPos;
                }
            }
        }
        public void TryEat(List<EatableObject> foodPieces)
        {
            for (int i = 0; i < foodPieces.Count - 1; i++)
            {
                bool intersect = MathHelper.CheckIntersectionCircleVsCircle(foodPieces[i], this); //need to check radius of objeckt
                if (intersect)
                {
                    foodPieces.Remove(foodPieces[i]);
                    IncreaseRadius(foodPieces[i]);
                }
            }
        }
       
        public void IncreaseRadius(EatableObject objectWhichWasEaten)
        {
            shape.Radius += objectWhichWasEaten.shape.Radius/3;
        }
    }
}
