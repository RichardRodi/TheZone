using TheAnomalousZone.Enemies;
using TheAnomalousZone.MainCharacter;

namespace TheAnomalousZone.Combat
{
    public static class RunAway
    {
        public static bool Run(MainPlayer player, BaseEnemy enemy)

        {
            if (player.Speed >= enemy.Speed)

            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
