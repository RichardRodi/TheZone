using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAnomalousZone.NewFolder;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Encounters.PowerPlant
{
    internal class PowerPlantMaze : BaseEncounter
    {
        private GameManager _gameManager;

        public PowerPlantMaze(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public override void NextEncounter(Type encounterType)
        {
            _gameManager.Encounters.Where(x => x.GetType() == encounterType).FirstOrDefault().RunEncounter();
        }

        public override void RunEncounter()
        {
            string prompt = ($"Entering the vast structure of the PowerPlant,\n" +
                $"you are immediately met with an otherworldly sight:\n" +
                $"colossal chamber dominated by eerie still sand dunes.\n" +
                $"Towering pillars stretch towards the ceiling, arranged in rows, three deep.\n" +
                $"Passing through the center of these pillars,\n" +
                $"you venture into a dark hallway, only to emerge once more into the same room.\n" +
                $"With each attempt to navigate the space,\n" +
                $"it becomes clear that you are ensnared in a perplexing loop.\n" +
                $"Is there an escape from this confounding puzzle? Here's the layout of the room\n" +
                $" {TitleArtAssets.FloorPlan}" +
                $" ");

            string[] options = { "1.Play Game.", "2.Credits.", "3.Exit.", "4.Use FirstAid Kit.", "5.Check Stats." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:

                    break;

                case 1:

                    break;
                case 2:

                    break;
                case 3:
                    _gameManager.SelectedMainPlayer.Heal(_gameManager.Items[0].MinAmountToHeal, _gameManager.Items[0].MaxAmountToHeal);
                    Console.ReadKey(true);
                    RunEncounter();
                    break;
                case 4:
                    _gameManager.SelectedMainPlayer.DisplayStats();
                    Console.ReadKey(true);

                    RunEncounter();
                    break;
            }
        }
    }
}
