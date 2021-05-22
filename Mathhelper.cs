using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace AgarIO
{
    class MathHelper
    {
        public static bool CheckIntersectionCircleVsCircle(Circle circle1, Circle circle2)
        {
            float distance = (float)Math.Sqrt((circle2.GetCenter().X - circle1.GetCenter().X) * (circle2.GetCenter().X - circle1.GetCenter().X) +
                                              (circle2.GetCenter().Y - circle1.GetCenter().Y) * (circle2.GetCenter().Y - circle1.GetCenter().Y));
            if (distance < circle2.shape.Radius)
                return true;
            return false;
        }
    }
}
