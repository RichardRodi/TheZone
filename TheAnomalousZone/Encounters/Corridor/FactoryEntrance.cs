using TheAnomalousZone.Combat;
using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.Corridor
{
    internal class FactoryEntrance : BaseEncounter
    {
        private GameManager _gameManager;
        public FactoryEntrance(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public override void NextEncounter(Type encounterType)
        {
            _gameManager.Encounters.Where(x => x.GetType() == encounterType).FirstOrDefault().RunEncounter();
        }

        public override void RunEncounter()
        {
            string prompt = ($"\nAs you step through the towering gates of the factory entrance,\n" +
                $"the distant echoes of gunfire reverberate through the air,\n" +
                $"Drawing nearer,\n" +
                $"you bear witness to a tense standoff between two distinct factions,\n" +
                $"each clad in their unmistakable attire.\n" +
                $"One group proudly wears the familiar insignias of allies you've encountered before,\n" +
                $"while the other remains a mystery,\n" +
                $"their mismatched uniforms mirroring those typically associated with the notorious bandits that roam the Zone.\n\n");

            string[] options = { "1.Help the friendly troops in their fight against the bandits.", "2.Turn on your friends and fight with the bandits.", "3.Leave them to their own devices and continue on.", $"4.Use a FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "5.Check Stats." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("\nAssuming a defensive stance, you unleash a volley of gunfire upon the encroaching bandits.\n");
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[0]);
                    Console.WriteLine("\nAfter defeating one foe you notice a Bandit Sniper on a roof who is inflicting a lot of damage and engage him.\n");
                    Console.ReadKey(true);
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[2]);
                    Console.WriteLine("\nAs the skirmish unfolds, it becomes evident that the tide of battle decidedly favors your side.\n" +
                        "The bandits, facing insurmountable odds, start to falter and scatter,\n" +
                        "their resolve crumbling beneath the relentless onslaught.\n" +
                        "As quickly as this skirmish began it ends just as abruptly, " +
                        "while the last of the bandits lies dead or has retreated.\n");
                    Console.ReadKey(true);
                    Console.Clear();
                    Console.WriteLine("\nTaking a moment to assess the aftermath,\n" +
                        "you're approached by one of the friendly soldiers.\n" +
                        "Hey friend, he begins, his voice laced with urgency,\n" +
                        "'There's something far more sinister lurking ahead than the scum we just faced.\n" +
                        "Those fanatics up ahead, they worship the Wishmaker like some twisted deity,\n" +
                        "their minds twisted by radiation and who knows what else.'\n" +
                        "If you're headed towards the Wishmaker,\n" +
                        "I wish you the best of luck, but be prepared—it won't be easy.\n" +
                        "As he speaks, the soldiers diligently scavenge the fallen for weapons and equipment.\n" +
                        "A gesture of goodwill breaks the tension as one of them tosses two first aid kits your way.\n" +
                        "Looks like you could use these,\n" +
                        "\nCatching the first aid kits, you notice a glint of metallic sheen from within.\n" +
                        "Peering inside, you find a small bundle of currency,\n" +
                        "presumably looted off the fallen soldiers, tucked snugly alongside the medical supplies.\n" +
                        "You get 2 First Aid Kits and 2000 Rubles!\n" +
                        "You move on from this area into the heart of the factory complex.");
                    _gameManager.SelectedMainPlayer.FirstAid += 2;
                    _gameManager.SelectedMainPlayer.Rubles += 2000;
                    Console.ReadKey(true);
                    NextEncounter(typeof(FactoryMainArea));
                    break;
                case 1:
                    Console.WriteLine("\nAs you aim your weapon at your friends,\n" +
                        "a nagging voice in the depths of your conscience whispers that this isn't the path to take.\n" +
                        "Lowering your weapon, you holster it with a heavy heart,\n" +
                        "acknowledging that this isn't the right course of action.\n" +
                        "As the adrenaline-fueled moment passes, clarity dawns upon you,\n" +
                        "presenting only two viable choices: to stand and lend a hand,\n" +
                        "or to retreat and preserve your own safety.");
                    Console.ReadKey(true);
                    RunEncounter();
                    break;
                case 2:
                    Console.WriteLine("\nYou decide to leave this skirmish behind and descend into the depths of the factory complex");
                    Console.ReadKey(true);
                    NextEncounter(typeof(FactoryMainArea));
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
}
