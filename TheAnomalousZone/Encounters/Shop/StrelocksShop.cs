using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using TheAnomalousZone.Encounters.Corridor;
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
            _gameManager.Encounters.Where(x => x.GetType() == encounterType).FirstOrDefault().RunEncounter();
        }
      
        public override void RunEncounter()
        {
            
            {
                string prompt = ($"\n\tYou make your way down to the rustic village,\n" +
                    $"\twhere a few people keep watch, their demeanor nonviolent yet vigilant.\n" +
                    $"\tThey bear similar gear and weapons, hinting at a shared purpose and allegiance.\n" +
                    $"\tNavigating through the small settlement while following the shop signs,\n" +
                    $"\tyou eventually find yourself standing before an old Cold War bunker,\n" +
                    $"\tits entrance concealed within the earth. A neon sign above reads Strelock's Shop.\n" +
                    $"\tInside, you are greeted by an older man,\n" +
                    $"\tDespite his gruff exterior, he welcomes you with a booming voice,\n" +
                    $"\turging you to enter and explore his wares.\n");

                string[] options = {"1.Buy Plates for your Armor\n Armor + 5 - 5000 Rubles", "2.Buy Custom parts for your Weapon\nWeapon Damage + 4 - 4000 Rubles",
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
                            Console.WriteLine("\n\tArmor increased by 5!");
                            Console.ReadKey(true);
                            RunEncounter();
                        }
                        else
                        {
                            Console.WriteLine("\n\tNot Enough Money.");
                            Console.ReadKey(true);
                            RunEncounter();
                        }

                        break;

                    case 1:

                        if (_gameManager.SelectedMainPlayer.Rubles >= _gameManager.Items[3].Price)
                        {
                            _gameManager.SelectedMainPlayer.Rubles -= _gameManager.Items[3].Price;
                            _gameManager.SelectedMainPlayer.WeaponValue += 4;
                            Console.WriteLine("\n\tWeapon Damage increased by 4!");
                            Console.ReadKey(true);
                            Console.Clear();
                            RunEncounter();

                        }
                        else
                        {
                            Console.WriteLine("\n\tNot Enough Money.");
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
                            Console.WriteLine("\n\tAmmunition per magazine increased by 2!");
                            Console.ReadKey(true);
                            Console.Clear();
                            RunEncounter();
                        }
                        else
                        {
                            Console.WriteLine("\n\tNot Enough Money.");
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
                            Console.WriteLine("\n\tFirst Aid Added to your Inventory!");
                            Console.ReadKey(true);
                            Console.Clear();
                            RunEncounter();
                        }
                        else
                        {
                            Console.WriteLine("\n\tNot Enough Money.");
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
                        Console.WriteLine("\n\tStrelock the owner of this shop speaks to you, his words laden with significance.\n" +
                            "\t'Thank you for your patronage!\n" +
                            "\tI can see it in your eyes, the call of the WishGiver, that towering Monolith tempting you with untold riches,\n" +
                            "\tor perhaps infinite knowledge or power.' He pauses, his gaze both penetrating and compassionate.\n" +
                            "\t'Be wary, for wishes are seldom what you truly desire.\n" +
                            "\tBut who am I to dissuade a man from following his heart? Good luck out there, friend.'\n" +
                            "\tWith these parting words, he tosses you an old pair of binoculars.\n" +
                            "\t'These are on the house friend.'\n" +
                            "\tHis advice echoing in your mind, you exit Strelock's shop.") ;
                        Console.ReadKey(true);
                        Console.Clear();
                        NextEncounter(typeof(CorridorCrossRoads));
                        break;
                }
            }
        }
        
    }
}
