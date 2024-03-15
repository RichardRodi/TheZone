using TheAnomalousZone.Combat;
using TheAnomalousZone.MainCharacter;
using TheAnomalousZone.NewFolder;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Encounters.Swamp
{
    public class DilapidatedBuilding : BaseEncounter
    {
        private GameManager _gameManager;

        public DilapidatedBuilding(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public override void RunEncounter()

        {
            GameManager gameManager = new GameManager();
            gameManager.GenerateAllEnemies();
            string prompt = ($"\n\nYou are faced with a snarling Boar. What do you do?\n\n");

            string[] options = { "1.Raise you rifle to fire at it!", "2.Run!", "3.Take a Closer look at the Boar" };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("You raise your Rifle and at the wild boar");
                    Console.ReadKey(true);
                    PlayerFirstCombat.Fight(_gameManager.SelectedMainPlayer, _gameManager.Enemies[3]);
                    break;

                case 1:
                    Console.WriteLine("You attempt to run away from the Boar");
                    bool getAway = RunAway.Run(_gameManager.SelectedMainPlayer, _gameManager.Enemies[3]);
                    if (!getAway)
                    {
                        Console.WriteLine("You Failed To Get Away");
                        Console.ReadKey(true);
                        EnemyFirstCombat.Fight(_gameManager.SelectedMainPlayer, _gameManager.Enemies[3]);
                    }

                    else
                    {
                        Console.WriteLine("You Got Away!");
                        Console.ReadKey(true);
                       
                    }
                    break;
                case 2:
                    Console.WriteLine("You inspect the boar");
                    gameManager.Enemies[3].DisplayStats();
                    SlowPrint.Print("While you took time inspecting the boar it decides its had enough and lunges at you");
                    EnemyFirstCombat.Fight(_gameManager.SelectedMainPlayer, _gameManager.Enemies[3]);
                    break;

            }

        }
        

        

        public override void NextEncounter(Type encounterType)
        {
            throw new NotImplementedException();
        }
    }
}
