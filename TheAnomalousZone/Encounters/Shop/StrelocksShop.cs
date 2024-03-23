using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.Shop
{
    public class StrelocksShop : BaseEncounter
    {
        private GameManager _gameManager;

        public StrelocksShop(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public override void NextEncounter(Type encounterType)
        {
            throw new NotImplementedException();
        }
        public int armorMod;
        public int weaponMod;
        public int firstAidMod;
        public int ammunitionMod;
        public override void RunEncounter()
        {
            armorMod = 5000;
            weaponMod = 4000;
            firstAidMod = 1000;
            ammunitionMod = 6000;

            //_gameManager.SelectedMainPlayer.FirstAid;
            //_gameManager.SelectedMainPlayer.ArmorValue;
            //_gameManager.SelectedMainPlayer.WeaponValue;
            //_gameManager.SelectedMainPlayer.Ammunition;
            {
                string prompt = ($"You make your way down to the rustic village,\n" +
                    $"where a few people keep watch, their demeanor nonviolent yet vigilant.\n" +
                    $"They bear similar gear and weapons, hinting at a shared purpose and allegiance.\n" +
                    $"Navigating through the small settlement while following the shop signs,\n" +
                    $"you eventually find yourself standing before an old Cold War bunker,\n" +
                    $"its entrance concealed within the earth. A neon sign above reads Strelock's Shop.\n" +
                    $"With a sense of anticipation, you step into the store.\n" +
                    $"Inside, you are greeted by an older man,\n" +
                    $"his face weathered by the passage of time and marked by the effects of a life lived hard.\n" +
                    $"Despite his gruff exterior, he welcomes you with a booming voice,\n" +
                    $"urging you to enter and explore his wares.\n\n");

                string[] options = {"Buy Ceramic Plates for your Armor\n - Armor + 5 - 5000 Rubles", "Buy Custom parts for your Weapon\n - WeaponValue + 8 - 4000 Rubles",
                    "Buy Bandit Chest Rig\n - Ammunition + 2 - 6000 Rubles", "Buy First Aid Kit\n - 1000 Rubles", "Check Stats", "Leave Shop"};
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
                            _gameManager.SelectedMainPlayer.WeaponValue += 8;
                            Console.WriteLine("Weapon value increased by 8!");
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
                        if (_gameManager.SelectedMainPlayer.Rubles >= firstAidMod)
                        {
                            _gameManager.SelectedMainPlayer.Rubles -= firstAidMod;
                            _gameManager.SelectedMainPlayer.FirstAid += 1;
                            Console.ReadKey();
                            RunEncounter();
                        }

                        break;
                    case 5:

                        _gameManager.SelectedMainPlayer.DisplayStats();

                        break;
                    case 6:
                        Console.WriteLine("'Thank you for your service', Who you assume to be Strelock says,\n" +
                            "his words carrying a weight of understanding. 'But I can see it in your eyes. \n" +
                            "The call of the WishGiver. That towering monolith beckons to you,\n" +
                            "tempting you with untold riches, or perhaps infinite knowledge or power'\n" +
                            "He pauses, his gaze piercing yet compassionate.\n" +
                            "'Be wary, for wishes are seldom what you actually want.'\n" +
                            "'But who am I to tell a man not to follow his heart?' Good luck out there, friend.\n" +
                            "With his words echoing in your mind, you step out of Strelock's shop, ready to face the challenges ahead.");
                        Console.WriteLine($"MORE TO GAME TO COME!");
                        GameManager mainMenu = new GameManager(true);
                        mainMenu.RunGame();
                        break;

                }

            }
        }
    }
}
