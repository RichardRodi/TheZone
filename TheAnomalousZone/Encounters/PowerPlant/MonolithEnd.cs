using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.PowerPlant
{
    public class MonolithEnd : BaseEncounter
    {
        private GameManager _gameManager;

        public MonolithEnd(GameManager gameManager)
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

                string prompt = ($"\n\tStepping into the vast chamber that once housed this facility's reactor,\n" +
                    $"\tone is immediately struck by the solemn testament to the cataclysmic events of decades past.\n" +
                    $"\tThe walls, etched with scars from the relentless onslaught of heat and radiation,\n" +
                    $"\tbear silent witness to the unfathomable horrors that unfolded within.\n" +
                    $"\tAmidst the remnants of a bygone era,\n" +
                    $"\trusted control panels and dead monitors stand as ghostly relics.\n" +
                    $"\tAt the heart of the room looms a monstrous mass,\n" +
                    $"\tan amalgamation of congealed substances emanating from the decaying reactor's core.\n" +
                    $"\tRising towards the partially exposed sky, \n" +
                    $"\tthis mass commands attention with its glossy sheen,\n" +
                    $"\ttransitioning from stark clarity to an ominous darkness as it ascends towards the ceiling.\n" +
                    $"\tIt is here, in the presence of this imposing structure,\n" +
                    $"\tthat a booming voice resonates, penetrating every fiber of one's being,\n" +
                    $"\tposing the profound question: What is your desire?\n\n");

                string[] options = { "1.I desire wealth.", "2.I desire power.", "3.I desire all knowledge.","4.I desire destruction." };
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();
                GameManager gameManager = new GameManager(true);
                switch (selectedIndex)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("\n\tAs you approach the Monolith,\n" +
                            "\tyour eyes are dazzled by a radiant golden hue,\n" +
                            "\trendering you temporarily blind.\n" +
                            "\tEvery surface is enveloped in a glistening sheen of gold.\n" +
                            "\tCoins and currency cascade from above, eliciting an initial thrill of excitement.\n" +
                            "\tHowever, as the relentless deluge of material wealth persists,\n" +
                            "\tthe euphoria gives way to discomfort, then suffocation.\n" +
                            "\tThe incessant hail shows no signs of abating.\n" +
                            "\tDesperately, you struggle to escape the cavernous chamber now inundated with riches,\n" +
                            "\tbut your efforts prove futile. Darkness encroaches, enveloping your senses,\n" +
                            "\tand the last vestige of sight fades into the ethereal glow of the Monolith.\n\n\t THE END.");
                        Console.ReadKey(true);  
                        gameManager.RunGame();

                        break;

                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n\tGazing upon the Monolith,\n" +
                            "\ta surge of invincible power courses through you,\n" +
                            "\tYou feel imbued with unparalleled strength,\n" +
                            "\tcapable of commanding anything and shaping worlds to your whim.\n" +
                            "\tDiscarding your weapons as mere toys in comparison to your newfound strength,\n" +
                            "\tyou stride forward, a force of unstoppable might.\n" +
                            "\tYet, in your haste, you stumble over a stray piece of reinforced rebar,\n" +
                            "\tcareening headlong into an unyielding column. As darkness closes in,\n" +
                            "\ta faint pool of blood gathers around your fractured skull,\n" +
                            "\tthe ethereal glow of the monolith lingering as your final sight.\n\n\t THE END.");
                        Console.ReadKey(true);
                        gameManager.RunGame();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\n\tAs you draw near to the Monolith's radiant hue,\n" +
                            "\tyou feel yourself slipping into the depths of your own consciousness.\n" +
                            "\tThe universe unfolds before your mind's eye,\n" +
                            "\trevealing the vast expanse of space and the intricate folds of existence.\n" +
                            "\tA chilling realization dawns upon you: in this moment of cosmic clarity, you are utterly alone,\n" +
                            "\tunmatched in your comprehension of all that is.\n" +
                            "\tDespite your efforts to return to your physical form,\n" +
                            "\tyou find yourself ensnared in the timeless present, unable to break free.\n" +
                            "\tMeanwhile, back in the chamber with the monolith,\n" +
                            "\tyour body remains motionless on the floor, eyes glazed over,\n" +
                            "\tmouth slightly ajar, a thin trickle of drool staining your cheek.\n\n\t THE END.");
                        Console.ReadKey(true);
                        gameManager.RunGame();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\n\tThe Monolith trembles with immense energy,\n" +
                            "\tits luminous glow shifting into a pulsating, enigmatic blue hue.\n" +
                            "\tIn a dazzling eruption, an overwhelming surge of power cascades forth.\n" +
                            "\tRemarkably, you remain unscathed amidst the torrent of energy,\n" +
                            "\tthough its brilliance forces you to shield your eyes with your hand.\n" +
                            "\tAs the radiance subsides, you emerge to a desolate expanse,\n" +
                            "\tthe once vibrant world now reduced to scorched, lifeless terrain\n" +
                            "\tUndeterred, you embark upon your journey through this barren wasteland\n" +
                            "\tembracing the challenge of forging a new path in a realm devoid of life.\n\n\t THE END.");
                        Console.ReadKey(true);
                        gameManager.RunGame();
                        break;

                }
            }
        }
    }
}
