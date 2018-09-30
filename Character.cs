using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameChallenge
{
    abstract class Character
    {
        public string Name { get; set; }
        public int AttackPower { get; set; }
        public bool IsAlive { get; set; }
        public int Energy { get; set; }

    }
}
