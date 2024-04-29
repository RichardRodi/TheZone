using TheAnomalousZone.MainCharacter;

namespace TheAnomalousZone.Encounters
{
  
    public abstract class BaseEncounter
    {
        public string EncounterName { get; set; } = string.Empty;
        public abstract void RunEncounter();
        public abstract void NextEncounter(Type encounterType);
    }
}
