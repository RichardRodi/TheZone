using TheAnomalousZone.Encounters.Swamp;
using TheAnomalousZone.NewFolder;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Encounters
{
    public class TitlePage 
    {
        public GameManager _gameManager;

        public TitlePage(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public TitlePage()
        {

        }

       
       

        public bool RunTitlePage()
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string radiationSymbol = "\u2622";

            string prompt = ($"\n\t\t\t\t    {radiationSymbol}  {radiationSymbol}  {radiationSymbol}   Welcome To  {radiationSymbol}  {radiationSymbol}  {radiationSymbol}\n\t\n\n " +
                $"{TitleArtAssets.GameHeader}\n\n\n Use Arrow Keys and Enter to Select Options: \n\n\n");

            string[] options = { "Play Game", "Credits", "Exit" };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    return true;
                    
                case 1:
                    Console.WriteLine("Created by Richard Rodi");
                    Console.ReadKey();
                    RunTitlePage();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
           
            Console.ResetColor();
            return false;
        }

    }
}
