using TheAnomalousZone.Combat;
using TheAnomalousZone.NewFolder;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Encounters.Swamp
{
    public class WareHouse : BaseEncounter
    {
        private GameManager _gameManager;

        public WareHouse(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public override void RunEncounter()

        {

            string prompt = ($"\n\nAs you approach the source of the voice when you realize you are surrounded by a group of men\n" +
                $"The man who is speaking you seems to be their leader.\n" +
                $"In a snarled voice he politely asks you to empty your pockets and be on your way\n\n");

            string[] options = { "1.Raise you rifle at the Bandit Leader!", "2.Run!", "3.Take a Closer look at the Bandit" };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("Without hesitating you raise your rifle to the bandit leader. With a loud deafening thud you begin to fire at him");
                    Console.ReadKey(true);
                    Console.Clear();
                    EnemyFirstBanditCombat.Fight(_gameManager.SelectedMainPlayer, _gameManager.Enemies[1]);

                    break;

                case 1:
                    Console.WriteLine("You attempt to run away from the Boar");
                    bool getAway = RunAway.Run(_gameManager.SelectedMainPlayer, _gameManager.Enemies[1]);
                    if (!getAway)
                    {
                        Console.WriteLine("You Failed To Get Away");
                        Console.ReadKey(true);
                        Console.Clear();
                        EnemyFirstBanditCombat.Fight(_gameManager.SelectedMainPlayer, _gameManager.Enemies[1]);
                        Console.ReadKey(true);

                    }

                    else
                    {
                        Console.WriteLine("You Got Away!");
                        Console.ReadKey(true);

                    }
                    break;
                case 2:
                    Console.WriteLine("You take a closer look at the bandit");
                    _gameManager.Enemies[1].DisplayStats();
                    SlowPrint.Print("While you took your time inspecting the bandit leader he quietly unclicks the safety on his rifle and begins to fire at you");
                    Console.Clear();
                    EnemyFirstBanditCombat.Fight(_gameManager.SelectedMainPlayer, _gameManager.Enemies[1]);
                    Console.ReadKey(true);

                    break;

            }

        }

        public override void NextEncounter(Type encounterType)
        {
            throw new NotImplementedException();
        }


    }
}

