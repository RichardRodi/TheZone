using TheAnomalousZone.Combat;
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

                string[] options = { "1.Walk through the center of the church", "2.Walk around the perimeter of the Church", "3.Check your surroundings", "4.Use FirstAid Kit", "5.Check Stats" };
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine("As you walk through the hollowed out corpse of this sanctified space,\n" +
                            "you hear the guttural sounds of something human but not quite.\n" +
                            "You raise your rifle in anticipation. \n" +
                            "It dawns on you that there are more than one of whatever is making this sound.\n" +
                            "Before you can react something leaps out at you.");
                        Console.ReadKey(true);
                        MutantCombat.FightMutantFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[5]);
                        Console.ReadKey(true);
                        Console.WriteLine("Taking a breath and reloading your weapon you are confronted with another enemy.");
                        MutantCombat.FightPlayerFirstMutant(_gameManager.SelectedMainPlayer, _gameManager.Enemies[5]);
                        Console.ReadKey(true);
                        Console.WriteLine("Is there any end to these damn creatures?");
                        MutantCombat.FightPlayerFirstMutant(_gameManager.SelectedMainPlayer, _gameManager.Enemies[5]);
                        Console.ReadKey(true);
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
                        _gameManager.SelectedMainPlayer.Heal(_gameManager.Items[0].AmountToHeal);
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

                    break;

                case 1:
                    Console.WriteLine("You attempt to run away from the fast approaching hoard.");
                    bool getAway = RunAway.Run(_gameManager.SelectedMainPlayer, _gameManager.Enemies[5]);
                    if (!getAway)
                    {
                        Console.ReadKey(true);
                        Console.Clear();
                        MutantCombat.FightMutantFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[5]);
                        Console.ReadKey(true);
                        Console.WriteLine("Taking a breath and reloading your weapon you are confronted with another enemy.");
                        MutantCombat.FightPlayerFirstMutant(_gameManager.SelectedMainPlayer, _gameManager.Enemies[5]);
                        Console.ReadKey(true);
                        Console.WriteLine("Is there any end to these damn creatures?");
                        MutantCombat.FightPlayerFirstMutant(_gameManager.SelectedMainPlayer, _gameManager.Enemies[5]);
                        Console.ReadKey(true);
                        ChurchFightFinished();
                    }

                    else
                    {
                        Console.WriteLine("You escape the hoard and make your way down the only path leading out of the swamp");
                        Console.ReadKey(true);
                        //NextEncounter(typeof(AbandonedChurch));

                    }
                    break;
               
                case 2:
                    _gameManager.SelectedMainPlayer.Heal(_gameManager.Items[0].AmountToHeal);
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

        }

    }

}
