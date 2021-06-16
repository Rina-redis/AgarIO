using AgarIO.Units;
using System.Collections.Generic;

namespace AgarIO.Core
{
    interface IUpdatable
    {
        public void Update(List<Food> foodPieces, List<Puppet> players);
    }
}
