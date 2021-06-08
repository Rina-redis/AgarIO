
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace AgarIO
{
    public class EatableObject
    {
        public CircleShape shape;

        public EatableObject(CircleShape shape)
        {
            this.shape = shape;
        }
    }
}
