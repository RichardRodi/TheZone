using TheAnomalousZone.Combat;
using TheAnomalousZone.MainCharacter;
using TheAnomalousZone.NewFolder;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Encounters.Swamp
{
    public class DilapidatedBuilding : BaseEncounter
    {
        private GameManager gameManager;

        public DilapidatedBuilding(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        public void RunEncounter(MainPlayer player)

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
                    PlayerFirstCombat.Fight(player, gameManager.Enemies[3]);
                    break;

                case 1:
                    Console.WriteLine("You attempt to run away from the Boar");
                    bool getAway = RunAway.Run(player, gameManager.Enemies[3]);
                    if (!getAway)
                    {
                        Console.WriteLine("You Failed To Get Away");
                        Console.ReadKey(true);
                        EnemyFirstCombat.Fight(player, gameManager.Enemies[3]);
                    }

                    else
                    {
                        Console.WriteLine("You Got Away!");
                        Console.ReadKey(true);
                        RunEncounterRunAway(player);
                    }
                    break;
                case 2:
                    Console.WriteLine("You inspect the boar");
                    gameManager.Enemies[3].DisplayStats();
                    SlowPrint.Print("While you took time inspecting the boar it decides its had enough and lunges at you");
                    EnemyFirstCombat.Fight(player, gameManager.Enemies[3]);
                    break;

            }

        }
        public static void RunEncounterRunAway(MainPlayer player)

        {
            GameManager gameManager = new GameManager();
            gameManager.GenerateAllEnemies();
            string prompt = ($"You decide to flee the Boar without attempting to get hurt\n" +
                $"You are approaching the dilapidated building. \n" +
                $"Reaching the Small building you notice something in the ruins\n");

            string[] options = { "1.Search the ruins of the small building", "2.Continue on", "Take a Closer look at the Boar" };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("You raise your Rifle and at the wild boar");
                    PlayerFirstCombat.Fight(player, gameManager.Enemies[3]);
                    break;

                case 1:
                    Console.WriteLine("You attempt to run away from the Boar");
                    bool getAway = RunAway.Run(player, gameManager.Enemies[3]);
                    if (!getAway)
                    {
                        Console.WriteLine("You Failed To Get Away");
                        EnemyFirstCombat.Fight(player, gameManager.Enemies[3]);
                    }

                    else
                    {
                        Console.WriteLine("You Got Away!");
                    }
                    break;
                case 2:
                    Console.WriteLine("You inspect the boar");
                    gameManager.Enemies[3].DisplayStats();
                    break;

            }

        }
        public static void RunEncounterBoarIsKilled(MainPlayer player)

        {
            GameManager gameManager = new GameManager();
            gameManager.GenerateAllEnemies();
            string prompt = ($"After you kill the boar you approach the dilapidated building\n" +
                $" \n" +
                $"Reaching the Small building you notice something in the ruins\n");

            string[] options = { "1.Search the ruins of the small building", "2.Continue on", "3.Take a Look at the surrounding area" };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("You raise your Rifle and at the wild boar");
                    PlayerFirstCombat.Fight(player, gameManager.Enemies[3]);
                    break;

                case 1:
                    Console.WriteLine("You attempt to run away from the Boar");
                    bool getAway = RunAway.Run(player, gameManager.Enemies[3]);
                    if (!getAway)
                    {
                        Console.WriteLine("You Failed To Get Away");
                        EnemyFirstCombat.Fight(player, gameManager.Enemies[3]);
                    }

                    else
                    {
                        Console.WriteLine("You Got Away!");
                    }
                    break;
                case 2:
                    Console.WriteLine("You inspect the boar");
                    gameManager.Enemies[3].DisplayStats();
                    break;

            }

        }

        public override void RunEncounter()
        {
            throw new NotImplementedException();
        }

        public override void NextEncounter(Type encounterType)
        {
            throw new NotImplementedException();
        }
    }
}
