 using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using System.Linq;


namespace AgarIO
{
    class Player: Actor
    {

        public Player()
        {
            shape = new CircleShape();
            shape.FillColor = Color.Red;
            shape.Radius = 30;
            shape.Position = new Vector2f(200, 200);
          
        }
        public void SetCoordinateForMovement(MouseMoveEventArgs e)
        {
            Move(new Vector2f(e.X, e.Y));
        }
        public int GetRadius() => (int)shape.Radius;
        

        public void ChangeCurrentBodyToBot(List<Bot> bots, int randomBotNumber)
        {
            CircleShape tempShape = shape;

            Actor newPlayer = bots[randomBotNumber];
            shape = newPlayer.shape;

            bots[randomBotNumber].shape = tempShape;
        }
        public void TryEat(List<Food> foodPieces, List<Bot> bots)
        {
            TryEatFood(foodPieces);
            for (int i = 0; i < bots.Count - 1; i++)
            {
                bool intersect = MathHelper.CheckIntersectionCircleVsCircle(bots[i], this); //need to check radius of objeckt
                if (intersect)
                {
                    bots.Remove(bots[i]);
                    IncreaseRadius(bots[i]);
                }
            }
        }
    }
}
