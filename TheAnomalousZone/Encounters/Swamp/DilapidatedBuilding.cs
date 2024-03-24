using TheAnomalousZone.Combat;
using TheAnomalousZone.NewFolder;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Encounters.Swamp
{
    public class DilapidatedBuilding : BaseEncounter
    {
        private GameManager _gameManager;

        public DilapidatedBuilding(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public override void RunEncounter()

        {

            string prompt = ($"\nAs you approach the dilapidated building, the snarl of a large animal breaks the quiet groan of the swamp around you.\n" +
                $"Emerging from the undergrowth is a creature unlike any you've seen before.\n" +
                $"It possesses the unmistakable features of a boar, yet something is profoundly amiss.\n" +
                $"It appears to be grotesquely mutated, its form twisted beyond recognition.\n\n");

            string[] options = { "1.Raise you Firearm to fire at it!", "2.Run to avoid this monstrosity and the house all together.", "3.Take a Closer look at the Boar." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("You raise your Rifle and at the wild boar.");
                    Console.ReadKey(true);
                    Console.Clear();
                    MutantCombat.FightPlayerFirstMutant(_gameManager.SelectedMainPlayer, _gameManager.Enemies[3]);
                    RunBoarDefeated();
                    break;

                case 1:
                    Console.WriteLine("You attempt to run away from the Boar.");
                    bool getAway = RunAway.Run(_gameManager.SelectedMainPlayer, _gameManager.Enemies[3]);
                    if (!getAway)
                    {
                        Console.ReadKey(true);
                        Console.Clear();
                        MutantCombat.FightMutantFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[3]);
                        Console.ReadKey(true);
                        RunBoarDefeated();
                    }

                    else
                    {
                        Console.WriteLine("Deciding not to mess with this ridiculous animal,\n" +
                            " you make your way out of this area and proceed along a small dirt path.\n" +
                            " You notice the only way out of this terrible bog is through a nearby looming structure.\n" +
                            " As you get closer to the structure you realize that it is a church.");
                        Console.ReadKey(true);
                        NextEncounter(typeof(AbandonedChurch));

                    }
                    break;
                case 2:
                    Console.WriteLine("You inspect the boar.");
                    _gameManager.Enemies[3].DisplayStats();
                    Console.WriteLine("While you took time inspecting the boar it decides its had enough and lunges at you.");
                    Console.ReadKey(true);
                    Console.Clear();
                    MutantCombat.FightMutantFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[3]);
                    RunBoarDefeated();
                    break;

            }

        }
        private void RunBoarDefeated()
        {

            string prompt = ($"\nAfter this swine like abomination breathes its last breath, you make your way towards the shanty home.\n" +
            $"There is a faint crackling coming from the home.\n\n");

            string[] options = { "Check the house.", "Move On.", "Use FirstAid Kit.", "Check Stats." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("As you approach the home, the hairs on the back of your neck stand on end.\n" +
                        "This is not from fear but from some unexplained external force. You decide to go inside.");
                    Console.ReadKey(true);
                    RunElectricalAnomaly();
                    break;

                case 1:
                    Console.WriteLine("You decide to not mess with this anomaly and make your way out of this area and proceed along a small dirt path.\n" +
                            "You notice the only way out of this terrible bog is through a nearby looming structure.\n" +
                            "As you get closer to the structure you realize that it is a church.");
                    Console.ReadKey();
                    NextEncounter(typeof(AbandonedChurch));
                    break;

                case 2:
                    _gameManager.SelectedMainPlayer.Heal(_gameManager.Items[0].MinAmountToHeal, _gameManager.Items[0].MaxAmountToHeal);
                    Console.ReadKey(true);
                    RunBoarDefeated();
                    break;
                case 3:
                    _gameManager.SelectedMainPlayer.DisplayStats();
                    Console.ReadKey(true);
                    RunBoarDefeated();
                    break;

            }


        }
        private void RunElectricalAnomaly()
        {

            string prompt = ($"\nPeering inside, your gaze falls upon an old fuse box, its metal casing melted and deformed, \n" +
                $"with massive tendrils of electricity surging forth. \n" +
                $"It's as if a colossal electrical spider has woven its web, enveloping the home in a crackling energy. \n" +
                $"Sitting amidst this chaotic spectacle, a tiny swirling globe of pure energy captivates your attention. \n" +
                $"An instinctual urge compels you to claim it as your own.\n\n");

            string[] options = { "1.Run through the Electricity as fast as you can to grab the object.", "2.Pick up a piece of Metal debris to throw at the swirling maelstrom.", "3.Exit.", "4. Use FirstAid Kit.", "5.Check Stats." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    if (_gameManager.SelectedMainPlayer.Speed > 10)
                    {
                        Console.WriteLine("You deftly run through the maze of electrical tendrils and grab the sphere\n" +
                                "You only take a few minor shocks that burn your skin");
                        _gameManager.SelectedMainPlayer.PlayerDamage(5);
                        Console.ReadKey();
                        Console.WriteLine("You skin feels strange to the touch as if has been hardened from the strange artifact you are holding");
                        _gameManager.SelectedMainPlayer.ArmorValue += 1;
                        Console.WriteLine("You get are now tougher Armor + 1!");
                        Console.ReadKey(true);
                        Console.WriteLine("Since there is nothing left of interest in this area you decide to move on from this home.");
                        Console.ReadKey(true);
                        Console.WriteLine("You make your way out of this area and proceed along a small dirt path.\n" +
                            "You notice the only way out of this terrible bog is through a nearby looming  structure.\n" +
                            "As you get closer to the structure you realize that it is a church.");
                        Console.ReadKey(true);
                        NextEncounter(typeof(AbandonedChurch));
                    }
                    else
                    {
                        Console.WriteLine("You attempt to run through the maze of electrical nightmares but you are too slow\n" +
                            "You get caught by the tendrils and they severely burn your skin through electrical shock.");
                        _gameManager.SelectedMainPlayer.PlayerDamage(20);
                        Console.WriteLine("After severely injuring yourself you realize you do not want anything to do with this place anymore.");
                        Console.ReadKey(true);
                        DeathCheck.IsALive(_gameManager.SelectedMainPlayer);
                        Console.WriteLine("You make your way out of this area and proceed along a small dirt path.\n" +
                            "You notice the only way out of this terrible bog is through a nearby looming structure.\n" +
                            "As you get closer to the structure you realize that it is a church.");
                        NextEncounter(typeof(AbandonedChurch));
                    }
                    break;

                case 1:
                    Console.WriteLine("You pick up a large metal object and throw it into the home.\n " +
                        "With an enormous crackle and a bang the energy dissipates,\n" +
                        "you realize there is enough time for you to grab the object\n" +
                        "As you frantically try to grab this object the electrical tendrils come back at the last\n" +
                        "second and burn your leg");
                    _gameManager.SelectedMainPlayer.PlayerDamage(10);
                    Console.ReadKey();
                    Console.WriteLine("You skin feels strange to the touch as if has been hardened from the strange artifact you are holding");
                    _gameManager.SelectedMainPlayer.ArmorValue += 2;
                    Console.WriteLine("You get are now tougher Armor + 2!");
                    Console.ReadKey(true);
                    Console.WriteLine("Since there is nothing left of interest in this area you decide to move on from this home.");
                    Console.ReadKey(true);
                    Console.WriteLine("You make your way out of this area and proceed along a small dirt path.\n" +
                        "You notice the only way out of this terrible bog is through a nearby looming structure.\n" +
                        "As you get closer to the structure you realize that it is a church.");
                    NextEncounter(typeof(AbandonedChurch));
                    break;
                case 2:
                    Console.WriteLine("You decide to not mess with this anomaly and head back");
                    Console.ReadKey();
                    RunBoarDefeated();
                    break;
                case 3:
                    _gameManager.SelectedMainPlayer.Heal(_gameManager.Items[0].MinAmountToHeal, _gameManager.Items[0].MaxAmountToHeal);
                    Console.ReadKey(true);
                    RunElectricalAnomaly();
                    break;
                case 4:
                    _gameManager.SelectedMainPlayer.DisplayStats();
                    Console.ReadKey(true);
                    RunElectricalAnomaly();
                    break;

            }

        }

        public override void NextEncounter(Type encounterType)
        {
            _gameManager.Encounters.Where(x => x.GetType() == encounterType).FirstOrDefault().RunEncounter();
        }
    }
}
