using System.Data;
using TheAnomalousZone.Encounters;
using TheAnomalousZone.Encounters.Shop;
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
                GenerateAllFirstAid();
            }
        }

        public void GenerateMainCharacter()
        {


            AllMainCharacters.Add(new MainPlayer(name: "Sergei", health: 50, radiation: 0, damage: 2, armorValue: 8,
                firstAid: 2, weaponValue: 15, ammunitionPerMagazine: 1, speed: 10, "You were a soldier in the Ukranian Army", rubles: 500, maxHealth: 50));

            AllMainCharacters.Add(new MainPlayer(name: "Artyom", health: 40, radiation: 0, damage: 1, armorValue: 5,
                firstAid: 3, weaponValue: 25, ammunitionPerMagazine: 1, speed: 13, "You were a sniper in the Ukranian Army", rubles: 1000, maxHealth: 40));

            AllMainCharacters.Add(new MainPlayer(name: "Dimitri", health: 30, radiation: 0, damage: 1, armorValue: 7,
                firstAid: 1, weaponValue: 12, ammunitionPerMagazine: 9, speed: 8, "You were a scientist in the Ukranian Army", rubles: 800, maxHealth: 30));
        }


        public void GenerateAllEnemies()
        {

            Enemies.Add(new Bandits("Bandit Soldier", health: 20, damage: 2, armorValue: 3,
                firstAid: 1, weaponValue: 6, ammunition: 8, speed: 10, numberOfShotsFired: 3));

            Enemies.Add(new Bandits("Bandit Leader", health: 25, damage: 1, armorValue: 4,
                firstAid: 2, weaponValue: 9, ammunition: 5, speed: 12, numberOfShotsFired: 1));

            Enemies.Add(new Bandits("Bandit Scout", health: 15, damage: 1, armorValue: 2,
                firstAid: 1, weaponValue: 9, ammunition: 2, speed: 14, numberOfShotsFired: 2));

            Enemies.Add(new MutatedAnimals("MutatedBoar", health: 20, damage: 6, armorValue: 4, radiationDamage: 1,
                  speed: 10, "This is a mutated boar"));

            Enemies.Add(new MutatedAnimals("MutatedChimera", health: 60, damage: 8, armorValue: 5, radiationDamage: 1,
            speed: 5, "This is a mutated chimera"));

            Enemies.Add(new MutatedAnimals("MutatedSnork", health: 30, damage: 5, armorValue: 5, radiationDamage: 1,
                 speed: 15, "This is a mutated Snork"));
        }


        public void GenerateAllEncounters()
        {

            var spaceEncounter = new SpaceEncounter(this);
            Encounters.Add(spaceEncounter);

            var swampIntro = new SwampIntro(this);
            Encounters.Add(swampIntro);

            var dilapidatedBuilding = new DilapidatedBuilding(this);
            Encounters.Add(dilapidatedBuilding);

            var wareHouse = new WareHouse(this);
            Encounters.Add(wareHouse);

            var strelocksShop = new StrelocksShop(this);
            Encounters.Add(strelocksShop);

            var abandonedChurch = new AbandonedChurch(this);
            Encounters.Add(abandonedChurch);

        }

        public void GenerateAllFirstAid()
        {
            Items.Add(new ItemBase(iD: 0, "Basic FirstAid Kit", price: 1000, amountToHeal: 10));
            Items.Add(new ItemBase(iD: 1, "Military FirstAid Kit", price: 2000, amountToHeal: 50));
        }

        public void RunGame()
        {
            TitlePage mainMenu = new TitlePage();


            var generateMainCharacter = mainMenu.RunTitlePage();
            if (generateMainCharacter)
            {
                IntroCharacterCreation createMainCharacter = new IntroCharacterCreation(this);
            }

            var firstEncounter = Encounters.Where(x => x.GetType() == typeof(SwampIntro)).FirstOrDefault();
            if (firstEncounter != null)
                firstEncounter.RunEncounter();
            else
                RunGame();
        }


        //Health: 50
        //Damage: 3
        //Armor Value: 10
        //First Aid: 2
        //Weapon Value: 12
        //Ammunition Per Magazine: 3
        //Speed: 10
        //Description: Ukrainian Army Soldier
        //Rubles: 500
        //Artyom:

        //Health: 40
        //Damage: 2
        //Armor Value: 8
        //First Aid: 3
        //Weapon Value: 15
        //Ammunition Per Magazine: 2
        //Speed: 12
        //Description: Ukrainian Army Sniper
        //Rubles: 1000
        //Dimitri:

        //Health: 30
        //Damage: 1
        //Armor Value: 7
        //First Aid: 1
        //Weapon Value: 5
        //Ammunition Per Magazine: 6
        //Speed: 8
        //Description: Ukrainian Army Scientist
        //Rubles: 800
        //Enemies:
        //Bandit Soldier:

        //Health: 25
        //Damage: 2
        //Armor Value: 5
        //First Aid: 1
        //Weapon Value: 10
        //Ammunition: 8
        //Speed: 7
        //Number of Shots Fired: 2
        //Bandit Leader:

        //Health: 35
        //Damage: 3
        //Armor Value: 6
        //First Aid: 2
        //Weapon Value: 12
        //Ammunition: 12
        //Speed: 9
        //Number of Shots Fired: 1
        //Bandit Scout:

        //Health: 20
        //Damage: 1
        //Armor Value: 4
        //First Aid: 1
        //Weapon Value: 8
        //Ammunition: 20
        //Speed: 10
        //Number of Shots Fired: 3
        //Mutated Boar:

        //Health: 70
        //Damage: 8
        //Armor Value: 6
        //Radiation Damage: 2
        //Speed: 6
        //Mutated Chimera:

        //Health: 30
        //Damage: 10
        //Armor Value: 8
        //Radiation Damage: 3
        //Speed: 8
        //Mutated Snork:

        //Health: 15
        //Damage: 6
        //Armor Value: 4
        //Radiation Damage: 1
        //Speed: 12
    }
}
