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
        
        public override void RunEncounter()
        {
            {

                string prompt = ($"\nApproaching the end of the winding valley, your gaze is drawn to a colossal,\n" +
                    $"crumbling structure ahead. With curiosity piqued,\n" +
                    $"you raise your binoculars to gain a closer look at the figures milling about.\n" +
                    $"You recognize the familiar uniforms worn by the individuals you encountered at the shop earlier.\n" +
                    $"Reassured by their friendly attire, you move closer to greet them.\n" +
                    $"The leader of this group bellows out in a loud, booming voice,\n" +
                    $"Hello, friend! If you've made it this far, you're trying to get to the The Monolith.\n" +
                    $"If you're going to make it, you have to fight those freaks that worship the Monolith as their god.\n" +
                    $"You're going to need some supplies, so take a look.\n");

                string[] options = {"1.Buy Plates for your Armor\n Armor + 5 - 5000 Rubles", "2.Buy Custom parts for your Weapon\n Weapon Damage + 8 - 4000 Rubles",
                    "3.Buy Bandit Chest Rig\n Ammunition + 2 - 3000 Rubles", "4.Buy First Aid Kit.\n 1000 Rubles",$"5.Use FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "6.Check Stats.", "7.Leave Shop."};
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:

                        if (_gameManager.SelectedMainPlayer.Rubles >= _gameManager.Items[2].Price)
                        {
                            _gameManager.SelectedMainPlayer.Rubles -= _gameManager.Items[2].Price;
                            _gameManager.SelectedMainPlayer.ArmorValue += 5;
                            Console.WriteLine("\nArmor increased by 5!");
                            Console.ReadKey(true);
                            RunEncounter();
                        }
                        else
                        {
                            Console.WriteLine("\nNot Enough Money");
                            Console.ReadKey(true);
                            RunEncounter();
                        }

                        break;

                    case 1:

                        if (_gameManager.SelectedMainPlayer.Rubles >= _gameManager.Items[3].Price)
                        {
                            _gameManager.SelectedMainPlayer.Rubles -= _gameManager.Items[3].Price;
                            _gameManager.SelectedMainPlayer.WeaponValue += 8;
                            Console.WriteLine("\nWeapon Damage increased by 8!");
                            Console.ReadKey(true);
                            Console.Clear();
                            RunEncounter();

                        }
                        else
                        {
                            Console.WriteLine("\nNot Enough Money");
                            Console.ReadKey(true);
                            Console.Clear();
                            RunEncounter();
                        }
                        break;
                    case 2:
                        if (_gameManager.SelectedMainPlayer.Rubles >= _gameManager.Items[4].Price)
                        {
                            _gameManager.SelectedMainPlayer.Rubles -= _gameManager.Items[4].Price;
                            _gameManager.SelectedMainPlayer.Ammunition += 2;
                            Console.WriteLine("\nAmmunition per magazine increased by 2!");
                            Console.ReadKey(true);
                            Console.Clear();
                            RunEncounter();
                        }
                        else
                        {
                            Console.WriteLine("\nNot Enough Money");
                            Console.ReadKey(true);
                            Console.Clear();
                            RunEncounter();
                        }

                        break;
                    case 3:


                        if (_gameManager.SelectedMainPlayer.Rubles >= _gameManager.Items[0].Price)
                        {
                            _gameManager.SelectedMainPlayer.Rubles -= _gameManager.Items[0].Price;
                            _gameManager.SelectedMainPlayer.FirstAid += 1;
                            Console.WriteLine("\nFirst Aid Added to your Inventory!");
                            Console.ReadKey(true);
                            Console.Clear();
                            RunEncounter();
                        }
                        else
                        {
                            Console.WriteLine("\nNot Enough Money");
                            Console.ReadKey(true);
                            Console.Clear();
                            RunEncounter();
                        }

                        break;
                    case 4:
                        _gameManager.SelectedMainPlayer.Heal(_gameManager.Items[0].MinAmountToHeal, _gameManager.Items[0].MaxAmountToHeal);
                        Console.ReadKey(true);
                        Console.Clear();
                        RunEncounter();
                        break;
                    case 5:
                        _gameManager.SelectedMainPlayer.DisplayStats();
                        Console.ReadKey(true);
                        Console.Clear();
                        RunEncounter();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("\nAs you prepare to depart, the leader of the friendlies steps forward,\n" +
                            "offering you some parting advice.\n" +
                            "'You are entering unknown territory, friend,' he cautions, their voice tinged with solemnity. \n" +
                            "'Not many have made it this far. We would go further, but no one has come back from where you're headed.\n" +
                            "He throws you an awkward helmet.\n" +
                            "Upon further inspection you realize that there night vision goggles on them'\n" +
                            "'Good luck!', he yells out as stride out of the encampment\n" +
                            "With those words echoing in your mind,\n" +
                            "you steel yourself for the challenges that lie ahead.\n"); 
                        Console.ReadKey(true);
                        Console.Clear();
                        NextEncounter(typeof(PowerPlantHallway));
                        break;

                }
            }
        }
    }
}
