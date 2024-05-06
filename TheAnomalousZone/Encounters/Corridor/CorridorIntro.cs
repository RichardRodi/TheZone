using TheAnomalousZone.Encounters.Shop;
using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.Corridor
{
    internal class CorridorIntro : BaseEncounter
    {
        private GameManager _gameManager;

        public CorridorIntro(GameManager gameManager)
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
                string prompt = ($"\n\tLeaving the swamp behind, you are confronted with a long and winding valley.\n" +
                    $"\tA narrow two-lane road cuts through the center of this expanse,\n" +
                    $"\tleading your gaze to the far end where a massive power plant looms on the horizon.\n" +
                    $"\tAs you stare at the setting sun behind the imposing structure,\n" +
                    $"\tthe haunting hum of the Monolith from your nightmares reverberates in your skull,\n" +
                    $"\tsending shivers down your spine. Once again, you are faced with a choice.\n" +
                    $"\tTo your left, a sign beckons with the promise of a Shop,\n" +
                    $"\tpointing toward a small rural village nestled amidst the landscape.\n" +
                    $"\tAhead of you, the road stretches toward what you assume to be your destination,\n" +
                    $"\tinviting you to continue your journey into the unknown.\n\n");

                string[] options = { "1.Continue to your Left towards the Shop.", "2.Continue down the Road.", "3.Check Surroundings.", $"4.Use a FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "5.Check Player Stats." };
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine($"\n\tTrusting that this is not an other ambush or trap,\n" +
                            "\tyou make your towards the 'Shop'");
                        Console.ReadKey(true);
                        Console.Clear(); 
                        NextEncounter(typeof(StrelocksShop));
                        break;

                    case 1:
                        Console.WriteLine($"\n\tNot wanting to risk being eaten or shot you make your way down the road.");
                        Console.ReadKey(true);
                        NextEncounter(typeof(CorridorCrossRoads));
                        break;
                    case 2:
                        Console.WriteLine($"\n\tYou gaze at the road leading towards the power plant,\n" +
                            $"\trecognizing the daunting challenge it presents.\n" +
                            $"\tYet, despite the difficulties ahead, you understand that this path is one of significance and potential reward.\n" +
                            $"\tHowever, as your eyes drift towards the shop sign, a sense of tranquility washes over you.\n" +
                            $"\tIt's as if an unseen force gently nudges you towards the quaint village,\n" +
                            $"\twhispering that there may be something of value waiting for you there.\n");
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
                        Console.Clear();
                        RunEncounter();
                        break;

                }
            }
        }
    }
}
