using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZone.Encounters;
using TheZone.Printer;

namespace TheZone.Menus
{
    public class MainMenu
    {
        public void RunMainMenu()
        {
           
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string radiationSymbol = "\u2622";


            string prompt = $"\n\t\t\t\t{radiationSymbol}  {radiationSymbol}  {radiationSymbol}   Welcome To  {radiationSymbol}  {radiationSymbol}  {radiationSymbol}\n\t\n\n " +
                $"{ArtAssets.GameHeader}\n\n\n\n Use Arrow Keys and Enter to Select Options \n\n\n";

            string[] options = { "Play", "Credits", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();
            FirstEncounter newGame = new FirstEncounter();
            Game game = new Game();
            switch (selectedIndex)
            {
                case 0:
                    newGame.RunFirstChoice();
                    break;
                case 1:
                    game.DisplayCreditInfo();
                    break;
                case 2:
                    game.ExitGame();
                    break;

            }
            mainMenu.DislpayOptions();
            Console.ResetColor();
        }
    }
}
