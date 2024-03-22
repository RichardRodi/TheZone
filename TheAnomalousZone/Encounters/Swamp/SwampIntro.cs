using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.Swamp
{
    public class SwampIntro : BaseEncounter
    {
        private GameManager _gameManager;

        public SwampIntro(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public override void RunEncounter()
        {

            string prompt = ($"Surveying your surroundings, you find yourself standing at the heart of a crossroads,\n" +
                $"To your left, a small dilapidated building stands weathered and worn. \n" +
                $"Despite its decrepit appearance, the structure beckons with an air of intrigue,\n\n" +
                $"To your right, black smoke rises from the direction of a large warehouse,\n" +
                $"it's imposing silhouette looming ominously against the horizon. \n" +
                $"The source of the smoke remains unclear, casting doubt over the intentions of those who inhabit the structure.\n\n");

            string[] options = { "1.Head to your Left.", "2.Head to your Right.", "3.Look Around.", "4.Check Stats.\n\n" };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:

                    Console.WriteLine("As you cautiously advance down a muddy path, aided by makeshift bridges that span the damp terrain,\n" +
                        "each footfall echoes with the unmistakable squelch of mud under decaying wooden planks. \n" +
                        "Suddenly, a strange rustling breaks the silence, emanating from a nearby bush.\n" +
                        "Your heart races as you try to discern the source of the disturbance, your senses on high alert for any sign of danger.");
                    Console.ReadKey(true);
                    NextEncounter(typeof(DilapidatedBuilding));
                    break;
                case 1:

                    Console.WriteLine("As you navigate the murky path toward the makeshift camp, each step sinking into the soft mire beneath your feet,\n" +
                        "a commanding voice cuts through the damp silence, echoing across the swamp with an air of smugness and authority.");
                    Console.ReadKey(true);
                    NextEncounter(typeof(WareHouse));
                    break;
                case 2:
                    Console.WriteLine("As you around the vast and expansive swamp, the air is thick with moisture and the scent of decay,\n" +
                        "your gaze falls upon the scattered structures that emerge from the murky landscape. These remnants of civilization,\n" +
                        "once proud and sturdy, now stand as silent witnesses to the relentless march of time and nature's reclaiming embrace.");
                    Console.ReadKey(true);
                    RunEncounter();

                    break;
                case 3:
                    _gameManager.SelectedMainPlayer.DisplayStats();
                    Console.ReadKey(true);
                    RunEncounter();
                    break;

            }

            Console.ResetColor();
        }


        public override void NextEncounter(Type encounterType)
        {

            _gameManager.Encounters.Where(x => x.GetType() == encounterType).FirstOrDefault().RunEncounter();
            //    try
            //    {
            //        var nextEncounter = _gameManager.Encounters
            //            .Where(x => x.GetType() == encounterType)
            //            .FirstOrDefault();

            //        if (nextEncounter != null)
            //            nextEncounter.RunEncounter();
            //        else
            //        {
            //            // try to run a backup encounter //
            //            nextEncounter = _gameManager.Encounters
            //                .Where(x => x.GetType() == typeof(WareHouse))
            //                .FirstOrDefault();

            //            if (nextEncounter != null)
            //                nextEncounter.RunEncounter();
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Error with Message: {ex.Message}");
            //        Console.WriteLine($"Restarting Game");
            //        Console.ReadKey();
            //        _gameManager.RunGame();
            //    }
            //}

        }
    }
}
