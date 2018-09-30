using System;

namespace GameChallenge
{
    internal class ProgramUI
    {
        private HeroRepository _heroRepo = new HeroRepository();
        private EnemyRepository _enemyRepo = new EnemyRepository();

        public void Run()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;

            SetUpGame();
            RunGame();
            EndGame();
        }

        private void EndGame()
        {
            Console.WriteLine( "Thank you for playing! End Game!");
            Console.Clear();
          
        }

        private void SetUpGame()
        {
            CreateHero();
            CreateEnemy();
            ShowHeroDetails();
            ShowEnemyDetails();

        }

        private void ShowEnemyDetails()
        {
            Console.WriteLine("Here are the details for your toddler:\n");

            var enemy = _enemyRepo.CharacterDetails();

            Console.WriteLine($"Character Details:\n " +
                $"Name: {enemy.Name}\n" +
                $"Health: {enemy.IsAlive}\n" +
                $"Energy: {enemy.Energy}\n");
            
        }

        private void ShowHeroDetails()
        {
            Console.WriteLine("Here are the details for you, Mom:");

            var hero = _heroRepo.CharacterDetails();

            Console.WriteLine($"Mom Details: \n" +
                $"Name: {hero.Name}\n" +
                $"Health: {hero.IsAlive}\n" +
                $"Energy: {hero.Energy}\n"
                );
            
        }

        private void CreateEnemy()
        {
            Console.WriteLine("Shrills come from the other room and you drop what your\n" +
                "paper, panicked! Crap! It's time. Your toddler has awoken in the other\n" +
                "room. You rush to grab them from their bed. What is your toddlers name?\n");

            string name = Console.ReadLine();

            _enemyRepo.CreateCharacter(name);

        }

        private void CreateHero()
        {
            Console.WriteLine($"Welcome to Surving Toddlers.\n" +
                $"Let's see if you have what it takes to be a mom.\n " +
                $"We know what every good mom needs to make it through\n" +
                $"their day - energy. You have 3 bursts of energy. It's simple.\n" +
                $"Do great things and your toddler loses energy. Mess up and cause stress\n" +
                $"to yourself and lose energy. Let's see how you do. First, what's your mom name?\n");

            string name = Console.ReadLine();

            _heroRepo.CreateCharacter(name);

            

        }

        private void RunGame()
        {
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            while (hero.IsAlive && enemy.IsAlive)
            {
                //DO STUFF
                PromptPlayer();
            }

            if (enemy.Energy == 0){
                enemy.IsAlive = false;
            }

            if (hero.Energy == 0)
            {
                hero.IsAlive = false;
            }
            
        }

        private void PromptPlayer()
        {
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

                Console.WriteLine($"What would you like to do?:\n" +
                    $"1. Give the {enemy.Name} a nap.\n" +
                    $"2. Take the {enemy.Name} to the park.\n" +
                    $"3. Hide In the Pantry to drink wine. Its 5 o'clock somewhere\n" +
                    $"4. Arts and Crafts. \n" +
                    $"5. See Current Stats for {enemy.Name} and {hero.Name}"
                    );
                var input = int.Parse(Console.ReadLine());

                HandleBattleInput(input);
           
        }

        private void HandleBattleInput(int input)
        {
            switch (input)
            {
                case 1:
                    Nap();
                    break;
                case 2:
                    Park();
                    break;
                case 3:
                    Pantry();
                    break;
                case 4:
                    ArtsCrafts();
                    break;
                case 5:
                    ShowHeroDetails();
                    ShowEnemyDetails();
                    break;
                default:
                    break;
            }
        }


        private void Nap()
        {
            //Get hero variable
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            Console.WriteLine($"You're trying to put {enemy.Name} down for a nap BUT\n" +
                $"they are refusing to lay down. You're getting worn out and \n" +
                $"{enemy.Name} is not budging. What do you do? \n" +
                $"1. Pat {enemy.Name} to sleep.\n" +
                $"2. Turn on a lullaby and walk out.\n" +
                $"3. Give {enemy.Name} a bottle and run.\n");
            var actions = int.Parse(Console.ReadLine());

            ToddlerNapInput(actions);
        }

        private void ToddlerNapInput(int actions)
        {
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            switch (actions)
            {

                case 1:
                    Console.WriteLine($"Congratulations you put {enemy.Name} to sleep! \n" +
                        $"You won 10 extra health points for yourself!");
                    _heroRepo.GiveEnergy(hero.Energy);
                    break;

                case 2:
                    Console.WriteLine($"Good try, {hero.Name}! We applaud your efforts.\n" +
                        $"However, {enemy.Name} got out of bed as soon as you walked out.\n" +
                        $"{enemy.Name} crapped their pants, rubbed the crap up the walls,\n " +
                        $"on themselves, and all over their crib. You came back in the room \n" +
                        $"to mudpies. You lost 10 health points exhaustively cleaning and \n" +
                        $"sanitizing your house. Next time, though, Mom.\n");
                    _heroRepo.GiveEnergy(hero.Energy);
                    break;

                case 3:
                    Console.WriteLine($"Double Bonus! Not only did {enemy.Name} take a nap,\n " +
                        $"but since you ran out, {enemy.Name} lost energy by crying themself \n" +
                        $"to sleep and you gained energy by getting to relax. Nice win, Mom.");
                    break;

                default:
                    break;
                        
            }
        }

        private void Park()
        {
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            Console.WriteLine($"Although you both got some quality time in the sun,\n" +
                $"You're both pretty exhausted. {enemy.Name} ran away countless" +
                $"times so you spent most of your afternoon out chasing them." +
                $"What do you decide to do when you're done at the park?") ;
            _heroRepo.TakeDamage(hero.Energy);
            _enemyRepo.TakeDamage(enemy.Energy);

        }

        private void Pantry()
        {
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            Console.WriteLine("Drink up, Mommy! While you were hiding,\n" +
                "destruction occured. Juice, milk, eggs, and all were" +
                "dumped from the fridge to the floor. Happy cleaning."
               );
            _heroRepo.TakeDamage(hero.Energy);
        }

        private void ArtsCrafts()
        {
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            Console.WriteLine($"Choose a craft for {enemy.Name} :\n"  +
                $"1. Painting.\n" +
                $"2. Stringing beads.\n" +
                $"3. Chalk on the sidewalk.\n");
            var craftact = int.Parse(Console.ReadLine());

            HandleBattleInput(craftact);

        }

        private void HandleCraftInput(int craftact)
        {
            switch (craftact)
            {
                case 1:
                    Nap();
                    break;
                case 2:
                    Park();
                    break;
                case 3:
                    Pantry();
                    break;
                case 4:
                    ArtsCrafts();
                    break;
                case 5:
                    ShowHeroDetails();
                    ShowEnemyDetails();
                    break;
                default:
                    break;
            }
        }


    }
}