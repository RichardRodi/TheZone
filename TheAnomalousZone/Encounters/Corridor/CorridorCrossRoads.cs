using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.Corridor
{
    internal class CorridorCrossRoads : BaseEncounter
    {
        private GameManager _gameManager;

        public CorridorCrossRoads(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public override void NextEncounter(Type encounterType)
        {
            _gameManager.Encounters.Where(x => x.GetType() == encounterType).FirstOrDefault().RunEncounter();
        }

        public override void RunEncounter()
        {
            string prompt = ($"\nLeaving the shop behind, you proceed toward the ominous valley. As you advance,\n" +
                $"you encounter another branching path. Continuing straight ahead seems to be the shortest route to exit this valley,\n" +
                $"but heading to your right may reveal unknown treasures that could aid you on your journey.\n\n");


            string[] options = { "1.Continue Down the Main Road.", "2.Head to your Right.", "3.Check Surroundings.", "4.Use FirstAid Kit.", "5.Check Stats." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();
            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine($"You navigate the somewhat large road, now uneven and broken from the anomalous activities that have threatened the zone.\n");
                    Console.ReadKey();
                    NextEncounter(typeof(MainRoad));
                    break;

                case 1:
                    Console.WriteLine($"Realizing the indirect path might be your best option you head to your right\n");
                    Console.ReadKey();
                    NextEncounter(typeof(FactoryEntrance));
                    break;
                case 2:
                    Console.WriteLine($"Peering through the binoculars Strelock provided, you survey the valley ahead.\n" +
                        $"The main road lies in disrepair, and amidst the chaos, a sizable group of creatures rushes forward,\n" +
                        $"some disappearing into an unknown vortex. As you adjust your gaze to the right, factory-like structures emerge,\n" +
                        $"one adorned with a conspicuous satellite dish. Straining to see beyond the valley,\n" +
                        $"your gaze catches a towering structure on the horizon.\n" +
                        $"A colossal structure topped with a towering smokestack dominates the landscape.\n" +
                        $"As you train your binoculars on the spire,\n" +
                        $"a pulsating hum reminiscent of the Monolith reverberates through your skull,\n" +
                        $"threatening to cleave it in two.\n" +
                        $"With a shudder, you avert your eyes, seeking relief from the unsettling sensation");
                    Console.Read();
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
                    Console.Clear();
                    RunEncounter();
                    break;
            }

        }
    }
}
