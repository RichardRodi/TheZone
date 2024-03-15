using TheAnomalousZone.MainCharacter;

namespace TheAnomalousZone.Encounters
{
    /// <summary>
    /// Anything that defines an Encounter and can be shared ///
    /// </summary>
    public abstract class BaseEncounter
    {
        public string EncounterName { get; set; } = string.Empty;
        public abstract void RunEncounter();
        public abstract void NextEncounter(Type encounterType);
    }
}
