using AgarIO.Units;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace AgarIO.Controllers
{
    class HeroController : Controller
    {
        public Vector2f directionToMove;
        public HeroController(Actor Dependent) : base(Dependent)
        {
        }

        public override float speed { get; } = 3f;
        public void MouseMoved(MouseMoveEventArgs e)
        {
            directionToMove = new Vector2f(e.X, e.Y);
        }
        public override void Cycle(List<Food> foodPieces, List<Actor> players)
        {
            Move(directionToMove);
            dependent.TryEat(foodPieces);
        }
    }
}
