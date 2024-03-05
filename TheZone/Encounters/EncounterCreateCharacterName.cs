using TheZone.Combat;
using TheZone.Enemies;
using TheZone.MainPlayers;
using TheZone.Menus;

namespace TheZone.Encounters
{
    public class EncounterCreateCharacterName
    {
        public void RunCharacterCreateEncounterName()
        {

            string prompt = $"As you head towards the Small building in this Marshy Swamp you realize that your memory is coming back to you.\n You remember you were a:\n\n";


            string[] options = { "Soldier.\n", "Scout.\n", "Scientist.\n", };
            Menu firstChoiceMenu = new Menu(prompt, options);
            int selectedIndex = firstChoiceMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("\n Gripping your Ak patterned Rifle you remember you were a soldier. \n");
                    MainPlayer newSoldier = new MainPlayer(" Sergeant Artyom.", health: 10, radiation: 10, armorValue: 9, firstaid: 1, damage: 1, weaponValue: 10);
                    Console.WriteLine($" You remember your name is {newSoldier.Name}");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine(" As quickly as you remember your who you are there is a rustling of something in the bushes,\n Suddenly a giant mutated boar charges you!");
                    MutatedBoar newBoarSoldier = new MutatedBoar("Boar1", 10, 5, 5);
                    Console.ReadKey();
                    CombatMutant.Fight(newSoldier, newBoarSoldier);
                    Console.ReadKey(true);

                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Grabbing you Bolt Action Rifle you remember you were a sniper in the Military.");
                    MainPlayer newSniper = new MainPlayer("Sniper Sergei.", health: 30, radiation: 0, armorValue: 3, firstaid: 2, damage: 1, weaponValue: 25);
                    Console.WriteLine($" You remember your name is {newSniper.Name}");
                    Console.WriteLine(" As quickly as you remember your who you are there is a rustling of something in the bushes,\n Suddenly a giant mutated boar charges you!");
                    MutatedBoar newBoarSniper = new MutatedBoar("Boar1", 10, 5, 5);
                    Console.ReadKey(true);
                    CombatMutant.Fight(newSniper, newBoarSniper);
                    Console.WriteLine($" You remember your name is {newSniper.Name}");
                    Console.ReadKey(true);

                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine(" Grabbing your scientific instruments and a small caliber handgun you remember you were a Scientist.");
                    MainPlayer newScientist = new MainPlayer("Sniper Sergei.", health: 50, radiation: 3, armorValue: 5, firstaid: 4, damage: 1, weaponValue: 5);
                    Console.WriteLine($" You remember your name is {newScientist.Name}");
                    Console.WriteLine(" As quickly as you remember your who you are there is a rustling of something in the bushes,\n Suddenly a giant mutated boar charges you!");
                    MutatedBoar newBoarScientist = new MutatedBoar("Boar1", 10, 5, 5);
                    Console.ReadKey(true);
                    CombatMutant.Fight(newScientist, newBoarScientist);
                    Console.ReadKey(true);
                    break;


            }
        }
    }
}
