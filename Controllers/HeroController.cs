using AgarIO.Units;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace AgarIO.Controllers
{
    class HeroController : Controller
    {
        public Vector2f directionToMove;
        public HeroController(Puppet Dependent) : base(Dependent)
        {
        }

        public override float speed { get; } = 0.1f;
        public void MouseMoved(object sender, MouseMoveEventArgs e)
        {
            directionToMove = new Vector2f(e.X, e.Y);
        }
        public override void Update(List<Food> foodPieces, List<Puppet> players)
        {
            Move(directionToMove);
            dependent.TryEat(foodPieces);
        }
    }
}
