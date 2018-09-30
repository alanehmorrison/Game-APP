using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameChallenge
{
    class HeroRepository : ICharacter
    {
        //--Fields
        private Hero _hero;

        public void CreateCharacter(string name)
        {
            _hero = new Hero
            {
                Name = name,
                IsAlive = true,
                AttackPower = 10,
                Energy = 100

            };
        }

        public Character CharacterDetails()
        {
            return _hero;
        }

        public void TakeDamage(int attackDamage)
        {
            _hero.Energy -= attackDamage;
        }


        public void GiveEnergy(int attackDamage)
        {
            _hero.Energy += attackDamage;
        }

    }
}
