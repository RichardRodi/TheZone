using TheAnomalousZone.Combat;
using TheAnomalousZone.Encounters.Shop;
using TheAnomalousZone.NewFolder;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Encounters.Swamp
{
    public class WareHouse : BaseEncounter
    {
        private GameManager _gameManager;

        public WareHouse(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public override void RunEncounter()

        {

            string prompt = ($"\n\nAs you approach the source of the voice when you realize you are surrounded by a group of men\n" +
                $"The man who is speaking you seems to be their leader.\n" +
                $"In a snarled voice he politely asks you to empty your pockets and be on your way\n\n");

            string[] options = { "1.Raise you rifle at the Bandit Leader!", "2.Run!", "3.Take a Closer look at the Bandit" };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("Without hesitating you raise your rifle to the bandit leader. With a loud deafening thud you begin to fire at him");
                    Console.ReadKey(true);
                    Console.Clear();
                    EnemyFirstBanditCombat.Fight(_gameManager.SelectedMainPlayer, _gameManager.Enemies[1]);
                    _gameManager.SelectedMainPlayer.DisplayStats();
                    RunWareHouseDefeatedBanditLeader();
                    break;

                case 1:
                    Console.WriteLine("You attempt to run away from the Boar");
                    bool getAway = RunAway.Run(_gameManager.SelectedMainPlayer, _gameManager.Enemies[1]);
                    if (!getAway)
                    {
                        Console.WriteLine("You Failed To Get Away");
                        Console.ReadKey(true);
                        Console.Clear();
                        EnemyFirstBanditCombat.Fight(_gameManager.SelectedMainPlayer, _gameManager.Enemies[1]);
                        Console.ReadKey(true);
                        RunWareHouseDefeatedBanditLeader();
                    }

                    else
                    {
                        Console.WriteLine("You Got Away!");
                        Console.ReadKey(true);
                        NextEncounter(typeof(StrelocksShop));
                    }
                    break;
                case 2:
                    Console.WriteLine("You take a closer look at the bandit");
                    _gameManager.Enemies[1].DisplayStats();
                    SlowPrint.Print("While you took your time inspecting the bandit leader he quietly unclicks the safety on his rifle and begins to fire at you");
                    Console.Clear();
                    EnemyFirstBanditCombat.Fight(_gameManager.SelectedMainPlayer, _gameManager.Enemies[1]);
                    Console.ReadKey(true);
                    RunWareHouseDefeatedBanditLeader();
                    break;

            }


        }
        private void RunWareHouseDefeatedBanditLeader()
        {
            {

                string prompt = ($"The Bandit leader now lies face down in a pool of his own blood.\n" +
                    $" Anticipating retaliation, you swiftly pivot your firearm muzzles towards the remaining bandits locations,\n" +
                    $" but it seems the demise of their leader has shattered any semblance of courage among them. \n" +
                    $"Pausing to catch your breath, you survey your surroundings.\n\n");
                   

                string[] options = { "1.Check Area", "2.Check the inside of the Warehouse", "3.Leave Area", "4.Check Stats", "5.First Aid" };
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine("You are standing in front of a large warehouse that seems to have been of some agricultural importance.\n" +
                            "There is an eerie crackling that is coming from the inside of the warehouse");
                        Console.ReadKey(true);
                        RunWareHouseDefeatedBanditLeader();
                        break;

                    case 1:
                        Console.WriteLine("As you step through the threshold of the warehouse's expansive entrance, an astounding sight greets you:\n" +
                            " large bales of hay erupting with fiery geysers. Despite appearances,\n" +
                            " the hay isn't consumed by flames but rather generates this curious anomaly.\n\n");
                        Console.ReadKey(true);
                        RunWarehouseAnomaly();
                        break;
                    case 2:
                        Console.WriteLine("You decide to not tempt fate and move on");
                        Console.ReadKey(true);
                        NextEncounter(typeof(StrelocksShop));

                        break;
                    case 3:
                        _gameManager.SelectedMainPlayer.DisplayStats();
                        Console.ReadKey(true);
                        break;
                }

                Console.ResetColor();
            
            }
        }
        private void RunWarehouseAnomaly()
        {
            {

                string prompt = ($"As you approach the Anomaly, the searing heat from the flames washes over your face,\n" +
                    $" intensifying with each step.\n" +
                    $"Amidst the fiery tumult, something draws your gaze, a small spherical object weaving through the flames. \n" +
                    $"Its presence flickers, appearing and disappearing in a mesmerizing dance. \n" +
                    $"It's as though it beckons to you, a silent but compelling invitation.");

                string[] options = {"1.Climb the rafters to try and avoid the flames", 
                    "2.Do your best to run through the flames and grab the object", "3.Take a brief moment to grab the dead Bandit leaders Jacket to use as a fire blanket",
                "4.Leave the Warehouse"};
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

                }

                Console.ResetColor();
            }

        }
        public override void NextEncounter(Type encounterType)
        {
            _gameManager.Encounters.Where(x => x.GetType() == encounterType).FirstOrDefault().RunEncounter();
        }


    }
}

