using TheAnomalousZone.Combat;
using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.PowerPlant
{
    internal class PowerPlantHallway : BaseEncounter
    {
        private GameManager _gameManager;

        public PowerPlantHallway(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public override void NextEncounter(Type encounterType)
        {
            _gameManager.Encounters.Where(x => x.GetType() == encounterType).FirstOrDefault().RunEncounter();
        }

        public override void RunEncounter()
        {
            string prompt = ($"\n\tLeaving behind the safety of the friendly denizens of the zone,\n" +
                $"\tyou step into the looming shadow cast by the massive power plant.\n" +
                $"\tThe faint echo of the monolith reverberates in your ears, urging you forward.\n" +
                $"\tEquipping your newly acquired night vision goggles, you plunge into the unknown,\n" +
                $"\ta profound sense of dread gripping you as you approach the colossal entrance of the plant.\n" +
                $"\tAs your eyes adjust to the eerie glow and flicker of the goggles,\n" +
                $"\tyou discern a multitude of soldiers bearing the eclipse symbol,\n" +
                $"\ttheir now familiar chants echoing eerily.\n" +
                $"\tThey stand with their backs turned, \n" +
                $"\tblocking your path to your final goal of reaching the Monolith,\n" +
                $"\tthere is no way to evade their vigilant watch. You have to fight them!\n\n");

            string[] options = { "1.No more hesitation. Begin the damn fight.", "2.Try and take out as many soldiers as possible before they notice.", $"3.Quickly Use FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "4.Check Player Stats." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("\n\tGathering your courage you open fire on the strange soldiers guarding your path to the prize");
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[8]);
                    Console.WriteLine("\n\tThey keep coming!");
                    Console.ReadKey(true);
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[9]);
                    Console.WriteLine("\n\tThere is no end to them!");
                    Console.ReadKey(true);
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[10]);
                    Console.WriteLine("\n\tA very large soldier clad in formidable exo-skeleton armor steps forward,\n" +
                        "\tthis lone soldier exudes an aura of relentless determination as he swiftly advances towards you.");
                    Console.ReadKey(true);
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[11]);
                    Console.WriteLine("\n\tAs the relentless battle rages on,\n" +
                        "\tit feels like an endless struggle against an unyielding tide of adversaries.\n" +
                        "\tSuddenly, you stumble backward, only to find yourself sprawled beside a fallen soldier.\n" +
                        "\tAmidst the chaos, your eyes catch sight of a grenade nestled on a lifeless soldier's belt.\n" +
                        "\tSwiftly seizing the opportunity,\n" +
                        "\tyou deftly extract the pin and hurl the grenade toward the mass of adversaries still locked in combat with you." +
                        "\tAs the smoke dissipates, revealing the aftermath of the chaos,\n" +
                        "\tonly one figure remains:\n" +
                        "\tThe previously defeated soldier in the advanced exo-skeleton armor is still damaged but still alive.\n" +
                        "\tHe advances towards you.");
                    Console.ReadKey(true);
                    FinalBoss();
                    break;
                case 1:
                    Console.WriteLine("\n\tYou manage to sink your knife into one of the soldiers,\n" +
                        "\tbut just as quickly as he breathes his last breath the other soldiers immediately open fire upon you.");
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[8]);
                    Console.WriteLine("\n\tThey keep coming!");
                    Console.ReadKey(true);
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[9]);
                    Console.WriteLine("\tThere is no end to them!");
                    Console.ReadKey(true);
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[10]);
                    Console.WriteLine("\n\tA very large soldier clad in formidable exo-skeleton armor steps forward,\n" +
                       "\tthis lone soldier exudes an aura of relentless determination as he swiftly advances towards you.");
                    Console.ReadKey(true);
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[11]);
                    Console.Clear();
                    Console.WriteLine("\n\tAs the relentless battle rages on,\n" +
                        "\tit feels like an endless struggle against an unyielding tide of adversaries.\n" +
                        "\tSuddenly, you stumble backward, only to find yourself sprawled beside a fallen soldier.\n" +
                        "\tAmidst the chaos, your eyes catch sight of a grenade nestled on a lifeless soldier's belt.\n" +
                        "\tSwiftly seizing the opportunity,\n" +
                        "\tyou deftly extract the pin and hurl the grenade toward the mass of adversaries still locked in combat with you.\n" +
                        "\n\tAs the smoke dissipates, revealing the aftermath of the chaos,\n" +
                        "\tonly one figure remains:\n" +
                        "\tThe previously defeated soldier in the advanced exo-skeleton armor is damaged but still alive.\n" +
                        "\tHe advances towards you.");
                    Console.ReadKey(true);
                    FinalBoss();
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
        private void FinalBoss()
        {
            string prompt = ($"\n\tStruggling against overwhelming fatigue,\n" +
                $"\tyou frantically search for your weapon in vain.\n" +
                $"\tunable to find it you realize must confront this formidable foe with nothing but your bare hands.\n\n");

            string[] options = { "1.Grab a nearby pipe that was broken in the destruction and launch it at the soldier.", "2.Attempt to block the first strike from your foe and counter.", "3.Flail your arms in hopes defeating this terrifying foe.", $"4.Use FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "5.Check Player Stats." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("\n\tWith a surge of resourcefulness,\n" +
                        "\tyou wrench a nearby pipe free and hurl its jagged end at the advancing demon soldier.\n" +
                        "\tThe makeshift projectile finds its mark,\n" +
                        "\tembedding itself deep within the intricate gears of the complex armor.\n" +
                        "\tSuddenly, oil and gases spew forth from your target,\n" +
                        "\twhich in turn ignites into flames that engulf the soldier in a blaze of searing heat.\n" +
                        "\tBlinded by the sudden burst of light, you swiftly remove your night vision goggles,\n" +
                        "\tRelying now on the fiery illumination emanating from the soldier's charred remains,\n" +
                        "\tyou press forward into the depths of the power plant,\n" +
                        "\tdriven by an unyielding resolve to uncover whatever truth or prize awaits you in the darkness.");
                    Console.ReadKey(true);
                    NextEncounter(typeof(PowerPlantMaze));
                    break;
                case 1:
                    Console.WriteLine("\n\tYou block the soldiers first attack and feel the pain of the massive strength of the suit.\n" +
                        "\tHowever in desperation you are able to pull a large tube from the side of this soldiers armor.\n" +
                        "\tSuddenly, oil and gases spew forth from your target,\n" +
                        "\twhich in turn ignites into flames that engulf the soldier in a blaze of searing heat.\n" +
                        "\tBlinded by the sudden burst of light, you swiftly remove your night vision goggles,\n" +
                        "\tRelying now on the fiery illumination emanating from the soldier's charred remains,\n" +
                        "\tyou press forward into the depths of the power plant,\n" +
                        "\tdriven by an unyielding resolve to uncover whatever truth or prize awaits you in the darkness.");
                    Console.ReadKey(true);
                    _gameManager.SelectedMainPlayer.PlayerDamage(5);
                    DeathCheck.IsALive(_gameManager.SelectedMainPlayer);
                    Console.ReadKey(true);
                    NextEncounter(typeof(PowerPlantMaze));
                    break;
                case 2:
                    Console.WriteLine("\n\tYou flail your arms in a futile attempt to fight back.\n" +
                        "\tSwiftly evading your erratic assault, the impenetrable wall of soldier seizes hold of your head,\n" +
                        "\tforcefully driving it against the solid wall of the power plant, again and again.\n" +
                        "\tAs your vision fades to darkness, you realize the gravity of your final, ill-fated choice.\n");
                    _gameManager.SelectedMainPlayer.PlayerDamage(100);
                    Console.ReadKey(true);
                    DeathCheck.IsALive(_gameManager.SelectedMainPlayer);
                    break;
                case 3:
                    _gameManager.SelectedMainPlayer.Heal(_gameManager.Items[0].MinAmountToHeal, _gameManager.Items[0].MaxAmountToHeal);
                    Console.ReadKey(true);
                   FinalBoss();
                    break;
                case 4:
                    _gameManager.SelectedMainPlayer.DisplayStats();
                    Console.ReadKey(true);
                    FinalBoss();
                    break;

            }
        }

    }
}
