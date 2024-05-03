using TheAnomalousZone.Combat;
using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.Corridor
{
    internal class MainRoad : BaseEncounter
    {
        private GameManager _gameManager;
        public MainRoad(GameManager gameManager)
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
                string prompt = ($"\nAs you tread down the desolate main road, strewn with forsaken trucks,\n" +
                    $"a cacophony of screeches assaults your ears. Darting among the debris,\n" +
                    $"mutated creatures reminiscent of rats scuttle in a frenzied whirlwind.\n" +
                    $"In their wake follows a grotesque behemoth, a dual-headed monstrosity,\n" +
                    $"voraciously devouring the rodents in its path.\n" +
                    $"Pausing mid-feast, it fixes its gaze upon you with an unsettling intensity.\n" +
                    $"Brace yourself – this is going to be a touch fight.\n\n");

                string[] options = { "1.Take a defensive position behind a nearby abandoned truck.", "2.Relinquish your personal courage and run!", "3.Immediately begin firing at the Monstrosity.", $"4.Quickly use a FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "5.Check Player Stats." };
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine($"\nYou run behind a nearby truck to get a bead on the monster.\n" +
                            $"Since the sun is going down you lose sight of the mutant.\n" +
                            $"As you frantically dart your eyes around trying to adjust to the dimming light,\n" +
                            $" you hear a snarl behind you and realize its super close. It takes a swipe at you.\n");
                        Console.ReadKey(true);
                        if (_gameManager.SelectedMainPlayer.Speed > 10)
                        {
                            Console.WriteLine($"You deftly dodge the mutants grasp. Now you have to put it down.");
                            Console.ReadKey(true);
                            MutantCombat.FightPlayerFirstMutant(_gameManager.SelectedMainPlayer, _gameManager.Enemies[4]);
                            Console.ReadKey(true);
                            ChimeraDefeated();
                        }
                        else
                        {
                            Console.WriteLine($"\nThe Monster connects with your body rocking you to the ground.\n" +
                                $"You jump up from the wound and have no choice but to put down the monster.");
                            _gameManager.SelectedMainPlayer.PlayerDamage(10);
                            Console.ReadKey(true);
                            DeathCheck.IsALive(_gameManager.SelectedMainPlayer);
                            Console.ReadKey(true);
                            MutantCombat.FightPlayerFirstMutant(_gameManager.SelectedMainPlayer, _gameManager.Enemies[4]);
                            Console.ReadKey(true);
                            ChimeraDefeated();

                        }
                        break;

                    case 1:
                        Console.WriteLine($"\nYou whisper a nope under your breath and decide to flee this area and head to towards the factories.");
                        if (_gameManager.SelectedMainPlayer.Speed > 11)
                        {
                            Console.WriteLine($"\nYou are able to flee before the mutant notices you.\n" +
                                $"Heading over a hill you see the path towards the factories ahead of you.");
                            Console.ReadKey(true);
                            NextEncounter(typeof(FactoryEntrance));
                        }
                        else
                        {

                            Console.WriteLine($"\nAs you try and flee the mutant connects with your body rocking you to the ground.\n" +
                                $"You jump up from the wound and have no choice but to put down the monster.");
                            _gameManager.SelectedMainPlayer.PlayerDamage(10);
                            Console.ReadKey(true);
                            DeathCheck.IsALive(_gameManager.SelectedMainPlayer);
                            MutantCombat.FightPlayerFirstMutant(_gameManager.SelectedMainPlayer, _gameManager.Enemies[4]);
                            Console.ReadKey(true);
                            ChimeraDefeated();
                        }
                        break;
                    case 2:
                        Console.WriteLine($"\nYou fire at the mutant but given its distance and speed it dodges your attacks.\n" +
                            $"You have to reload as all the ammunition in your magazine is spent.\n" +
                            $"You are not able to raise your rifle in time before the beast gets its claws out to attack you.\n");
                        Console.ReadKey(true);
                        _gameManager.SelectedMainPlayer.PlayerDamage(5);
                        Console.ReadKey(true);
                        DeathCheck.IsALive(_gameManager.SelectedMainPlayer);
                        MutantCombat.FightPlayerFirstMutant(_gameManager.SelectedMainPlayer, _gameManager.Enemies[4]);
                        Console.ReadKey(true);
                        ChimeraDefeated();
                        break;
                    case 3:
                        Console.WriteLine($"\nYou quickly use a first aid kit as the mutant barrels towards you.\n" +
                            $"You are not able to raise your rifle in time before the beast gets its claws out to attack you.\n");
                        _gameManager.SelectedMainPlayer.Heal(_gameManager.Items[0].MinAmountToHeal, _gameManager.Items[0].MaxAmountToHeal);
                        Console.ReadKey(true);
                        _gameManager.SelectedMainPlayer.PlayerDamage(5);
                        Console.ReadKey(true);
                        DeathCheck.IsALive(_gameManager.SelectedMainPlayer);
                        MutantCombat.FightPlayerFirstMutant(_gameManager.SelectedMainPlayer, _gameManager.Enemies[4]);
                        Console.ReadKey(true);
                        ChimeraDefeated();

                        break;
                    case 4:
                        _gameManager.SelectedMainPlayer.DisplayStats();
                        Console.ReadKey(true);
                        Console.Clear();
                        ChimeraDefeated();
                        break;


                }

            }
        }
        private void ChimeraDefeated()
        {

            string prompt = ($"\nThe mighty beast exhales its final breath, collapsing to the ground in a silent surrender.\n" +
                $"With a cautious determination, you deliver two precise shots to each of its skulls, ensuring its demise.\n" +
                $"Taking a moment to tend to your own wounds and regain your composure, you survey the grim aftermath. \n" +
                $"Strewn across the landscape are rotting fallen soldiers presumably killed by this great beast.\n" +
                $"They are clad in distinctive uniforms adorned with matching patches bearing an eclipsed sun.\n" +
                $"Among them, a lone soldier grips a peculiar rifle, \n" +
                $"This rifle is emanating an otherworldly energy.\n\n");

            string[] options = { "1.Grab the Rifle.", "2.Leave the rifle and move on.", $"3.Use FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "4.Check Player Stats." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("\nYou seize the peculiar rifle, its weight demanding you relinquish your current weapon.\n" +
                        "Upon closer examination, you discover a small artifact nestled within its structure.\n" +
                        "Eager to test its capabilities, you take aim at a nearby road sign. With a resounding whoosh,\n" +
                        "the rifle unleashes an intense blue stream of light, effortlessly melting the sign in half.\n" +
                        "You do this two more times and notice the rifle gets super hot and glows.\n" +
                        "You need to give it a moment to cool down before you can continue firing.");
                    Console.ReadKey(true);
                    Console.WriteLine("\nYour new weapon gives you Weapon Value: 22, Ammunition Per Magazine: 3!\n" +
                        "You Continue on your journey down the main road");
                    _gameManager.SelectedMainPlayer.Ammunition = 3;
                    _gameManager.SelectedMainPlayer.WeaponValue = 22;
                    Console.ReadKey(true);
                    NextEncounter(typeof(MainRoadContinued));
                    break;
                case 1:
                    Console.WriteLine("\nYou decide to forgo picking up the rifle and continue on your way down the arduous road.");
                    Console.ReadKey(true);
                    NextEncounter(typeof(MainRoadContinued));
                    break;
                case 2:
                    _gameManager.SelectedMainPlayer.Heal(_gameManager.Items[0].MinAmountToHeal, _gameManager.Items[0].MaxAmountToHeal);
                    Console.ReadKey(true);
                    RunEncounter();
                    break;
                case 3:
                    _gameManager.SelectedMainPlayer.DisplayStats();
                    Console.ReadKey(true);
                    RunEncounter();
                    break;

            }
        }
    }
}
