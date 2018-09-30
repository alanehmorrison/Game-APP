using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameChallenge
{
    interface ICharacter
    {
        void CreateCharacter(string name);
        Character CharacterDetails();
        void TakeDamage(int attackDamage);
        void GiveEnergy(int attackDamage);
    }
}
