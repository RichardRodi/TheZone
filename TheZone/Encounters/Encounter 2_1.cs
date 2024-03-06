using TheZone.Base;
using TheZone.Menus;

namespace TheZone.Encounters
{
    public class Encounter2_1 : EncounterCreateCharacterClass
    {
        public void Encounter2of1()
        {

            string prompt = "\n\n After Fighting that boar you look at around and see there two buildings in front of you, \n One building has smoke billowing from it,\n the other is " +
                "caved in and derelict.\n\n\n";

            string[] options = { "Walk towards the building with smoke coming out of it.\n", "Walk towards the derelict building.\n", "Look Around.\n", "Check Stats.\n" };
            Menu firstChoiceMenu = new Menu(prompt, options);
            int selectedIndex = firstChoiceMenu.Run();

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
            }
        }
    }
}
