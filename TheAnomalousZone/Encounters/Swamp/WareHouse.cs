using System.Numerics;
using TheAnomalousZone.Combat;
using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.Swamp
{
    internal class WareHouse : BaseEncounter
    {
        private GameManager _gameManager;

        public WareHouse(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public override void NextEncounter(Type encounterType)
        {
            throw new NotImplementedException();
        }

        public override void RunEncounter()
        {
            string prompt = ($"Welcome");

            string[] options = { "Fight", "Credits", "Exit" };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("You raise your Rifle and at the wild boar");
                    Console.ReadKey(true);
                    PlayerFirstCombat.Fight(_gameManager.SelectedMainPlayer, _gameManager.Enemies[3]);
                   
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
