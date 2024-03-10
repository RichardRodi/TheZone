using TheAnomalousZone.Encounters.Swamp;
using TheAnomalousZone.NewFolder;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Encounters
{
    public static class IntroCharacterCreation
    {
        public static void RunEncounter()

        {
            GameManager gameManager = new GameManager();
            gameManager.GenerateMainCharacter();
            gameManager.GenerateAllEnemies();

            string prompt = $"{StoryScript.IntroCharacterCreationPrompt}";

            string[] options = { "1.You were a Soldier.", "2.You were a Sniper.", "3.You were a Scientist." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("You remember were a Sergeant in the Army\n");
                    var mainPlayerSoldier = gameManager.MainCharacter[0];
                    Console.ReadKey(true);
                    SwampIntro.RunEncounter(mainPlayerSoldier);
                    Console.ReadKey(true);
                    break;
                case 1:
                    Console.WriteLine("You remember you were a Mercenary Sniper");
                    var mainPlayerSniper = gameManager.MainCharacter[1];
                    Console.ReadKey(true);
                    SwampIntro.RunEncounter(mainPlayerSniper);
                    break;
                case 2:
                    Console.WriteLine("You were a Scientist working for the Government");
                    var mainPlayerScientist = gameManager.MainCharacter[2];
                    Console.ReadKey(true);
                    SwampIntro.RunEncounter(mainPlayerScientist);

                    break;

            }

            Console.ResetColor();
        }
    }
}
