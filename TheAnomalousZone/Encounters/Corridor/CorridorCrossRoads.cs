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
            string prompt = ($"\n\tYou proceed toward the ominous valley. As you advance,\n" +
                $"\tyou encounter another branching path.\n" +
                $"\tContinuing straight ahead seems to be the shortest route to exit this valley,\n" +
                $"\tbut heading to your right may reveal unknown treasures that could aid you on your journey.\n\n");


            string[] options = { "1.Continue Down the Main Road.", "2.Head to your Right.", "3.Check Surroundings.", $"4.Use a FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "5.Check Player Stats." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();
            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine($"\n\tYou navigate the somewhat large road, now uneven and broken from the anomalous activities that have threatened the zone.\n");
                    Console.ReadKey(true);
                    NextEncounter(typeof(MainRoad));
                    break;

                case 1:
                    Console.WriteLine($"\n\tTaking a chance you head towards the sprawling factory like complex.\n");
                    Console.ReadKey(true);
                    NextEncounter(typeof(FactoryEntrance));
                    break;
                case 2:
                    Console.WriteLine($"\n\tPeering through the binoculars Strelock provided,\n" +
                        $"\tyou meticulously survey the valley ahead.\n" +
                        $"\tThe main road sprawls in disrepair,\n" +
                        $"\tAs you strain to focus on the road,\n" +
                        $"\ta flurry of movement catches your attention,\n" +
                        $"\tsmaller rodent like creatures fleeing from an unseen threat.\n" +
                        $"\tTo your right, a sprawling factory like complex looms,\n" +
                        $"\tits silhouette punctuated by the glow of man made campfires.");
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
