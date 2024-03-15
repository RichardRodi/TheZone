namespace TheAnomalousZone.Encounters
{
    public class SpaceEncounter : BaseEncounter
    {
        public GameManager _gameManager;
        public SpaceEncounter()
        {

        }
        public SpaceEncounter(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public override void RunEncounter()
        {
            // Encounter Logic //

            // Run Next Encounter //

            // switch //

            // Based on results - output a specific encounter type //


        }

        public override void NextEncounter(Type type)
        {
            _gameManager.Encounters.Where(x => x.GetType() == type).FirstOrDefault().RunEncounter();
        }
    }
}
