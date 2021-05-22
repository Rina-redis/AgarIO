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
       public void Controll(Keyboard.Key key)
        {
            if (player.keysMovement.ContainsKey(key))
            {

            }
        }

    }
}
