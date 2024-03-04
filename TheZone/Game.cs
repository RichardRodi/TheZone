using TheZone.Menus;
using TheZone.Printer;

namespace TheZone
{
    public class Game
    {
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

        public void RunFirstChoice()
        {

            string prompt = $"\n\n Enveloped within the swirling vortex of a dream, you find yourself confronted by a towering presence: " +
                $"a Massive {GetColoredText.GetCyanText("Monolith")} stretches out before you." +
                $"Its surface emits a faint, rhythmic pulse that intensifies," +
                $"overwhelming your senses with a deafening roar. As the sound crescendos to an unbearable level," +
                $"you instinctively cover your ears, but find no relief, no air fills your lungs, no voice escapes your lips." +
                $"Darkness descends, and you awaken to the sensation of damp earth beneath you, face-down in a marsh." +
                $" The once-pervasive hum of the Monolith is replaced by the crackling static of your Geiger Meter.\n\n\n";


            string[] options = {"Turn off your geiger meter\n", "Keep your Geiger On and try to Walk towards a small structure a little ways away.\n", 
                "Check Inventory\n"};
            Menu firstChoiceMenu = new Menu(prompt, options);
            int selectedIndex = firstChoiceMenu.Run();
            switch(selectedIndex)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("You stagger blindly through the radioactive marsh,\n " +
                        "devoid of your Geiger Meter to guide your steps. Before long, you find yourself ensnared within a vast pool of irradiated liquid. " +
                        "Initially, a sense of lightheadedness grips you, followed by the unmistakable metallic tang upon your tongue. " +
                        "The world around you dims rapidly as consciousness slips away. In the end, darkness claims you—another casualty of The Zone.");
                    DeathMenu deathMenu = new DeathMenu();
                    deathMenu.DeathScreen();
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadKey(true);
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.RunMainMenu();
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("You walk carefully through the swamp as your avoid the areas that crackle from your Geiger Meter");
                    
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Here is your inventory");
                    break;

            }
            ExitGame();
        }
    }
}




