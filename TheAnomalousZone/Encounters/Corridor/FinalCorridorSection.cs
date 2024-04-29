using TheAnomalousZone.Encounters.PowerPlant;
using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.Corridor
{
    internal class FinalCorridorSection : BaseEncounter
    {
        private GameManager _gameManager;

        public FinalCorridorSection(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public override void NextEncounter(Type encounterType)
        {
            _gameManager.Encounters.Where(x => x.GetType() == encounterType).FirstOrDefault().RunEncounter();
        }
        public int armorMod;
        public int weaponMod;
        public int firstAidMod;
        public int ammunitionMod;
        public override void RunEncounter()
        {
            {
                armorMod = 5000;
                weaponMod = 4000;
                firstAidMod = 1000;
                ammunitionMod = 6000;

                string prompt = ($"\nApproaching the end of the winding valley, your gaze is drawn to a colossal,\n" +
                    $"crumbling structure ahead. With curiosity piqued,\n" +
                    $"you raise your binoculars to gain a closer look at the figures milling about.\n" +
                    $"As their features come into focus,\n" +
                    $"you recognize the familiar uniforms worn by the individuals you encountered at the shop earlier.\n" +
                    $"Reassured by their friendly attire, you move closer to greet them.\n" +
                    $"You are welcomed by an experienced group of zone denizens.\n" +
                    $"Their leader bellows out in a loud, booming voice,\n" +
                    $"Hello, friend! If you've made it this far, you're trying to get to the Wish Giver/The Monolith.\n" +
                    $"If you're going to make it, you have to fight those freaks that worship the Monolith as their god.\n" +
                    $"You're going to need some supplies, so take a look.\n\n");

                string[] options = {"1.Buy Ceramic Plates for your Armor\n \t - Armor + 5 - 5000 Rubles", "2.Buy Custom parts for your Weapon\n \t - WeaponValue + 8 - 4000 Rubles",
                    "3.Buy Bandit Chest Rig\n \t- Ammunition + 2 - 6000 Rubles", "4.Buy First Aid Kit\n \t - 1000 Rubles",$"5.Use a FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "6.Check Player Stats", "7.Leave Shop"};
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:

                        if (_gameManager.SelectedMainPlayer.Rubles >= armorMod)
                        {
                            _gameManager.SelectedMainPlayer.Rubles -= armorMod;
                            _gameManager.SelectedMainPlayer.ArmorValue += 5;
                            Console.WriteLine("Armor increased by 5!");
                            Console.ReadKey();
                            RunEncounter();
                        }
                        else
                        {
                            Console.WriteLine("Not Enough Money");
                            Console.ReadKey();
                            RunEncounter();
                        }

                        break;

                    case 1:

                        if (_gameManager.SelectedMainPlayer.Rubles >= weaponMod)
                        {
                            _gameManager.SelectedMainPlayer.Rubles -= weaponMod;
                            _gameManager.SelectedMainPlayer.WeaponValue += 3;
                            Console.WriteLine("Weapon value increased by 3!");
                            Console.ReadKey();
                            RunEncounter();

                        }
                        else
                        {
                            Console.WriteLine("Not Enough Money");
                            Console.ReadKey();
                            RunEncounter();
                        }
                        break;
                    case 2:
                        if (_gameManager.SelectedMainPlayer.Rubles >= ammunitionMod)
                        {
                            _gameManager.SelectedMainPlayer.Rubles -= ammunitionMod;
                            _gameManager.SelectedMainPlayer.Ammunition += 2;
                            Console.WriteLine("Ammunition per magazine increased by 2!");
                            Console.ReadKey();
                            RunEncounter();
                        }
                        else
                        {
                            Console.WriteLine("Not Enough Money");
                            Console.ReadKey();
                            RunEncounter();
                        }

                        break;
                    case 3:
                        if (_gameManager.SelectedMainPlayer.Rubles >= firstAidMod)
                        {
                            if (_gameManager.SelectedMainPlayer.Rubles >= firstAidMod)
                                _gameManager.SelectedMainPlayer.Rubles -= 1000;
                            _gameManager.SelectedMainPlayer.FirstAid += 1;
                            Console.WriteLine("First Aid Added to your Inventory!");
                            Console.ReadKey();
                            RunEncounter();
                        }
                        else
                        {
                            Console.WriteLine("Not Enough Money");
                            Console.ReadKey();
                            RunEncounter();
                        }

                        break;
                    case 4:
                        _gameManager.SelectedMainPlayer.Heal(_gameManager.Items[0].MinAmountToHeal, _gameManager.Items[0].MaxAmountToHeal);
                        Console.ReadKey(true);
                        RunEncounter();
                        break;
                    case 5:

                        _gameManager.SelectedMainPlayer.DisplayStats();
                        Console.ReadKey(true);
                        RunEncounter();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("As you prepare to depart, the leader of the friendlies steps forward,\n" +
                            "offering you some parting advice.\n" +
                            "'You are entering unknown territory, friend,' he cautions, their voice tinged with solemnity. \n" +
                            "'Not many have made it this far. We would go further, but no one has come back from where you're headed.\n" +
                            "He throws you an awkward helmet." +
                            "Upon further inspection you realize that there night vision goggles on them'" +
                            "'Good luck!', he yells out as stride out of the encampment\n" +
                            "With those words echoing in your mind,\n" +
                            "you steel yourself for the challenges that lie ahead,\n" +
                            "grateful for their warning and help as you venture into uncharted territory.");
                        Console.ReadKey();
                        NextEncounter(typeof(PowerPlantHallway));
                        break;

                }
            }
        }
    }
}
