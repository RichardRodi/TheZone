using TheAnomalousZone.Combat;
using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.Corridor
{
    internal class MainRoadContinued : BaseEncounter
    {
        private GameManager _gameManager;
        public MainRoadContinued(GameManager gameManager)
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

                string prompt = ($"\n\tAs you advance down the main road toward the looming power plant structure at the valley's end,\n" +
                    $"\tsigns of human habitation come into view directly ahead. The camp appears haphazard and makeshift,\n" +
                    $"\twith a towering fire casting flickering shadows against the surrounding landscape.\n" +
                    $"\tAs you approach you notice the men are wearing the same uniforms as the fallen soldiers with the eclipsed sun insignia.\n");

                string[] options = { "1.Sneak up to the camp.", "2.Sneak past the camp.", "3.Create a distraction by throwing something.", $"4.Use FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "5.Check Player Stats." };
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine("\n\tYou sneak up to the makeshift camp.\n" +
                            "\tAs you get closer you notice that the soldiers are all making a unique sound." +
                            "\tThey seem to be chanting in unison. A sort of hum.\n" +
                            "\tAs you approach the chant gets louder and begins to mimic a hum.\n" +
                            "\tThis hum is eerily familiar to you. Its the hum of the Monolith.\n" +
                            "\tWith a mounting sense of urgency, you cover your ears as you approach the camp.\n");
                        Console.ReadKey(true);
                        MakeShiftCamp();
                        break;

                    case 1:
                        Console.WriteLine("\n\tUsing the shadows to your advantage you sneak past the chanting soldiers.");
                        Console.ReadKey(true);
                        NextEncounter(typeof(FinalCorridorSection));
                        break;
                    case 2:
                        Console.WriteLine("\n\tYou pick up a large screw like bolt and toss it an metal container. It makes a loud clang.\n" +
                            "The guards are unphased by the sound and continue their chant.");
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
                        RunEncounter();
                        break;

                }
            }
        }
        private void MakeShiftCamp()
        {
            {

                string prompt = ($"\n\tApproaching the chanting soldiers with stealth and silence,\n" +
                    $"\tyou discern the object of their devotion at the center of the camp. It resembles a spring,\n" +
                    $"\tits spongy encased exterior emitting a faint grating sound with each reverberating chant.\n" +
                    $"\tSensing its potential significance, you recognize the value of this enigmatic item amidst the eerie scene.\n\n");

                string[] options = { "1.Try to sneak in the camp and grab the object.", "2.Silently take out as many of these soldiers as possible.", "3.Forget what you have seen and head back from where you came.", $"4.Use FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "5.Check Player Stats." };
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine("\n\tApproaching the mysterious object within the heart of the camp,\n" +
                            "\tyou move with cautious steps, mindful of the escalating hum permeating the air.\n" +
                            "\tThe resonance of the hum intensifies with each stride,\n" +
                            "\tbuilding a palpable tension as your hand inches closer to the enigmatic artifact.\n" +
                            "\tAs your fingertips make contact, the deafening hum abruptly ceases,\n" +
                            "\ttriggering an immediate reaction from the dormant soldiers surrounding you.\n" +
                            "\tA surge of energy courses through your veins as the object unleashes a blinding flash,\n" +
                            "\tmomentarily obscuring your vision. Blinking away the disorientation,\n" +
                            "\tyou find yourself met with an empty space where the object once rested.\n" +
                            "\tTaking a moment to collect your thoughts, you survey the scene,\n" +
                            "\tonly to be confronted by the grim sight of the soldiers reduced to deformed melted husks,\n" +
                            "\ta haunting testament to the power that had been unleashed.\n" +
                            "\tAs you scavenge the area for anything salvageable, your search yields only a few crumpled rubles amidst the chaos.");
                        Console.ReadKey(true);
                        Console.WriteLine("\n\tYou gained 1000 rubles");
                        _gameManager.SelectedMainPlayer.Rubles = +1000;
                        Console.WriteLine("\n\tYou continue down the main path towards your ultimate goal.");
                        Console.ReadKey(true);
                        NextEncounter(typeof(FinalCorridorSection));
                        Console.ReadKey(true);
                        break;

                    case 1:
                        Console.WriteLine("\n\tApproaching the mysterious object nestled deep within the camp,\n" +
                            "\tyour movements are deliberate,\n" +
                            "\teach step calculated to avoid detection amidst the escalating hum that resonates through the air.\n" +
                            "\tWith each passing moment, the hum grows louder, a persistent reminder of the impending unknown.\n" +
                            "\tAs you cautiously maneuver through the shadows,\n" +
                            "\twielding an antiquated military bayonet with practiced precision,\n" +
                            "\tyou silently dispatch the unsuspecting soldiers one by one.\n" +
                            "\tAs you draw nearer to the object, the hum reaches a crescendo,\n" +
                            "\tan unbearable cacophony that rattles your senses to their core before abruptly falling silent.\n" +
                            "\tIn the deafening stillness that follows, the two remaining soldiers emerge from their trance-like state.\n" +
                            "\tThey immediately realize their fallen comrades and train their rifles on you.");
                        Console.ReadKey(true);
                        BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[8]);
                        Console.WriteLine("\n\tBefore you can even catch your breath you have to fight an other soldier");
                        Console.ReadKey(true);
                        BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[9]);
                        Console.WriteLine("\n\tWith your adversaries vanquished, you stride confidently toward the enigmatic object.\n" +
                            "\tAs you reach out to touch the object,\n" +
                            "\ta wave of energy washes over you, suffusing every fiber of your being with vitality.\n" +
                            "\tYour body feels invigorated, your spirit fortified against the trials that lie ahead.\n" +
                            "\tWith a newfound sense of strength coursing through your veins,\n" +
                            "\tyou realize that your maximum health has increased by 10!");
                        Console.ReadKey(true);
                        Console.WriteLine("\n\tYou continue down the main path towards your ultimate goal.");
                        Console.ReadKey(true);
                        _gameManager.SelectedMainPlayer.MaxHealth += 10;
                        Console.Clear();
                        NextEncounter(typeof(FinalCorridorSection));
                        break;
                    case 2:
                        RunEncounter();
                        break;
                    case 3:
                        _gameManager.SelectedMainPlayer.Heal(_gameManager.Items[0].MinAmountToHeal, _gameManager.Items[0].MaxAmountToHeal);
                        Console.ReadKey(true);
                        MakeShiftCamp();
                        break;
                    case 4:
                        _gameManager.SelectedMainPlayer.DisplayStats();
                        Console.ReadKey(true);
                        MakeShiftCamp();
                        break;
                }
            }
        }
    }
}
