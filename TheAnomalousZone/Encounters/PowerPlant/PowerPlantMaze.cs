using TheAnomalousZone.NewFolder;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Encounters.PowerPlant
{
    internal class PowerPlantMaze : BaseEncounter
    {
        private GameManager _gameManager;

        public PowerPlantMaze(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public override void NextEncounter(Type encounterType)
        {
            _gameManager.Encounters.Where(x => x.GetType() == encounterType).FirstOrDefault().RunEncounter();
        }

        public override void RunEncounter()
        {
            string prompt = ($"\n\tInjured but not finished you venture further into the bowels of the power plant,\n" +
                $"\tyou are immediately met with an otherworldly sight:\n" +
                $"\tA colossal chamber covered with eerily still and silent sand dunes.\n" +
                $"\tTowering pillars stretch towards a crumbling ceiling, eerie moonlight streams through ceiling's cracks.\n" +
                $"\tPassing through the center of these pillars,\n" +
                $"\tyou venture into a dark hallway, only to emerge once more into the same room.\n" +
                $"\tWith each attempt to navigate the space,\n" +
                $"\tit becomes clear that you are ensnared in a perplexing loop.\n" +
                $"\tIs there an escape from this confounding puzzle? Here is the layout of the room.\n\n" +
                $"\t{TitleArtAssets.FloorPlanFirst}" +
                $"\n\n");

            string[] options = { "1.Walk through the opening between the left wall and left pillar", "2.Walk through the center of the room between the right and left pillar.", "3.Walk between the right wall and the right pillar." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("\n\tAs you traverse the expansive space between the left wall and pillar,\n" +
                        "\ta rush of air and a sudden blaze of light greet you as you cross the threshold,\n" +
                        "\tfinding yourself back at the room's entrance.\n" +
                        "\tYou chose incorrectly, you have to start over from the beginning.");
                    Console.ReadKey(true);
                    MazeEntrance();
                    break;

                case 1:
                    Console.WriteLine("\n\tAs you traverse the expansive space in the center of the room between the right and left pillar.\n" +
                        "\ta rush of air and a sudden blaze of light greet you as you cross the threshold,\n" +
                        "\tfinding yourself back at the room's entrance.\n" +
                        "\tYou chose incorrectly, you have to start over from the beginning.");
                    Console.ReadKey(true);
                    MazeEntrance();
                    break;
                case 2:
                    Console.WriteLine("\n\tNothing happens as you walk through the threshold of the right wall and the right pillar.\n" +
                        "\tYou need to make another decision to proceed.You chose correctly.\n" +
                        "\tYou must continue on and choose the correct path.");
                    Console.ReadKey(true);
                    MazeSecondPillar();
                    break;

            }

        }
        private void MazeEntrance()
        {
            string prompt = ($"\n\tBack at the entrance of this confounding room,\n" +
                $"\tit becomes clear that you are ensnared in a perplexing loop.\n" +
                $"\tIs there an escape from this confounding puzzle? Here is the layout of the room.\n\n" +
                $"\t{TitleArtAssets.FloorPlanFirst}" +
                $"\n\n");

            string[] options = { "1.Walk through the opening between the left wall and left pillar.", "2.Walk through the center of the room between the right and left pillar.", "3.Walk between the right wall and the right pillar." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("\n\tAs you traverse the expansive space between the left wall and pillar,\n" +
                        "\ta rush of air and a sudden blaze of light greet you as you cross the threshold,\n" +
                        "\tfinding yourself back at the room's entrance\n" +
                        "\tYou chose incorrectly, you have to start over from the beginning.");
                    Console.ReadKey(true);
                    MazeEntrance();
                    break;

                case 1:
                    Console.WriteLine("\n\tAs you traverse the expansive space in the center of the room between the right and left pillar.\n" +
                        "\ta rush of air and a sudden blaze of light greet you as you cross the threshold,\n" +
                        "\tfinding yourself back at the room's entrance. You chose incorrectly,\n" +
                        "\tyou have to start over from the beginning.");
                    Console.ReadKey(true);
                    MazeEntrance();
                    break;
                case 2:
                    Console.WriteLine("\n\tNothing happens as you walk through the threshold of the right wall and the right pillar.\n" +
                        "\tYou need to make another decision to proceed. You chose correctly.\n" +
                        "\tYou must continue on and choose the correct path.");
                    Console.ReadKey(true);
                    MazeSecondPillar();
                    break;

            }

        }
        private void MazeSecondPillar()
        {
            string prompt = ($"\n\tStanding in the center of the massive room\n" +
                $"\tyou have an other decision to make.\n" +
                $"\t{TitleArtAssets.FloorPlanSecond}\n\n" +
                $"\n\n");

            string[] options = { "1.Walk through the opening between the left wall and left pillar", "2.Walk through the center of the room between the right and left pillar.", "3.Walk between the right wall and the right pillar." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("\n\tNothing happens as you walk through the threshold of the left wall and the left pillar.\n" +
                        "\tYou need to make another decision to proceed. You chose correctly.\n" +
                        "\tYou must continue on and choose the correct path.");
                    Console.ReadKey(true);
                    MazeThirdPillar();
                    break;

                case 1:
                    Console.WriteLine("\n\tAs you traverse the expansive space in the center of the room between the right and left pillar.\n" +
                        "\ta rush of air and a sudden blaze of light greet you as you cross the threshold,\n" +
                        "\tfinding yourself back at the room's entrance.\n" +
                        "\tYou chose incorrectly, you have to start over from the beginning.");
                    Console.ReadKey(true);
                    MazeEntrance();
                    break;
                case 2:
                    Console.WriteLine("\n\tAs you traverse the expansive space between the right wall and pillar,\n" +
                        "\ta rush of air and a sudden blaze of light greet you as you cross the threshold,\n" +
                        "\tfinding yourself back at the room's entrance.\n" +
                        "\tYou chose incorrectly, you have to start over from the beginning.");
                    Console.ReadKey(true);
                    MazeEntrance();
                    break;

            }
        }
        private void MazeThirdPillar()
        {
            string prompt = ($"\n\tStanding towards the end of the massive room\n" +
                $"\tyou have an other decision to make.\n" +
                $"\t{TitleArtAssets.FloorPlanThird}\n\n" ); 
        
            string[] options = { "1.Walk through the opening between the left wall and left pillar", "2.Walk through the center of the room between the right and left pillar.", "3.Walk between the right wall and the right pillar." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();
            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("\n\tAs you traverse the expansive space between the left wall and pillar,\n" +
                        "\ta rush of air and a sudden blaze of light greet you as you cross the threshold once more,\n" +
                        "\tfinding yourself back at the room's entrance.\n" +
                        "\tYou chose incorrectly, you have to start over from the beginning.");
                    Console.ReadKey(true);
                    MazeEntrance();
                    break;

                case 1:
                    Console.WriteLine("\n\tAs you step through the threshold of the room's center,\n" +
                        "\ta profound sense of tranquility washes over you.\n" +
                        "\tThe rhythmic echoes of the Monolith resonate gently in your ears.\n" +
                        "\tExiting the eerie chamber, you emerge into a soothing, warm glow of light.");
                    Console.ReadKey(true);
                    NextEncounter(typeof(MonolithEnd));
                    break;
                case 2:
                    Console.WriteLine("\n\tAs you traverse the expansive space between the right wall and pillar,\n" +
                        "\ta rush of air and a sudden blaze of light greet you as you cross the threshold once more,\n" +
                        "\tfinding yourself back at the room's entrance.\n" +
                        "\tYou chose incorrectly, you have to start over from the beginning.");
                    Console.ReadKey(true);
                    MazeEntrance();
                    break;

            }
        }
    }
}
