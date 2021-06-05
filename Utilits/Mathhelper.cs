using System;
using SFML.System;

namespace AgarIO.Utilits
{
    public static class MathHelper
    {
        private static Random random;
        static MathHelper()
        {
            random = new Random();
        }
        public static bool IsIntersectsCircleVsCircle(EatableObject circle1, EatableObject circle2)
        {
            float deltaX = (circle2.GetCenter().X - circle1.GetCenter().X);
            float deltaY = (circle2.GetCenter().Y - circle1.GetCenter().Y);
           
            float distanceSquare = (deltaX*deltaX + deltaY*deltaY);
            return distanceSquare < circle2.shape.Radius*circle2.shape.Radius;
        }
        public static int RandomNumber(int count)
        {          
            return random.Next(0, count);
        }
        public static float DistanceToPoint(Vector2f source, Vector2f destination)
        {
            float distanceToPoint = (float)Math.Sqrt((destination.X - source.X) * (destination.X - source.X) +
                                       (destination.Y - source.Y) * (destination.Y - source.Y));

            return distanceToPoint;
        }
        public static float NextFloat(this Random rand, float a, float b)
        {
            float value = (float)rand.NextDouble();
            return value * (b - a) + a;
        }

    }
}
