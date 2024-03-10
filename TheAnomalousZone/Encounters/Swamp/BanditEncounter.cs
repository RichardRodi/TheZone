using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAnomalousZone.MainCharacter;
using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.Swamp
{
    internal class BanditEncounter
    {
        public static void RunEncounter(MainPlayer player)

        {

            string prompt = ($"You are faced with a large intimidating man in a Trench Coat. What do you do?");

            string[] options = { "Raise you rifle to fire at it!", "Run!", "Take a Closer look at the Boar" };
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

            }

            Console.ResetColor();
        }
    }
}
