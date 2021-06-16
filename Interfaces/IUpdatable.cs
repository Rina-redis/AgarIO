using AgarIO.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgarIO.Core
{
    interface IUpdatable
    {
        public void Update(List<Food> foodPieces, List<Puppet> players);
    }
}
