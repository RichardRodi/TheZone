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
                string prompt = ($"\n\nHello welcome to Strelock's Shop!\n\n");

                string[] options = {"Buy Ceramic Plates for your Armor\n - Armor + 5 - 5000 Rubles", "Buy Custom parts for your Weapon\n - WeaponValue + 8 - 4000 Rubles",
                    "Buy Bandit Chest Rig\n - Ammunition + 2 - 6000 Rubles", "Buy First Aid Kit\n - Heals 30 Health - 1000 Rubles", "Check Stats"};
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:

                        if (_gameManager.SelectedMainPlayer.Rubles >= armorMod)
                        {
                            _gameManager.SelectedMainPlayer.Rubles -= armorMod;
                            _gameManager.SelectedMainPlayer.ArmorValue += 5;
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
                        if (_gameManager.SelectedMainPlayer.Rubles >= ammunitionMod)
                        {
                            _gameManager.SelectedMainPlayer.Rubles -= ammunitionMod;
                            _gameManager.SelectedMainPlayer.Ammunition += 2;
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

                }

            }
        }
    }
}
