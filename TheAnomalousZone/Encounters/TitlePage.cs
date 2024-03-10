using TheAnomalousZone.NewFolder;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Encounters
{
    public class TitlePage
    {
        public void RunMainMenu()

        {
            //GameManager gameManager = new GameManager();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string radiationSymbol = "\u2622";


            string prompt = ($"\n\t\t\t\t    {radiationSymbol}  {radiationSymbol}  {radiationSymbol}   Welcome To  {radiationSymbol}  {radiationSymbol}  {radiationSymbol}\n\t\n\n " +
                $"{TitleArtAssets.GameHeader}\n\n\n\n Use Arrow Keys and Enter to Select Options: \n\n\n");

            string[] options = { "Play Game", "Credits", "Exit" };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    IntroCharacterCreation.RunEncounter();
                    break;

                case 1:
                    Console.WriteLine("Created by Richard Rodi");
                    break;
                case 2:
                    Environment.Exit(0);
                    break;

            }
            
            Console.ResetColor();
        }
    }
}
