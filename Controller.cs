using System;
using System.Collections.Generic;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace AgarIO
{
    class Controller
    {
        Circle owner;
        

        public Controller(Circle Player)
        {
            owner = Player;
        }

        public void SetCoordinateForMovement(MouseMoveEventArgs e)
        {
           owner.Move(new Vector2f(e.X, e.Y));
        }

        public void TryEatFood(List<Food> foodPieces)
        {
            for (int i = 0; i < foodPieces.Count - 1; i++)
            {
                bool intersect = MathHelper.CheckIntersectionCircleVsCircle(foodPieces[i], owner);
                if (intersect)
                {
                    foodPieces.Remove(foodPieces[i]);
                    owner.shape.Radius++;                  
                }
            }

        }
    }
}
