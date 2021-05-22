using System;
using System.Collections.Generic;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace AgarIO
{
    class Food : Circle
    {
        public Food(int positionX, int positionY)
        {
            Random rand = new Random();
            shape.Position = new Vector2f(positionX, positionY);
            shape.Radius = 7;       
            shape.FillColor = new Color((byte)rand.Next(1, 255), (byte)rand.Next(1, 255), (byte)rand.Next(1, 255)) ;
        }
    }
}
