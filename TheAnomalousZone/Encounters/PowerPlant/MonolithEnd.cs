using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.PowerPlant
{
    public class MonolithEnd : BaseEncounter
    {
        private GameManager _gameManager;

        public MonolithEnd(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public override void NextEncounter(Type encounterType)
        {
            throw new NotImplementedException();
        }
        public override void RunEncounter()
        {
            {

                string prompt = ($"\nStepping into the vast chamber that once housed this facility's reactor,\n" +
                    $"one is immediately struck by the solemn testament to the cataclysmic events of decades past.\n" +
                    $"The walls, etched with scars from the relentless onslaught of heat and radiation,\n" +
                    $"bear silent witness to the unfathomable horrors that unfolded within.\n" +
                    $"Amidst the remnants of a bygone era,\n" +
                    $"rusted control panels and dead monitors stand as ghostly relics.\n" +
                    $"At the heart of the room looms a monstrous mass,\n" +
                    $"an amalgamation of congealed substances emanating from the decaying reactor's core.\n" +
                    $"Rising towards the partially exposed sky, \n" +
                    $"this mass commands attention with its glossy sheen,\n" +
                    $"transitioning from stark clarity to an ominous darkness as it ascends towards the ceiling.\n" +
                    $"It is here, in the presence of this imposing structure,\n" +
                    $"that a booming voice resonates, penetrating every fiber of one's being,\n" +
                    $"posing the profound question: What is your desire?\n\n");

                string[] options = { "1.I desire wealth.", "2.I desire power,", "3.I desire all knowledge.", "4.I desire love.", "5.I desire destruction." };
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
                        
                        break;
                    case 4:
                       
                        break;

                }
            }
        }
    }
}
