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
            string prompt = ($"Injured but not finished you venture further into the bowels of the power plant,\n" +
                $"you are immediately met with an otherworldly sight:\n" +
                $"A colossal chamber covered with eerily still and silent sand dunes.\n" +
                $"Towering pillars stretch towards a crumbling ceiling, eerie moonlight streams through ceiling's cracks.\n" +
                $"Passing through the center of these pillars,\n" +
                $"you venture into a dark hallway, only to emerge once more into the same room.\n" +
                $"With each attempt to navigate the space,\n" +
                $"it becomes clear that you are ensnared in a perplexing loop.\n" +
                $"Is there an escape from this confounding puzzle? Here is the layout of the room\n\n" +
                $" {TitleArtAssets.FloorPlan}" +
                $"\n\n");

            string[] options = { "1.Walk through the opening between the left wall and left pillar", "2.Walk through the center of the room between the right and left pillar.", "3.Walk between the right wall and the right pillar." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("As you traverse the expansive space between the left wall and pillar,\n" +
                        "a rush of air and a sudden blaze of light greet you as you cross the threshold,\n" +
                        "finding yourself back at the room's entrance.");
                    Console.ReadKey();
                    MazeEntrance();
                    break;

                case 1:
                    Console.WriteLine("As you traverse the expansive space in the center of the room between the right and left pillar.\n" +
                        "a rush of air and a sudden blaze of light greet you as you cross the threshold,\n" +
                        "finding yourself back at the room's entrance.");
                    Console.ReadKey();
                    MazeEntrance();
                    break;
                case 2:
                    Console.WriteLine("Nothing happens as you walk through the threshold of the right wall and the right pillar.\n" +
                        "You need to make another decision to proceed");
                    Console.ReadKey();
                    MazeSecondPillar();
                    break;

            }

        }
        private void MazeEntrance()
        {
            string prompt = ($"Back at the entrance of this confounding room,\n" +
                $"it becomes clear that you are ensnared in a perplexing loop.\n" +
                $"Is there an escape from this confounding puzzle? Here is the layout of the room\n\n" +
                $" {TitleArtAssets.FloorPlan}" +
                $"\n\n");

            string[] options = { "1.Walk through the opening between the left wall and left pillar.", "2.Walk through the center of the room between the right and left pillar.", "3.Walk between the right wall and the right pillar." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("As you traverse the expansive space between the left wall and pillar,\n" +
                        "a rush of air and a sudden blaze of light greet you as you cross the threshold,\n" +
                        "finding yourself back at the room's entrance.");
                    Console.ReadKey();
                    MazeEntrance();
                    break;

                case 1:
                    Console.WriteLine("As you traverse the expansive space in the center of the room between the right and left pillar.\n" +
                        "a rush of air and a sudden blaze of light greet you as you cross the threshold,\n" +
                        "finding yourself back at the room's entrance.");
                    Console.ReadKey();
                    MazeEntrance();
                    break;
                case 2:
                    Console.WriteLine("Nothing happens as you walk through the threshold of the right wall and the right pillar.\n" +
                        "You need to make another decision to proceed.");
                    Console.ReadKey();
                    MazeSecondPillar();
                    break;

            }

        }
        private void MazeSecondPillar()
        {
            string prompt = ($"Standing in the center of the massive room\n" +
                $"you have an other decision to make." +
                $"\n\n");

            string[] options = { "1.Walk through the opening between the left wall and left pillar", "2.Walk through the center of the room between the right and left pillar.", "3.Walk between the right wall and the right pillar." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("Nothing happens as you walk through the threshold of the left wall and the left pillar.\n" +
                        "You need to make another decision to proceed.");
                    Console.ReadKey();
                    MazeThirdPillar();
                    break;

                case 1:
                    Console.WriteLine("As you traverse the expansive space in the center of the room between the right and left pillar.\n" +
                        "a rush of air and a sudden blaze of light greet you as you cross the threshold,\n" +
                        "finding yourself back at the room's entrance.");
                    Console.ReadKey();
                    MazeEntrance();
                    break;
                case 2:
                    Console.WriteLine("As you traverse the expansive space between the right wall and pillar,\n" +
                        "a rush of air and a sudden blaze of light greet you as you cross the threshold,\n" +
                        "finding yourself back at the room's entrance.");
                    Console.ReadKey();
                    MazeEntrance();
                    break;

            }
        }
        private void MazeThirdPillar()
        {
            string prompt = ($"Back at the entrance of this confounding room,\n" +
              $"it becomes clear that you are ensnared in a perplexing loop.\n" +
              $"Is there an escape from this confounding puzzle? Here is the layout of the room\n\n" +
              $" {TitleArtAssets.FloorPlan}" +
              $"\n\n");
            string[] options = { "1.Walk through the opening between the left wall and left pillar", "2.Walk through the center of the room between the right and left pillar.", "3.Walk between the right wall and the right pillar." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();
            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("As you traverse the expansive space between the left wall and pillar,\n" +
                        "a rush of air and a sudden blaze of light greet you as you cross the threshold once more,\n" +
                        "finding yourself back at the room's entrance.");
                    Console.ReadKey();
                    MazeEntrance();
                    break;

                case 1:
                    Console.WriteLine("As you step through the threshold of the room's center,\n" +
                        "a profound sense of tranquility washes over you.\n" +
                        "The rhythmic echoes of the Monolith resonate gently in your ears.\n" +
                        "Exiting the eerie chamber, you emerge into a soothing, warm glow of light.");
                    Console.ReadKey();
                    NextEncounter(typeof(MonolithEnd));
                    break;
                case 2:
                    Console.WriteLine("As you traverse the expansive space between the right wall and pillar,\n" +
                        "a rush of air and a sudden blaze of light greet you as you cross the threshold once more,\n" +
                        "finding yourself back at the room's entrance.");
                    Console.ReadKey();
                    MazeEntrance();
                    break;

            }
        }
    }
}
