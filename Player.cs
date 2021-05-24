 using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Window;
using SFML.Graphics;


namespace AgarIO
{
    class Player: Circle
    {
        float speed = 0.5f;
       
        public Player()
        {
            shape = new CircleShape();
            shape.FillColor = Color.Red;
            shape.Radius = 30;
        }    
        
        public void IncreaseRadius()
        {
            shape.Radius++;
        }
    }
}
