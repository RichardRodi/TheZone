using TheAnomalousZone.NewFolder;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Menus
{

    public class DeathMenu
    {
        public void RunEncounter()
        {

            string prompt = ($"\t\t\n\n\n You have Been:\n\n\n{TitleArtAssets.DeathHeader}\n\n\n");

            string[] options = { "1.Exit To Main Menu", "2.Exit Game" };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    GameManager mainMenu = new GameManager(true);
                    mainMenu.RunGame();
                    break;

                case 1:
                    Environment.Exit(0);
                    break;
                case 2:

                    break;

            }

            Console.ResetColor();
        }


    }

}

