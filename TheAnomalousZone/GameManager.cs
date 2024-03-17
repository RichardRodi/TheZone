using TheAnomalousZone.Encounters;
using TheAnomalousZone.Encounters.Swamp;
using TheAnomalousZone.Enemies;
using TheAnomalousZone.Items;
using TheAnomalousZone.MainCharacter;

namespace TheAnomalousZone
{
    public class GameManager
    {
        public MainPlayer SelectedMainPlayer { get; set; }

        public List<MainPlayer> AllMainCharacters { get; set; } = new List<MainPlayer>();

        public List<BaseEnemy> Enemies { get; set; } = new List<BaseEnemy>();

        public List<BaseEncounter> Encounters { get; set; } = new List<BaseEncounter>();

        public List<ItemBase> Items { get; set; } = new List<ItemBase>();

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

            AllMainCharacters.Add(new MainPlayer(name: "Sergei", health: 50, radiation: 0, damage: 2, armorValue: 8,
                firstAid: 2, weaponValue: 15, ammunitionPerMagazine: 10, speed: 4, numberOfShotsFired: 3, "You were a soldier in the Ukranian Army"));

            AllMainCharacters.Add(new MainPlayer(name: "Artyom", health: 40, radiation: 0, damage: 1, armorValue: 5,
                firstAid: 3, weaponValue: 25, ammunitionPerMagazine: 5, speed: 6, numberOfShotsFired: 1, "You were a sniper in the Ukranian Army"));

            AllMainCharacters.Add(new MainPlayer(name: "Dimitri", health: 30, radiation: 0, damage: 1, armorValue: 7,
                firstAid: 1, weaponValue: 3, ammunitionPerMagazine: 3, speed: 5, numberOfShotsFired: 2, "You were a scientist in the Ukranian Army"));
        }


        public void GenerateAllEnemies()
        {

            Enemies.Add(new Bandits("Bandit Soldier", health: 20, damage: 1, armorValue: 3,
                firstAid: 1, weaponValue: 8, ammunition: 20, speed: 5, numberOfShotsFired: 3));

            Enemies.Add(new Bandits("Bandit Leader", health: 20, damage: 1, armorValue: 4,
                firstAid: 2, weaponValue: 18, ammunition: 15, speed: 5, numberOfShotsFired: 1));

            Enemies.Add(new Bandits("Bandit Scout", health: 15, damage: 1, armorValue: 2,
                firstAid: 1, weaponValue: 5, ammunition: 30, speed: 7, numberOfShotsFired: 2));

            Enemies.Add(new MutatedAnimals("MutatedBoar", health: 60, damage: 5, armorValue: 4, radiationDamage: 1,
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
        public void GenerateAllArmors()

        {
            Items.Add(new Armor(iD: 1, "Merc Suit", price: 500, armorValue: 7));

            Items.Add(new Armor(iD: 1, "Seva Suit", price: 500, armorValue: 9));

            Items.Add(new Armor(iD: 1, "Beryl Suit", price: 500, armorValue: 11));

            Items.Add(new Armor(iD: 1, "ExoSkeleton", price: 500, armorValue: 15));
        }

        public void GenerateAllFirstAid()
        {
            Items.Add(new FirstAidKit(iD: 0, "Basic FirstAid Kit", amountToHeal: 30, price: 1000));
        }

        public void RunGame()
        {
            TitlePage mainMenu = new TitlePage();


            var generateMainCharacter = mainMenu.RunTitlePage();
            if (generateMainCharacter)
            {
                IntroCharacterCreation createMainCharacter = new IntroCharacterCreation(this);
            }



            Encounters.Where(x => x.GetType() == typeof(SwampIntro)).FirstOrDefault().RunEncounter();

        }

    }
}
