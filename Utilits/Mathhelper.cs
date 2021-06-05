using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using NPOI.SS.Formula.Functions;

namespace AgarIO
{
    public static class MathHelper
    {
        public static bool CheckIntersectionCircleVsCircle(EatableObject circle1, EatableObject circle2)
        {
            float distance = (float)Math.Sqrt((circle2.GetCenter().X - circle1.GetCenter().X) * (circle2.GetCenter().X - circle1.GetCenter().X) +
                                              (circle2.GetCenter().Y - circle1.GetCenter().Y) * (circle2.GetCenter().Y - circle1.GetCenter().Y));
            if (distance < circle2.shape.Radius)
                return true;
            return false;
        }
        public static int RandomNumber(int count)
        {
            Random random = new Random();
            return random.Next(0, count);
        }
        public static float DistanceToPoint(Vector2f source, Vector2f destination)
        {
            float distanceToPoint = (float)Math.Sqrt(((destination.X -source.X) *(destination.X - source.X)) +
                                       ((destination.Y - source.Y) * (destination.Y - source.Y)));

            return distanceToPoint;
        }
        public static float NextFloat(this Random rand, float a, float b)
        {
            float value = (float)rand.NextDouble();
            return value * (b - a) + a;
        }

    }
}
