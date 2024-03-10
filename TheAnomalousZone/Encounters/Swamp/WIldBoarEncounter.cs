using TheAnomalousZone.Combat;
using TheAnomalousZone.Enemies;
using TheAnomalousZone.MainCharacter;
using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.Swamp
{
    public static class WildBoarEncounter
    {
        public static void RunEncounter(MainPlayer player)

        {
            GameManager gameManager = new GameManager();
            gameManager.GenerateAllEnemies();
            string prompt = ($"You are faced with a snarling Boar. What do you do?");

            string[] options = { "Raise you rifle to fire at it!", "Run!", "Take a Closer look at the Boar"};
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

            Console.ResetColor();
        }
    }
}
