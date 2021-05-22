 using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Window;
using SFML.Graphics;


namespace AgarIO
{
    class Player
    {
        public CircleShape shape;
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
            shape.Radius = 15;

        }    

    }
}
