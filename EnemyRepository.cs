using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameChallenge
{
    class EnemyRepository : ICharacter
    {
        private Enemy _enemy;

        public void CreateCharacter(string name)
        {
            _enemy = new Enemy
            {
                Name = name,
                AttackPower = 10,
                IsAlive = true,
                Energy = 100
            };
        }

        public Character CharacterDetails()
        {
            return _enemy;
        }

        public void TakeDamage(int attackDamage)
        {
            _enemy.Energy -= attackDamage;
        }

        public void GiveEnergy(int attackDamage)
        {
            _enemy.Energy += attackDamage;
        }

    }
}
