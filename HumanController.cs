﻿using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgarIO
{
    class HumanController : Controller
    {
        public override float speed { get; } = 3f;
        public Vector2f MouseMoved(MouseMoveEventArgs e)
        {
            return new Vector2f(e.X, e.Y);
        }
    }
}
