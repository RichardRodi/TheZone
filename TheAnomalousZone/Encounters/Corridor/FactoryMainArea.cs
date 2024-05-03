using TheAnomalousZone.Combat;
using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.Corridor
{
    internal class FactoryMainArea : BaseEncounter
    {
        private GameManager _gameManager;
        public FactoryMainArea(GameManager gameManager)
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

                string prompt = ($"\nNavigating the main complex of the factory with cautious steps,\n" +
                    $"you remain alert, mindful of the lingering presence of bandits.\n" +
                    $"The rusted corridors and corroded depot present a surreal sight,\n" +
                    $"punctuated by pools of eerie, glowing jelly that seem to seep into the very fabric of the old Soviet architecture.\n" +
                    $"Moving forward, you realize that traversing through this strange substance will pose a challenge.\n" +
                    $"As you cautiously extend your foot to touch the strange substance,\n" +
                    $"a sudden realization dawns upon you—the jelly-like material exhibits a corrosive nature, \n" +
                    $"far beyond your initial expectations.\n" +
                    $"With a mere graze, it sets to work with alarming speed, devouring the sole of your boot as if it were mere paper.\n" +
                    $"Amidst this alien landscape, another curious but somewhat familiar sight catches your eye, an ethereal,\n" +
                    $"semi-transparent orb hovers faintly in the air above a mass of the glowing jelly,\n" +
                    $"its presence barely discernible amidst the eerie glow of the ooze.\n" +
                    $"Instinct tells you that this enigmatic orb may hold secrets or treasures yet unknown.\n\n");

                string[] options = { "1.Begin cautiously moving towards the object", "2. Sprint as fast as you can through the unknown substance. ", "3.Dealing with this substance is too risky. You move on.", $"4.Use a FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "5.Check Player Stats." };
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine("\nYou tread incredibly carefully as you make your way through the minefield of this sticky unknown substance.");
                        Console.ReadKey(true);
                        SubstanceMaze();
                        break;

                    case 1:
                        Console.WriteLine("\nYou make an incredible dash towards the unknown object.");
                        Console.ReadKey(true);
                        if (_gameManager.SelectedMainPlayer.Speed >= 13)
                        {
                            Console.WriteLine("\nWith a burst of adrenaline-fueled agility,\n" +
                                "you deftly navigate through the treacherous minefield of corrosive substances,\n" +
                                "propelled by sheer determination and speed. Though a small amount of the noxious material manages to graze your body,\n" +
                                "the burning sensation it induces quickly dissipates.\n" +
                                "Reaching the coveted object, a surge of euphoria washes over you,\n" +
                                "flooding your senses with an unparalleled sense of empowerment.\n" +
                                "As if touched by some mysterious force, you feel invigorated,\n" +
                                "as though you can conquer any challenge that lies ahead.\n" +
                                "Your focus sharpens to a razor's edge, and you find yourself wielding your weapons with newfound expertise,\n" +
                                "as if they were extensions of your very being. Weapon Damage + 5!\n");
                            _gameManager.SelectedMainPlayer.PlayerDamage(5);
                            Console.ReadKey(true);
                            Console.WriteLine("\nWith nothing of value left in this area you move on.\n" +
                                "You exit the factory facility and continue down the main road");
                            _gameManager.SelectedMainPlayer.WeaponValue += 5;
                            DeathCheck.IsALive(_gameManager.SelectedMainPlayer);
                            Console.ReadKey(true);
                            NextEncounter(typeof(MainRoadContinued));
                        }
                        else Console.WriteLine("\nYou awkwardly make your way through the sticky substance.\n" +
                            "It clings to your body and begins to eat through your clothes.\n" +
                            "You start to smell the burning of your own flesh as the corrosiveness eats through your garments. \n" +
                            "You try in vain but you can not get through fast enough.\n" +
                            "You stare down at your feet to see that your boots are almost disintegrated.\n" +
                            "You stumble and fall face first into the burning mucus.\n" +
                            "Everything begins to go blurry, the pain becoming a distant memory as you fade into blackness.");
                        _gameManager.SelectedMainPlayer.PlayerDamage(150);
                        Console.ReadKey(true);
                        DeathCheck.IsALive(_gameManager.SelectedMainPlayer);
                        break;
                    case 2:
                        Console.WriteLine("\nYou have intention of being consumed alive by this horrific substance so decide to move on.\n" +
                            "You exit the factory facility and continue down the main road.");
                        Console.ReadKey(true);
                        NextEncounter(typeof(MainRoadContinued));
                        break;
                    case 3:
                        _gameManager.SelectedMainPlayer.Heal(_gameManager.Items[0].MinAmountToHeal, _gameManager.Items[0].MaxAmountToHeal);
                        Console.ReadKey(true);
                        RunEncounter();
                        break;
                    case 4:
                        _gameManager.SelectedMainPlayer.DisplayStats();
                        Console.ReadKey(true);
                        RunEncounter();
                        break;

                }
            }
        }
        private void SubstanceMaze()
        {

            string prompt = ($"\nYou are confronted with a few choices as you approach the maze of corrosive substances that dot the floor\n" +
                $"leading up to the prized object.\n\n");

            string[] options = { "1.Take the left path which has fewer pools of substance on the floor but is a longer route.", "2. Take the right path which has more pools of the substance on the floor but is shorter.", "3.Head Back", $"4.Use a FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "5.Check Player Stats." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("\nChoosing the left path, where the pools of corrosive substance are fewer\n" +
                        "but the journey is longer,\n" +
                        "you proceed cautiously. Each step forward is met with relative success,\n" +
                        "but as you draw nearer to the coveted object, you encounter patches of long dead foliage scattered along the way.\n" +
                        "Unbeknownst to you, these innocuous-looking plants harbor traces of the corrosive substance,\n" +
                        "which eagerly devours the fabric of your clothes upon contact.\n" +
                        "A sharp, searing pain jolts through you as the corrosive foliage gnaws away at your garments,\n" +
                        "leaving behind a trail of destruction. The burning sensation intensifies with each passing moment,\n" +
                        "a stark reminder of the perilous nature of your surroundings.\n" +
                        "Despite the agony, you press on, determined to reach your goal.");
                    _gameManager.SelectedMainPlayer.PlayerDamage(20);
                    DeathCheck.IsALive(_gameManager.SelectedMainPlayer);
                    Console.ReadKey(true);
                    Console.WriteLine("\nReaching the coveted object, a surge of euphoria washes over you,\n" +
                        "flooding your senses with an unparalleled sense of empowerment.\n" +
                        "As if touched by some mysterious force, you feel invigorated,\n" +
                        "as though you can conquer any challenge that lies ahead.\n" +
                        "Your focus sharpens to a razor's edge, and you find yourself wielding your weapons with newfound expertise,\n" +
                        "as if they were extensions of your very being. Weapon Damage + 5!");
                    Console.ReadKey(true);
                    Console.WriteLine("\nWith nothing of value left in this area you carefully retrace your steps and move on.\n" +
                        "You exit the factory facility and continue down the main road.");
                    _gameManager.SelectedMainPlayer.WeaponValue += 5;
                    Console.ReadKey(true);
                    NextEncounter(typeof(MainRoadContinued));
                    break;

                case 1:
                    Console.WriteLine("\nOpting for the right path, where the density of pools containing the unknown substance is higher,\n" +
                        "you tread carefully, attempting to navigate the treacherous minefield of corrosive pools.\n" +
                        "Despite your best efforts, you can't avoid all contact with the viscous substance due to its sheer volume in this area.\n" +
                        "A splash of it surges upward, searing through your pant legs with an intensity coursing pain through your body.");
                    _gameManager.SelectedMainPlayer.PlayerDamage(15);
                    DeathCheck.IsALive(_gameManager.SelectedMainPlayer);
                    Console.ReadKey(true);
                    Console.WriteLine("\nReaching the coveted object, a surge of euphoria washes over you,\n" +
                        "flooding your senses with an unparalleled sense of empowerment.\n" +
                        "As if touched by some mysterious force, you feel invigorated,\n" +
                        "as though you can conquer any challenge that lies ahead.\n" +
                        "Your focus sharpens to a razor's edge, and you find yourself wielding your weapons with newfound expertise,\n" +
                        "as if they were extensions of your very being. Weapon Damage + 5!");
                    Console.ReadKey(true);
                    Console.WriteLine("\nWith nothing of value left in this area you carefully retrace your steps and move on.\n" +
                        "You exit the factory facility and continue down the main road.");
                    _gameManager.SelectedMainPlayer.WeaponValue += 5;
                    Console.ReadKey(true);
                    NextEncounter(typeof(MainRoadContinued));
                    break;
                case 2:
                    Console.WriteLine("\nTaking a moment to reassess your options, you decide to backtrack to the main area of the factory.");
                    Console.ReadKey(true);
                    RunEncounter();
                    break;
                case 3:
                    _gameManager.SelectedMainPlayer.Heal(_gameManager.Items[0].MinAmountToHeal, _gameManager.Items[0].MaxAmountToHeal);
                    Console.ReadKey(true);
                    SubstanceMaze();
                    break;
                case 4:
                    _gameManager.SelectedMainPlayer.DisplayStats();
                    Console.ReadKey(true);
                    SubstanceMaze();
                    break;

            }

        }
    }
}

