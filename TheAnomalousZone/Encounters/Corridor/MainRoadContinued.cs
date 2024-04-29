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

                string prompt = ($"\nAs you advance down the main road toward the looming power plant structure at the valley's end,\n" +
                    $"signs of human habitation come into view directly ahead. The camp appears haphazard and makeshift,\n" +
                    $"with a towering fire casting flickering shadows against the surrounding landscape.\n" +
                    $"As you approach you notice the men are wearing the same uniforms as the fallen soldiers with the eclipsed sun insignia.\n");

                string[] options = { "1.Sneak up to the camp.", "2.Sneak past the camp.", "3.Create a distraction by throwing something.", $"4.Use FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "5.Check Player Stats." };
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine("You sneak up to the makeshift camp.\n" +
                            "As you get closer you notice that the soldiers are all making a unique sound." +
                            "They seem to be chanting in unison. A sort of hum.\n" +
                            "As you approach the chant gets louder and begins to mimic a hum.\n" +
                            "This hum is eerily familiar to you. Its the hum of the Monolith.\n" +
                            "With a mounting sense of urgency, you cover your ears as you approach the camp,\n");
                        Console.ReadKey();
                        MakeShiftCamp();
                        break;

                    case 1:
                        Console.WriteLine("Using the shadows to your advantage you sneak past the chanting soldiers");
                        Console.ReadKey();
                        NextEncounter(typeof(FinalCorridorSection));
                        break;
                    case 2:
                        Console.WriteLine("You pick up a large screw like bolt and toss it an metal container. It makes a loud clang.\n" +
                            "The guards are unphased by the sound and continue their chant");
                        Console.ReadKey();
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

                string prompt = ($"\nApproaching the chanting soldiers with stealth and silence,\n" +
                    $"you discern the object of their devotion at the center of the camp. It resembles a spring,\n" +
                    $"its spongy encased exterior emitting a faint grating sound with each reverberating chant.\n" +
                    $"Sensing its potential significance, you recognize the value of this enigmatic item amidst the eerie scene.\n\n");

                string[] options = { "1.Try to sneak in the camp and grab the object.", "2.Silently take out as many of these soldiers as possible.", "3.Forget what you have seen and head back from where you came.", $"4.Use FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "5.Check Player Stats." };
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine("Approaching the mysterious object within the heart of the camp,\n" +
                            "you move with cautious steps, mindful of the escalating hum permeating the air.\n" +
                            "The resonance of the hum intensifies with each stride,\n" +
                            "building a palpable tension as your hand inches closer to the enigmatic artifact.\n" +
                            "As your fingertips make contact, the deafening hum abruptly ceases,\n" +
                            "triggering an immediate reaction from the dormant soldiers surrounding you.\n" +
                            "A surge of energy courses through your veins as the object unleashes a blinding flash,\n" +
                            "momentarily obscuring your vision. Blinking away the disorientation,\n" +
                            "you find yourself met with an empty space where the object once rested.\n" +
                            "Taking a moment to collect your thoughts, you survey the scene,\n" +
                            "only to be confronted by the grim sight of the soldiers reduced to deformed melted husks,\n" +
                            "a haunting testament to the power that had been unleashed.\n" +
                            "As you scavenge the area for anything salvageable, your search yields only a few crumpled rubles amidst the chaos.");
                        Console.ReadKey();
                        Console.WriteLine("You gained 1000 rubles");
                        _gameManager.SelectedMainPlayer.Rubles = +1000;
                        Console.ReadKey();
                        break;

                    case 1:
                        Console.WriteLine("Approaching the mysterious object nestled deep within the camp,\n" +
                            "your movements are deliberate,\n" +
                            "each step calculated to avoid detection amidst the escalating hum that resonates through the air.\n" +
                            "With each passing moment, the hum grows louder, a persistent reminder of the impending unknown.\n" +
                            "As you cautiously maneuver through the shadows,\n" +
                            "wielding an antiquated military bayonet with practiced precision,\n" +
                            "you silently dispatch the unsuspecting soldiers one by one.\n" +
                            "As you draw nearer to the object, the hum reaches a crescendo,\n" +
                            "an unbearable cacophony that rattles your senses to their core before abruptly falling silent.\n" +
                            "In the deafening stillness that follows, the two remaining soldiers emerge from their trance-like state.\n" +
                            "They immediately realize their fallen comrades and train their rifles on you.");
                        Console.ReadKey();
                        BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[8]);
                        Console.WriteLine("Before you can even catch your breath you have to fight an other soldier");
                        Console.ReadKey();
                        BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[9]);
                        Console.WriteLine("With your adversaries vanquished, you stride confidently toward the enigmatic object.\n" +
                            "As you reach out to touch the object,\n" +
                            "a wave of energy washes over you, suffusing every fiber of your being with vitality.\n" +
                            "Your body feels invigorated, your spirit fortified against the trials that lie ahead.\n" +
                            "With a newfound sense of strength coursing through your veins, you realize that your maximum health has increased by 10!");
                        Console.ReadKey();
                        _gameManager.SelectedMainPlayer.MaxHealth += 10;
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
