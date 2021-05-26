using System;
using System.Collections.Generic;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace AgarIO
{
    class Food : EatableObject
    {     
        public Food()
        {
            shape = new CircleShape();
            Random rand = new Random();
            int positionX = rand.Next(1, 1600);
            int positionY = rand.Next(1, 900);
            shape.Position = new Vector2f(positionX, positionY);
            shape.Radius = 7;       
            shape.FillColor = new Color((byte)rand.Next(1, 255), (byte)rand.Next(1, 255), (byte)rand.Next(1, 255)) ;
        }
        public void Die()
        {
            shape.Dispose();
        }
    }
}
