using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.Swamp
{
    internal class AbandonedChurch : BaseEncounter
    {
        private GameManager _gameManager;

        public AbandonedChurch(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public override void NextEncounter(Type encounterType)
        {
            _gameManager.Encounters.Where(x => x.GetType() == encounterType).FirstOrDefault().RunEncounter();
        }

        public override void RunEncounter()
        {
            {

                string prompt = ($"");

                string[] options = { "1.Play Game", "2.Credits", "3.Exit", "4. Use FirstAid Kit", "5.Check Stats" };
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
                        _gameManager.SelectedMainPlayer.Heal(_gameManager.Items[0].AmountToHeal);
                        Console.ReadKey(true);
                        break;
                    case 4:
                        _gameManager.SelectedMainPlayer.DisplayStats();
                        Console.ReadKey(true);
                        Console.Clear();

                        break;

                }
            }
        }
    }
}
