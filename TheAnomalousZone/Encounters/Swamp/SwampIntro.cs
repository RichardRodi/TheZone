using TheAnomalousZone.MainCharacter;
using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.Swamp
{
    public class SwampIntro : BaseEncounter
    {
        private GameManager _gameManager;

        public SwampIntro(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public override void RunEncounter()
        {

            string prompt = ($"\n\nLooking Around you realize that you are standing in the middle of a crossroads.\n" +
                $"To your left is a small dilapidated building.\n" +
                $"To your right smoke rises up from what appears to a makeshift camp\n\n");

            string[] options = { "1.Head to your Left", "2.Head to your Right", "3.Look Around", "4.Check Stats\n\n" };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:

                    Console.WriteLine("You start to head towards the dilapidated building when you hear a rustling in a nearby bush");
                    Console.ReadKey(true);
                    NextEncounter(typeof(DilapidatedBuilding));
                    break;
                case 1:

                    Console.WriteLine("You start to head towards the makeshift camp when you hear a voice call out to you in a commanding voice");
                    NextEncounter(typeof(WareHouse));
                    break;
                case 2:
                    Console.WriteLine("You see a vast and expansive swamp");
                    Console.ReadKey(true);

                    break;
                case 3:
                    
                    Console.ReadKey(true);
                    
                    break;

            }

            Console.ResetColor();
        }


        public override void NextEncounter(Type encounterType)
        {
            _gameManager.Encounters.Where(x => x.GetType() == encounterType).FirstOrDefault().RunEncounter();

        }

    }
}
