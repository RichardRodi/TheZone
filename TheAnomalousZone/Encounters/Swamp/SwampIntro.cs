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

            string prompt = ($"\n\tSurveying your surroundings, you find yourself standing at the heart of a crossroads,\n" +
                $"\tTo your left, a small dilapidated building stands weathered and worn. \n" +
                $"\tDespite its decrepit appearance, the structure beckons with an air of intrigue,\n\n" +
                $"\tTo your right, black smoke rises from the direction of a large warehouse,\n" +
                $"\tit's imposing silhouette looming ominously against the horizon. \n" +
                $"\tThe source of the smoke remains unclear,\n" +
                $"\tcasting doubt over the intentions of those who inhabit the structure.\n\n");

            string[] options = { "1.Head to your Left.", "2.Head to your Right.", "3.Look Around.", $"4.Use FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", $"5.Check Player Stats." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:

                    Console.WriteLine("\n\tAs you cautiously advance down a muddy path,\n" +
                        "\taided by makeshift bridges that span the damp terrain,\n" +
                        "\teach footfall echoes with the unmistakable squelch of mud under decaying wooden planks\n" +
                        "\tSuddenly, a strange rustling breaks the silence, emanating from a nearby bush.\n" +
                        "\tYour heart races as you try to discern the source of the disturbance,\n" +
                        "\tyour senses on high alert for any sign of danger.");
                    Console.ReadKey(true);
                    NextEncounter(typeof(DilapidatedBuilding));
                    break;
                case 1:

                    Console.WriteLine("\n\tAs you navigate the murky path toward the makeshift camp,\n" +
                        "\teach step sinking into the soft mire beneath your feet,\n" +
                        "\ta commanding voice cuts through the damp silence,\n" +
                        "\techoing across the swamp with an air of smugness and authority.");
                    Console.ReadKey(true);
                    NextEncounter(typeof(WareHouse));
                    break;
                case 2:
                    Console.WriteLine("\n\tAs you look around the vast and expansive swamp,\n" +
                        "\tthe air is thick with moisture and the scent of decay,\n" +
                        "\tyour gaze falls upon the scattered structures that emerge from the murky landscape.\n" +
                        "\tThese remnants of civilization,\n" +
                        "\tonce proud and sturdy,\n" +
                        "\tnow stand as silent witnesses to the relentless march of time and nature's reclaiming embrace.");
                    Console.ReadKey(true);
                    RunEncounter();

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

            Console.ResetColor();
        }


        public override void NextEncounter(Type encounterType)
        {

            _gameManager.Encounters.Where(x => x.GetType() == encounterType).FirstOrDefault().RunEncounter();

        }
    }
}
