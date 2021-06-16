using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using AgarIO.Core;

namespace AgarIO.Units
{
    class Food : EatableObject 
    {
        public Food()
        {
            Random rand = new Random();
            int positionX = rand.Next(1, 1600);
            int positionY = rand.Next(1, 900);
            shape.Position = new Vector2f(positionX, positionY);
            shape.Radius = 7;
            shape.FillColor = new Color((byte)rand.Next(1, 255), (byte)rand.Next(1, 255), (byte)rand.Next(1, 255));
        }     
    }
}
