using TheZone.Enemies;
using TheZone.Menus;
using TheZone.NewFolder;
using TheZone.Printer;
using TheZone.MainPlayers;
namespace TheZone
{
    public class Game
    {
        public MainPlayer MainPlayer { get; set; }
        public void RunGame()
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.RunMainMenu();
            
        }

        public void ExitGame()
        {
            Console.WriteLine("\n Press Enter to Exit");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
        public void DisplayCreditInfo()
        {

            Console.WriteLine("Created by Richard Rodi");
            Console.ReadKey(true);
            MainMenu mainMenu = new MainMenu();
            mainMenu.RunMainMenu();
        }

        
        
    }
}




