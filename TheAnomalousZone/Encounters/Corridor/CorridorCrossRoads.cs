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


            string[] options = { "1.Continue Down the Main Road.", "2.Head to your Right.", "3.Check Surroundings.", $"4.Use a FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "5.Check Player Stats." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();
            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine($"\nYou navigate the somewhat large road, now uneven and broken from the anomalous activities that have threatened the zone.\n");
                    Console.ReadKey(true);
                    NextEncounter(typeof(MainRoad));
                    break;

                case 1:
                    Console.WriteLine($"\nTaking a chance you head towards the sprawling factory like complex.\n");
                    Console.ReadKey(true);
                    NextEncounter(typeof(FactoryEntrance));
                    break;
                case 2:
                    Console.WriteLine($"\nPeering through the binoculars Strelock provided,\n" +
                        $"you meticulously survey the valley ahead.\n" +
                        $"The main road sprawls in disrepair,\n" +
                        $"As you strain to focus on the road,\n" +
                        $"a flurry of movement catches your attention,\n" +
                        $"smaller rodent like creatures fleeing from an unseen threat.\n" +
                        $"To your right, a sprawling factory like complex looms,\n" +
                        $"its silhouette punctuated by the glow of man made campfires.");
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
