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

                string prompt = ($"\nStepping into the vast chamber that once housed this facility's reactor,\n" +
                    $"one is immediately struck by the solemn testament to the cataclysmic events of decades past.\n" +
                    $"The walls, etched with scars from the relentless onslaught of heat and radiation,\n" +
                    $"bear silent witness to the unfathomable horrors that unfolded within.\n" +
                    $"Amidst the remnants of a bygone era,\n" +
                    $"rusted control panels and dead monitors stand as ghostly relics.\n" +
                    $"At the heart of the room looms a monstrous mass,\n" +
                    $"an amalgamation of congealed substances emanating from the decaying reactor's core.\n" +
                    $"Rising towards the partially exposed sky, \n" +
                    $"this mass commands attention with its glossy sheen,\n" +
                    $"transitioning from stark clarity to an ominous darkness as it ascends towards the ceiling.\n" +
                    $"It is here, in the presence of this imposing structure,\n" +
                    $"that a booming voice resonates, penetrating every fiber of one's being,\n" +
                    $"posing the profound question: What is your desire?\n\n");

                string[] options = { "1.I desire wealth.", "2.I desire power.", "3.I desire all knowledge.","4.I desire destruction." };
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();
                GameManager gameManager = new GameManager(true);
                switch (selectedIndex)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("\nAs you approach the Monolith,\n" +
                            "your eyes are dazzled by a radiant golden hue,\n" +
                            "rendering you temporarily blind.\n" +
                            "Every surface is enveloped in a glistening sheen of gold.\n" +
                            "Coins and currency cascade from above, eliciting an initial thrill of excitement.\n" +
                            "However, as the relentless deluge of material wealth persists,\n" +
                            "the euphoria gives way to discomfort, then suffocation.\n" +
                            "The incessant hail shows no signs of abating.\n" +
                            "Desperately, you struggle to escape the cavernous chamber now inundated with riches,\n" +
                            "but your efforts prove futile. Darkness encroaches, enveloping your senses,\n" +
                            "and the last vestige of sight fades into the ethereal glow of the Monolith.\n\n THE END.");
                        Console.ReadKey(true);  
                        gameManager.RunGame();

                        break;

                    case 1:
                        Console.Clear();
                        Console.WriteLine("\nGazing upon the Monolith,\n" +
                            "a surge of invincible power courses through you,\n" +
                            "You feel imbued with unparalleled strength,\n" +
                            "capable of commanding anything and shaping worlds to your whim.\n" +
                            "Discarding your weapons as mere toys in comparison to your newfound strength,\n" +
                            "you stride forward, a force of unstoppable might.\n" +
                            "Yet, in your haste, you stumble over a stray piece of reinforced rebar,\n" +
                            "careening headlong into an unyielding column. As darkness closes in,\n" +
                            "a faint pool of blood gathers around your fractured skull,\n" +
                            "the ethereal glow of the monolith lingering as your final sight.\n\n THE END.");
                        Console.ReadKey(true);
                        gameManager.RunGame();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\nAs you draw near to the Monolith's radiant hue,\n" +
                            "you feel yourself slipping into the depths of your own consciousness.\n" +
                            "The universe unfolds before your mind's eye,\n" +
                            "revealing the vast expanse of space and the intricate folds of existence.\n" +
                            "A chilling realization dawns upon you: in this moment of cosmic clarity, you are utterly alone,\n" +
                            "unmatched in your comprehension of all that is.\n" +
                            "Despite your efforts to return to your physical form,\n" +
                            "you find yourself ensnared in the timeless present, unable to break free.\n" +
                            "Meanwhile, back in the chamber with the monolith,\n" +
                            "your body remains motionless on the floor, eyes glazed over,\n" +
                            "mouth slightly ajar, a thin trickle of drool staining your cheek.\n\n THE END.");
                        Console.ReadKey(true);
                        gameManager.RunGame();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\nThe Monolith trembles with immense energy,\n" +
                            "its luminous glow shifting into a pulsating, enigmatic blue hue.\n" +
                            "In a dazzling eruption, an overwhelming surge of power cascades forth.\n" +
                            "Remarkably, you remain unscathed amidst the torrent of energy,\n" +
                            "though its brilliance forces you to shield your eyes with your hand.\n" +
                            "As the radiance subsides, you emerge to a desolate expanse,\n" +
                            "the once vibrant world now reduced to scorched, lifeless terrain\n" +
                            "Undeterred, you embark upon your journey through this barren wasteland\n" +
                            "embracing the challenge of forging a new path in a realm devoid of life.\n\n THE END.");
                        Console.ReadKey(true);
                        gameManager.RunGame();
                        break;

                }
            }
        }
    }
}
