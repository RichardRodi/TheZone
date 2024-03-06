using TheZone.Menus;
using TheZone.Printer;

namespace TheZone.Encounters
{
    public class FirstEncounter
    {
        public void RunFirstChoice()
        {

            string prompt = $"\n\n Enveloped within the swirling vortex of a dream,\n you find yourself confronted by a towering presence:\n " +
                $"a Massive Monolith stretches out before you.\n" +
                $" Its surface emits a faint, rhythmic pulse that intensifies,\n" +
                $" overwhelming your senses with a deafening roar. As the sound crescendos to an unbearable level,\n" +
                $" you instinctively cover your ears, but find no relief.\n You try to scream but no air fills your lungs, no voice escapes your lips.\n" +
                $" Darkness descends; and you awaken to the sensation of damp earth beneath you, face-down in a marsh.\n" +
                $" The once-pervasive hum of the Monolith is replaced by the crackling static of your Geiger Meter.\n" +
                $" You have entered the Zone\n\n\n";

            string[] options = { "Turn Off your Geiger Meter and walk towards a small structure about 300 meters away.\n", "Keep your Geiger On and walk towards a small structure about 300 meters away.\n", "Look Around.\n" };
            Menu firstChoiceMenu = new Menu(prompt, options);
            int selectedIndex = firstChoiceMenu.Run();
            
            switch (selectedIndex)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("\n Devoid of your Geiger Meter's help to guide your steps You stagger blindly through the radioactive marsh,\n " +
                        "Before long, you find yourself ensnared within a vast pool of irradiated liquid.\n " +
                        "Initially, a sense of lightheadedness grips you, followed by the unmistakable metallic tang upon your tongue.\n " +
                        "The world around you dims rapidly as consciousness slips away.\n " +
                        "In the end, darkness claims another casualty of The Zone.\n");
                    DeathMenu deathMenu = new DeathMenu();
                    deathMenu.DeathScreen();
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadKey(true);
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.RunMainMenu();
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("\n\n You walk carefully through the swamp as you avoid the areas that crackle from your Geiger Meter.");
                    Console.ReadKey(true);
                    Console.Clear();
                    EncounterCreateCharacterClass newCharacter = new EncounterCreateCharacterClass();
                    newCharacter.RunCharacterCreateEncounterName();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine(" You spy a vast and expansive swamp.\n Its landscape punctuated by a scattering of decaying structures stretching across the horizon.\n You still need to make a decision about your Geiger Meter\n");
                    Console.ReadKey(true);
                    RunFirstChoice();
                    break;
            }
        }
    }
}
