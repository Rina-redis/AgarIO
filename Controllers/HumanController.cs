using AgarIO.Units;
using SFML.System;
using SFML.Window;


namespace AgarIO.Controllers
{
    class HumanController : Controller
    {
        public HumanController(Actor Dependent) : base(Dependent)
        {
        }

        public override float speed { get; } = 3f;
        public Vector2f MouseMoved(MouseMoveEventArgs e)
        {
            return new Vector2f(e.X, e.Y);
        }
    }
}
