using System.Collections.Generic;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace AgarIO.Units
{
    class Player : Actor
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
            //CircleShape tempShape = shape;

            //Actor newPlayer = bots[randomBotNumber];
            //shape = newPlayer.shape;

            //bots[randomBotNumber].shape = tempShape; nenenene
        }
        public void TryEat(List<Food> foodPieces, List<Bot> bots)
        {
            TryEat(foodPieces);
            TryEat(bots);
        }
    }
}
