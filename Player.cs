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
        public Vector2f direction;
        public Dictionary<Keyboard.Key, Direction> keysMovement = new Dictionary<Keyboard.Key, Direction>()
            {
             {Keyboard.Key.W, Direction.up },
             {Keyboard.Key.S, Direction.down },
             {Keyboard.Key.A, Direction.left },
             {Keyboard.Key.D, Direction.right }
            };

        public Player()
        {
            shape = new CircleShape();
            shape.FillColor = Color.Red;
            shape.Radius = 30;
        }    
        public void Move()
        {
            if(direction!= null)
            {           
                CenterPosition(direction); //херня, но пока сойдёт
            }
        }
        public void IncreaseRadius()
        {
            shape.Radius++;
        }
    }
}
