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
            string prompt = ($"\nLeaving behind the safety of the friendly denizens of the zone,\n" +
                $"you step into the looming shadow cast by the massive power plant.\n" +
                $"The faint echo of the monolith reverberates in your ears, urging you forward.\n" +
                $"Equipping your newly acquired night vision goggles, you plunge into the unknown,\n" +
                $"a profound sense of dread gripping you as you approach the colossal entrance of the plant.\n" +
                $"As your eyes adjust to the eerie glow and flicker of the goggles,\n" +
                $"you discern a multitude of soldiers bearing the eclipse symbol,\n" +
                $"their now familiar chants echoing eerily.\n" +
                $"They stand with their backs turned, \n" +
                $"blocking your path to your final goal of reaching the Monolith,\n" +
                $"there is no way to evade their vigilant watch. You have to fight them!\n\n");

            string[] options = { "1.No more hesitation. Begin the damn fight.", "2.Try and take out as many soldiers as possible before they notice.", $"3.Quickly Use FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "4.Check Player Stats." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("\nGathering your courage you open fire on the strange soldiers guarding your path to the prize");
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[8]);
                    Console.WriteLine("\nThey keep coming!");
                    Console.ReadKey(true);
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[9]);
                    Console.WriteLine("\nThere is no end to them!");
                    Console.ReadKey(true);
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[10]);
                    Console.WriteLine("\nA very large soldier clad in formidable exo-skeleton armor steps forward,\n" +
                        "this lone soldier exudes an aura of relentless determination as he swiftly advances towards you.");
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[11]);
                    Console.WriteLine("\nAs the relentless battle rages on,\n" +
                        "it feels like an endless struggle against an unyielding tide of adversaries.\n" +
                        "Suddenly, you stumble backward, only to find yourself sprawled beside a fallen soldier.\n" +
                        "Amidst the chaos, your eyes catch sight of a grenade nestled on a lifeless soldier's belt.\n" +
                        "Swiftly seizing the opportunity,\n" +
                        "you deftly extract the pin and hurl the grenade toward the mass of adversaries still locked in combat with you." +
                        "As the smoke dissipates, revealing the aftermath of the chaos,\n" +
                        "only one figure remains:\n" +
                        "The previously defeated soldier in the advanced exo-skeleton armor is still damaged but still alive.\n" +
                        "He advances towards you.");
                    Console.ReadKey(true);
                    FinalBoss();
                    break;

                case 1:
                    Console.WriteLine("\nYou manage to sink your knife into one of the soldiers,\n" +
                        "but just as quickly as he breathes his last breath the other soldiers immediately open fire upon you.");
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[8]);
                    Console.WriteLine("\nThey keep coming!");
                    Console.ReadKey(true);
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[9]);
                    Console.WriteLine("There is no end to them!");
                    Console.ReadKey(true);
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[10]);
                    Console.WriteLine("\nA very large soldier clad in formidable exo-skeleton armor steps forward,\n" +
                       "this lone soldier exudes an aura of relentless determination as he swiftly advances towards you.");
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[11]);
                    Console.Clear();
                    Console.WriteLine("\nAs the relentless battle rages on,\n" +
                        "it feels like an endless struggle against an unyielding tide of adversaries.\n" +
                        "Suddenly, you stumble backward, only to find yourself sprawled beside a fallen soldier.\n" +
                        "Amidst the chaos, your eyes catch sight of a grenade nestled on a lifeless soldier's belt.\n" +
                        "Swiftly seizing the opportunity,\n" +
                        "you deftly extract the pin and hurl the grenade toward the mass of adversaries still locked in combat with you." +
                        "As the smoke dissipates, revealing the aftermath of the chaos,\n" +
                        "only one figure remains:\n" +
                        "The previously defeated soldier in the advanced exo-skeleton armor is damaged but still alive.\n" +
                        "He advances towards you");
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
            string prompt = ($"\nStruggling against overwhelming fatigue,\n" +
                $"you frantically search for your weapon in vain.\n" +
                $"unable to find it you realize must confront this formidable foe with nothing but your bare hands.\n\n");

            string[] options = { "1.Grab a nearby pipe that was broken in the destruction and launch it at the soldier", "2.Attempt to block the first strike from your foe and counter", "3.Flail your arms in hopes defeating this terrifying foe.", $"4.Use FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "5.Check Player Stats." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("\nWith a surge of resourcefulness,\n" +
                        "you wrench a nearby pipe free and hurl its jagged end at the advancing demon soldier.\n" +
                        "The makeshift projectile finds its mark,\n" +
                        "embedding itself deep within the intricate gears of the complex armor.\n" +
                        "Suddenly, oil and gases spew forth from your target,\n" +
                        "which in turn ignites into flames that engulf the soldier in a blaze of searing heat.\n" +
                        "Blinded by the sudden burst of light, you swiftly remove your night vision goggles,\n" +
                        "Relying now on the fiery illumination emanating from the soldier's charred remains,\n" +
                        "you press forward into the depths of the power plant,\n" +
                        "driven by an unyielding resolve to uncover whatever truth or prize awaits you in the darkness.");
                    Console.ReadKey(true);
                    NextEncounter(typeof(PowerPlantMaze));
                    break;
                case 1:
                    Console.WriteLine("\nYou block the soldiers first attack and feel the pain of the massive strength of the suit.\n" +
                        "However in desperation you are able to pull a large tube from the side of this soldiers armor.\n" +
                        "Suddenly, oil and gases spew forth from your target,\n" +
                        "which in turn ignites into flames that engulf the soldier in a blaze of searing heat.\n" +
                        "Blinded by the sudden burst of light, you swiftly remove your night vision goggles,\n" +
                        "Relying now on the fiery illumination emanating from the soldier's charred remains,\n" +
                        "you press forward into the depths of the power plant,\n" +
                        "driven by an unyielding resolve to uncover whatever truth or prize awaits you in the darkness.");
                    Console.ReadKey(true);
                    _gameManager.SelectedMainPlayer.PlayerDamage(5);
                    DeathCheck.IsALive(_gameManager.SelectedMainPlayer);
                    Console.ReadKey(true);
                    NextEncounter(typeof(PowerPlantMaze));
                    break;
                case 2:
                    Console.WriteLine("\nYou flail your arms in a futile attempt to fight back.\n" +
                        "Swiftly evading your erratic assault, the impenetrable wall of soldier seizes hold of your head,\n" +
                        "forcefully driving it against the solid wall of the power plant, again and again.\n" +
                        "As your vision fades to darkness, you realize the gravity of your final, ill-fated choice.\n");
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
