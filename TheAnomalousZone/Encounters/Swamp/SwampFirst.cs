using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.Swamp
{
    public class SwampFirst : BaseEncounter
    {
       
        
            public GameManager _gameManager;
            public SwampFirst()
            {

            }
            public SwampFirst(GameManager gameManager)
            {
                _gameManager = gameManager;
            }

            public override void RunEncounter()
            {
            // Encounter Logic //
            string prompt = ($"");

            string[] options = { "forward", "backwards", "left" };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                   Console.WriteLine("you walk forward");
                    break;

                case 1:
                    Console.WriteLine("you walk backwards");
                    break;
                case 2:
                    Console.WriteLine("you walk left");
                    break;
                    

            }
            if (selectedIndex == 1) 
            { 
               
            }
            if (selectedIndex == 2) 
            { 
                NextEncounter(typeof(DilapidatedBuilding)); 
            }
            
            // Run Next Encounter //

            // switch //

            // Based on results - output a specific encounter type //

            
            }

            public override void NextEncounter(Type type)
            {
                _gameManager.Encounters.Where(x => x.GetType() == type).FirstOrDefault().RunEncounter();
            }

    }
}
