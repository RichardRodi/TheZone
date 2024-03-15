using System.Media;
using TheAnomalousZone.Encounters.Swamp;
using TheAnomalousZone.NewFolder;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Encounters
{
    public class IntroCharacterCreation 
    {
        private GameManager _gameManager;
        
        public IntroCharacterCreation(GameManager gameManager)
        {
            _gameManager = gameManager;
             RunGenerateMainCharacter();
        }
        public void RunGenerateMainCharacter()
        {

         string prompt = $"{StoryScript.IntroCharacterCreationPrompt}";

            string[] options = { "1.You were a Soldier.", "2.You were a Sniper.", "3.You were a Scientist.\n\n" };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("You remember were a Sergeant in the Army");
                    var selectedSoldier = _gameManager.AllMainCharacters.Where(x => x.Name == "Sergei").FirstOrDefault();
                    if(selectedSoldier is not null)
                        _gameManager.SelectedMainPlayer = selectedSoldier;
                    break;
                case 1:
                    Console.WriteLine("You remember you were a Mercenary Sniper");
                    var selectedSniper = _gameManager.AllMainCharacters.Where(x => x.Name == "Artyom").FirstOrDefault();
                    if (selectedSniper is not null)
                        _gameManager.SelectedMainPlayer = selectedSniper;
                   
                    break;
                case 2:
                    Console.WriteLine("You were a Scientist working for the Government");
                    var selectedScientist = _gameManager.AllMainCharacters.Where(x => x.Name == "Dimitri").FirstOrDefault();
                    if (selectedScientist is not null)
                        _gameManager.SelectedMainPlayer = selectedScientist;
                    Console.ReadKey();
                  
                    break;

            }

            Console.ResetColor();
        }

       

       
    }
}
