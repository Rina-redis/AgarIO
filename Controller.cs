using System;
using System.Collections.Generic;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace AgarIO
{
     enum Direction { right, left, up, down}
    class Controller
    {
        Player player;
        public Controller(Player Player)
        {
            player = Player;
        }
        public void SetCoordinateForMovement(MouseMoveEventArgs e)
        {
            player.direction = new Vector2f(e.X, e.Y);
        }
        public void SpavnFood( List<Food> foodPieces, int numberOfFood)
        {
            for(int i = 0; i< numberOfFood; i++)
            {
                Random rand = new Random();
                int PosX = rand.Next(1, 1600);
                int PosY = rand.Next(1, 900);


                Food pieceOfFood = new Food(PosX, PosY);
                foodPieces.Add(pieceOfFood);
               // objectsToDraw.Add(pieceOfFood);
            }
        }

        public void CheckIntersectionWithFood(List<Food> foodPieces)
        {
            //foreach (Food food in foodPieces)
            //{
            //    bool intersect = MathHelper.CheckIntersectionCircleVsCircle(food, player);
            //    if (intersect)
            //    {
            //        foodPieces.RemoveAll(food);
            //        player.IncreaseRadius();
            //    }
            //}

            //for(int i = foodPieces.Count-1; i>=0; i--)
            //{
            //    bool intersect = MathHelper.CheckIntersectionCircleVsCircle(foodPieces[i], player);
            //    if (intersect)
            //    {
            //        foodPieces.Remove(foodPieces[i]);
            //        objectsToDraw.Remove(foodPieces[i]);
            //        player.IncreaseRadius();
            //    }
            //}

            for (int i = 0; i < foodPieces.Count - 1; i++)
            {
                bool intersect = MathHelper.CheckIntersectionCircleVsCircle(foodPieces[i], player);
                if (intersect)
                {
                    foodPieces.Remove(foodPieces[i]);                   
                    player.IncreaseRadius();
                }
            }
        }
    }
}
