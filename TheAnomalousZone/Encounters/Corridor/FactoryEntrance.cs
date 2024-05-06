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
            string prompt = ($"\n\tAs you step through the towering gates of the factory entrance,\n" +
                $"\tthe distant echoes of gunfire reverberate through the air,\n" +
                $"\tDrawing nearer,\n" +
                $"\tyou bear witness to a tense standoff between two distinct factions,\n" +
                $"\teach clad in their unmistakable attire.\n" +
                $"\tOne group proudly wears the familiar insignias of allies you've encountered before,\n" +
                $"\twhile the other remains a mystery,\n" +
                $"\ttheir mismatched uniforms mirroring those typically associated with the notorious bandits that roam the Zone.\n\n");

            string[] options = { "1.Help the friendly troops in their fight against the bandits.", "2.Turn on your friends and fight with the bandits.", "3.Leave them to their own devices and continue on.", $"4.Use a FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "5.Check Stats." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("\n\tAssuming a defensive stance, you unleash a volley of gunfire upon the encroaching bandits.\n");
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[0]);
                    Console.WriteLine("\n\tAfter defeating one foe you notice a Bandit Sniper on a roof who is inflicting a lot of damage and engage him.\n");
                    Console.ReadKey(true);
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[2]);
                    Console.WriteLine("\n\tAs the skirmish unfolds, it becomes evident that the tide of battle decidedly favors your side.\n" +
                        "\tThe bandits, facing insurmountable odds, start to falter and scatter,\n" +
                        "\ttheir resolve crumbling beneath the relentless onslaught.\n" +
                        "\tAs quickly as this skirmish began it ends just as abruptly,\n" +
                        "\twhile the last of the bandits lies dead or has retreated.\n");
                    Console.ReadKey(true);
                    Console.Clear();
                    Console.WriteLine("\n\tTaking a moment to assess the aftermath,\n" +
                        "\tyou're approached by one of the friendly soldiers.\n" +
                        "\tHey friend, he begins, his voice laced with urgency,\n" +
                        "\t'There's something far more sinister lurking ahead than the scum we just faced.\n" +
                        "\tThose fanatics up ahead, they worship the Wishmaker like some twisted deity,\n" +
                        "\ttheir minds twisted by radiation and who knows what else.'\n" +
                        "\tIf you're headed towards the Wishmaker,\n" +
                        "\tI wish you the best of luck, but be prepared—it won't be easy.\n" +
                        "\tAs he speaks, the soldiers diligently scavenge the fallen for weapons and equipment.\n" +
                        "\tA gesture of goodwill breaks the tension as one of them tosses two first aid kits your way.\n" +
                        "\tLooks like you could use these,\n" +
                        "\n\tCatching the first aid kits, you notice a glint of metallic sheen from within.\n" +
                        "\tPeering inside, you find a small bundle of currency,\n" +
                        "\tpresumably looted off the fallen soldiers, tucked snugly alongside the medical supplies.\n" +
                        "\tYou get 2 First Aid Kits and 2000 Rubles!\n" +
                        "\tYou move on from this area into the heart of the factory complex.");
                    _gameManager.SelectedMainPlayer.FirstAid += 2;
                    _gameManager.SelectedMainPlayer.Rubles += 2000;
                    Console.ReadKey(true);
                    NextEncounter(typeof(FactoryMainArea));
                    break;
                case 1:
                    Console.WriteLine("\n\tAs you aim your weapon at your friends,\n" +
                        "\ta nagging voice in the depths of your conscience whispers that this isn't the path to take.\n" +
                        "\tLowering your weapon, you holster it with a heavy heart,\n" +
                        "\tacknowledging that this isn't the right course of action.\n" +
                        "\tAs the adrenaline-fueled moment passes, clarity dawns upon you,\n" +
                        "\tpresenting only two viable choices: to stand and lend a hand,\n" +
                        "\tor to retreat and preserve your own safety.");
                    Console.ReadKey(true);
                    RunEncounter();
                    break;
                case 2:
                    Console.WriteLine("\n\tYou decide to leave this skirmish behind and descend into the depths of the factory complex");
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
