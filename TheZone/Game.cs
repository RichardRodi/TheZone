using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZone.Printer;

namespace TheZone
{
    public class Game
    {
        public static void RunGame()

        {

            Console.WriteLine("Hello");
            //var keyPressed = Console.ReadKey();
            //if (keyPressed.Key == ConsoleKey.Enter)
            //{
            //    Console.WriteLine("You pressed enter");

            //}
            //else if (keyPressed.Key == ConsoleKey.UpArrow)
            //{
            //    Console.WriteLine("You Pressed the up arrow!");
            //}    

            //else
            //{
            //    Console.WriteLine("you pressed an other key");
            //}
            char radiationSymbol = '\u2622';
            string prompt = $"\t{radiationSymbol}{radiationSymbol}{radiationSymbol} Welcome to the {radiationSymbol}{radiationSymbol}{radiationSymbol}\n\t " +
                $"{ArtAssets.GameHeader}\n\n\n\n";
            string[] options = { "Play", "Credits", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();
            
            {
                Console.BackgroundColor = ConsoleColor.Black;
                
                mainMenu.DislpayOptions();
            }
        }
    }
}

