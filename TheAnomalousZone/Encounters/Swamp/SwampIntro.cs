using TheAnomalousZone.MainCharacter;
using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.Swamp
{
    public static class SwampIntro
    {
        public static void RunEncounter(MainPlayer player)

        {


            GameManager gameManager = new GameManager();
            gameManager.GenerateAllEnemies();


            string prompt = ($"Looking Around you realize that you are standing in the middle of a crossroads.\n" +
                $"To your left is a small dilapidated building.\n" +
                $"To your right smoke rises up from what appears to a makeshift camp\n");

            string[] options = { "Head to your Left", "Head to your Right", "Look Around", "Check Stats" };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:

                    Console.WriteLine("You start to head towards the dilapidated building when you hear a rustling in a nearby bush");
                    WildBoarEncounter.RunEncounter(player);
                    break;
                case 1:

                    Console.WriteLine("You start to head towards the makeshift camp when you hear a voice call out to you in a commanding voice");
                    break;
                case 2:
                    Console.WriteLine("You see a vast and expansive swamp");
                    Console.ReadKey(true);
                    SwampIntro.RunEncounter(player);
                    break;
                case 3:
                    player.DisplayStats();
                    Console.ReadKey(true);
                    SwampIntro.RunEncounter(player);
                    break;

            }

            Console.ResetColor();
        }
    }
}
