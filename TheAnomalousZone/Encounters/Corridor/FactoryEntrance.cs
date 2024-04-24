namespace TheAnomalousZone.Encounters.Corridor
{
    internal class FactoryEntrance : BaseEncounter
    {
        private GameManager _gameManager;
        public FactoryEntrance(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public override void NextEncounter(Type encounterType)
        {
            throw new NotImplementedException();
        }

        public override void RunEncounter()
        {
            throw new NotImplementedException();
        }
    }
}
