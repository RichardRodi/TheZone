using TheAnomalousZone.MainCharacter;
using TheAnomalousZone.Menus;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Combat
{
    public static class DeathCheck
    {
        public static void IsALive(MainPlayer player)

        {
            if (player.Health <= 0)

            {
                SlowPrint.Print($" {player.Name} has ceased to be alive!");
                Console.ReadKey(true);
                var deathmenu = new DeathMenu();
                deathmenu.RunEncounter();
            }


        }

    }
}
