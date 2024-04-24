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

                string prompt = ($"\nAs you advance toward the looming power plant structure at the valley's end,\n" +
                    $"signs of human habitation come into view directly ahead. The camp appears haphazard and makeshift,\n" +
                    $"with a towering fire casting flickering shadows against the surrounding landscape.\n" +
                    $"As you approach you notice the men are wearing the same uniforms as the fallen soldiers with eclipsed sun insignia.\n");

                string[] options = { "1.Sneak up to the camp.", "2.Sneak past the camp", "3.Create a distraction by throwing something.", "4.Use FirstAid Kit.", "5.Check Stats." };
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine("You sneak up to the makeshift camp.\n" +
                            "As you get closer you notice that the soldiers are all making a unique sound." +
                            "They seem to be chanting in unison. A sort of hum.\n" +
                            "As you approach the chant gets louder and begins to mimic a hum.\n" +
                            "This hum is familiar to you. Its that of the Monolith.\n " +
                            "With a mounting sense of urgency, you realize that without intervention,\n" +
                            "You may succumb to the enchanting sway of their chant, slipping away into oblivion.");
                        Console.ReadKey();
                        MakeShiftCamp();
                        break;

                    case 1:
                        Console.WriteLine("Using the shadows to your advantage you sneak past the chanting soldiers");
                        Console.ReadKey();
                        //RunEncounter();
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
                    $"you discern the object of their devotion at the center of the camp. It stands tall,\n" +
                    $"its spongy encased exterior emitting a faint grating sound with each reverberating chant.\n" +
                    $"Sensing its potential significance, you recognize the value of this enigmatic item amidst the eerie scene.");

                string[] options = { "1.Try to sneak in the camp and grab the object.", "2.Silently take out as many of these soldiers as possible.", "3.Forget what you have seen and head back from where you came.", "4.Use FirstAid Kit.", "5.Check Stats." };
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:

                        break;

                    case 1:

                        break;
                    case 2:

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
