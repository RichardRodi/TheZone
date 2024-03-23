using TheAnomalousZone.Combat;
using TheAnomalousZone.Encounters.Corridor;
using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.Swamp
{
    internal class AbandonedChurch : BaseEncounter
    {
        private GameManager _gameManager;

        public AbandonedChurch(GameManager gameManager)
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

                string prompt = ($"In the heart of the murky swamp stands an Old Church,\n" +
                    $"its weathered facade adorned with ornate carvings and intricate details of ancient saints.\n" +
                    $"Tall, slender spires pierce the mist-shrouded sky, \n" +
                    $"their hollowed out peaks disappearing into the veil of fog that hangs heavy over the damp swamp.\n\n");

                string[] options = { "1.Walk through the center of the Church.", "2.Walk around the perimeter of the Church.", "3.Check your surroundings.", "4.Use FirstAid Kit.", "5.Check Stats." };
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine("As you walk through the hollowed out corpse of this sanctified space,\n" +
                            "you hear the guttural sounds of something human but not quite.\n" +
                            "You raise your firearm in anticipation. \n" +
                            "It dawns on you that there are more than one of whatever is making this sound.\n" +
                            "Before you can react something leaps out at you.");
                        Console.ReadKey(true);
                        Console.Clear();
                        Console.WriteLine("You see the horrified creatures as they leap at you, running on all fours.\n" +
                        $"They are grotesquely mutated human soldiers, \n" +
                        $"Clad in the shredded remnants of their uniform and boots,\n" +
                        $"their inhuman faces obscured behind cracked gas masks with flailing hoses.");
                        Console.ReadKey(true);
                        MutantCombat.FightMutantFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[5]);
                        Console.WriteLine("You have a brief moment to catch your breath and reload your weapon,\n" +
                            " before another foe barrels at you!");
                        Console.ReadKey();
                        MutantCombat.FightMutantFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[6]);
                        ChurchFightFinished();
                        break;

                    case 1:
                        Console.WriteLine("As you walk around the hollowed out corpse of this sanctified space,\n" +
                            "you hear the guttural sounds of something human but not quite.\n" +
                            "You raise your rifle in anticipation. \n" +
                            "It dawns on you that there are more than one of whatever is making this sound.\n");
                        Console.ReadKey(true);
                        ChurchFight();
                        break;
                    case 2:
                        Console.WriteLine("Looking around the Church you experience an extreme sense of dread, \n" +
                            "If you are to exit this infernal swamp you must proceed around or through this church.");
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
        private void ChurchFight()
        {

            string prompt = ($"You see the horrified creatures as they approach you running on all fours.\n" +
                $"They are grotesquely mutated human soldiers, \n" +
                $"Clad in the shredded remnants of their uniform and boots,their face obscured behind cracked gas masks with flailing hoses.\n\n");

            string[] options = { "1.Stand and Fight!", "2.Run!", "3.Use FirstAid Kit.", "4.Check Stats." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("You eliminate several of the feral monsters as they close in,\n" +
                        "preventing them from laying a finger on you. \n" +
                        "However, one nimble adversary manages to evade your gunfire, \n" +
                        "forcing you to hastily reload as it closes in on you.");
                    Console.ReadKey(true);
                    MutantCombat.FightMutantFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[5]);
                    ChurchFightFinished();
                    break;

                case 1:
                    Console.WriteLine("You attempt to run away from the fast approaching hoard.");
                    bool getAway = RunAway.Run(_gameManager.SelectedMainPlayer, _gameManager.Enemies[5]);
                    if (!getAway)
                    {
                        Console.WriteLine("You are unable to escape the hoard!");
                        Console.ReadKey(true);
                        Console.Clear();
                        MutantCombat.FightMutantFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[5]);
                        ChurchFightFinished();
                    }

                    else
                    {
                        Console.WriteLine("You escape the hoard and make your way down the only path leading out of the swamp.\n" +
                            "Finally seeing and exit to the swamp you make your way up a slight hill.\n" +
                            "You exit this murky place once and for all.");
                        Console.ReadKey(true);
                        NextEncounter(typeof(CorridorIntro));
                    }
                    break;

                case 2:
                    _gameManager.SelectedMainPlayer.Heal(_gameManager.Items[0].MinAmountToHeal, _gameManager.Items[0].MaxAmountToHeal);
                    Console.ReadKey(true);
                    break;
                case 3:
                    _gameManager.SelectedMainPlayer.DisplayStats();
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
            }
        }
        private void ChurchFightFinished()
        {
            string prompt = ($"You stand amidst the fallen mutant freaks.\n" +
                $"Any other enemies that could have caused you trouble have run away in terror.\n" +
                $"feeling the weight of exhaustion settle upon you from the fierce battle you've just endured.\n" +
                $"You find yourself amidst the eerie silence of this ghostly church.\n\n");

            string[] options = { "1.Check the Altar.", "2.Look around.", "3.Climb the stairs and check the steeple", "4.You want to Leave!", "4.Use FirstAid Kit.", "5.Check Stats." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("The altar stands bare, crafted from cold marble,\n" +
                        "adorned only by the broken half of an Eastern Orthodox cross, \n" +
                        "teetering precariously upon its surface. Below the Alter lies a small Lock Box." +
                        "There is a simple lock with a four digit combination keeping it shut.\n\n\n" +
                        "Please type numbers to try and open the LockBox.");
                    Console.ReadKey(true);
                    var answer = Console.ReadLine();
                    if (answer == "9012")
                    {
                        Console.WriteLine("The Lockbox opens with a satisfying click.\n" +
                            "Inside is a giant stack of rubles!\n" +
                            "You gain 5000 Rubles!");
                        _gameManager.SelectedMainPlayer.Rubles += 5000;
                        Console.ReadKey(true);
                        Console.WriteLine("Realizing there is nothing left in this church you move on\n" +
                        "Finally seeing and exit to the swamp you make your way up a slight hill.\n" +
                        "You exit this murky place once and for all.");
                        NextEncounter(typeof(CorridorIntro));
                    }
                    else
                        Console.WriteLine("Unfortunately that is not the answer to the lockbox");
                    Console.ReadKey(true);
                    ChurchFightFinished();
                    break;

                case 1:
                    Console.WriteLine("Looking up at the strangely defiant structure, you notice the numbers 1 and 2 etched into the vacant area of the crucifix");
                    Console.ReadKey();
                    ChurchFightFinished();
                    break;

                case 2:
                    Console.WriteLine("Climbing the harrowing stairs to the pinnacle of the church you make your way to the top.\n" +
                        "Peering through the mists of the swamp you can see some semblance of an exit.\n" +
                        "As you get ready to descend, something catches your eye on the way down.\n" +
                        "You noticed the numbers 9 and 0 etched into the are where the a massive bell hung.\n" +
                        "You are once again standing in the middle of the church");
                    Console.ReadKey();
                    ChurchFightFinished();
                    break;
                case 3:
                    Console.WriteLine("Desiring to leave this accursed place you make your way out of the swamp.\n" +
                        "Finally seeing and exit to the swamp you make your way up a slight hill.\n" +
                        "You exit this murky place once and for all.");
                    NextEncounter(typeof(CorridorIntro));
                    break;

                case 4:

                    _gameManager.SelectedMainPlayer.Heal(_gameManager.Items[0].MinAmountToHeal, _gameManager.Items[0].MaxAmountToHeal);
                    Console.ReadKey(true);
                    break;
                case 5:
                    _gameManager.SelectedMainPlayer.DisplayStats();
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
            }
        }

    }

}
