using TheAnomalousZone.Encounters;
using TheAnomalousZone.Encounters.Enemies;
using TheAnomalousZone.Encounters.Swamp;
using TheAnomalousZone.MainCharacter;

namespace TheAnomalousZone
{
    public class GameManager
    {
        public MainPlayer SelectedMainPlayer { get; set; }

        public List<MainPlayer> AllMainCharacters { get; set; } = new List<MainPlayer>();

        public List<BaseEnemy> Enemies { get; set; } = new List<BaseEnemy>();

        public List<BaseEncounter> Encounters { get; set; } = new List<BaseEncounter>();

        public GameManager(bool seedData = false)
        {
            if (seedData)
            {
                GenerateMainCharacter();
                GenerateAllEnemies();
                GenerateAllEncounters();
            }
        }

        public void GenerateMainCharacter()
        {

            AllMainCharacters.Add(new MainPlayer(name: "Sergei", health: 40, radiation: 0, damage: 1, armorValue: 6,
                firstAid: 1, weaponValue: 10, ammunition: 50, speed: 5, numberOfShotsFired: 3, "You were a soldier in the Ukranian Army"));

            AllMainCharacters.Add(new MainPlayer(name: "Artyom", health: 20, radiation: 0, damage: 1, armorValue: 3,
                firstAid: 2, weaponValue: 20, ammunition: 20, speed: 5, numberOfShotsFired: 1, "You were a sniper in the Ukranian Army"));

            AllMainCharacters.Add(new MainPlayer(name: "Dimitri", health: 30, radiation: 0, damage: 1, armorValue: 5,
                firstAid: 1, weaponValue: 3, ammunition: 50, speed: 5, numberOfShotsFired: 2, "You were a scientist in the Ukranian Army"));
        }


        public void GenerateAllEnemies()
        {

            Enemies.Add(new Bandits("Bandit Soldier", health: 15, damage: 1, armorValue: 4,
                firstAid: 1, weaponValue: 5, ammunition: 25, speed: 5, numberOfShotsFired: 3));

            Enemies.Add(new Bandits("Bandit Leader", health: 20, damage: 1, armorValue: 5,
                firstAid: 2, weaponValue: 15, ammunition: 20, speed: 5, numberOfShotsFired: 1));

            Enemies.Add(new Bandits("Bandit Scout", health: 10, damage: 1, armorValue: 5,
                firstAid: 1, weaponValue: 3, ammunition: 50, speed: 5, numberOfShotsFired: 2));

            Enemies.Add(new MutatedAnimals("MutatedBoar", health: 23, damage: 1, armorValue: 4, radiationDamage: 1,
                  speed: 5, "This is a mutated boar"));

            Enemies.Add(new MutatedAnimals("MutatedChimera", health: 20, damage: 1, armorValue: 5, radiationDamage: 1,
            speed: 5, "This is a mutated chimera"));

            Enemies.Add(new MutatedAnimals("MutatedSnork", health: 10, damage: 1, armorValue: 5, radiationDamage: 1,
                 speed: 5, "This is a mutated snork"));
        }


        public void GenerateAllEncounters()
        {
            // Instantiate All Encounters //
            var spaceEncounter = new SpaceEncounter(this);
            Encounters.Add(spaceEncounter);

            var swampIntro = new SwampIntro(this);
            Encounters.Add(swampIntro);

            var dilapidatedBuilding = new DilapidatedBuilding(this);
            Encounters.Add(dilapidatedBuilding);

            var wareHouse = new WareHouse(this);
            Encounters.Add(wareHouse);

        }
        public void RunGame()
        {
            TitlePage mainMenu = new TitlePage();


            var generateMainCharacter = mainMenu.RunTitlePage();
            if (generateMainCharacter)
            {
                IntroCharacterCreation createMainCharacter = new IntroCharacterCreation(this);
            }

            //You have everything you need to run an encounter 

            Encounters.Where(x => x.GetType() == typeof(SwampIntro)).FirstOrDefault().RunEncounter();

        }

    }
}
