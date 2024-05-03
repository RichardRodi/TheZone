namespace TheAnomalousZone.NewFolder
{
    public class BaseMenu
    {
        
        
            private int SelectedIndex;
            private string[] Options;
            private string Prompt;

            public BaseMenu(string prompt, string[] options)
            {
                Prompt = prompt;
                Options = options;
                SelectedIndex = 0;

            }
            public void DislpayOptions()
            {
                Console.WriteLine(Prompt);
                for (int i = 0; i < Options.Length; i++)
                {
                    string currentOption = Options[i];
                    string prefix;
                    if (i == SelectedIndex)
                    {
                        prefix = "\u2622";
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        prefix = "";
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.ResetColor();
                    Console.WriteLine($"{prefix}   {currentOption} \n");


                }
            }
            public int Run()
            {
                ConsoleKey keyPressed;
                do
                {
                    Console.Clear();
                    DislpayOptions();
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    keyPressed = keyInfo.Key;
                    //Updated Selected Index
                    if (keyPressed == ConsoleKey.UpArrow)
                    {
                        SelectedIndex--;
                        if (SelectedIndex == -1)
                        {
                            SelectedIndex = Options.Length - 1;
                        }
                    }
                    else if (keyPressed == ConsoleKey.DownArrow)
                    {
                        SelectedIndex++;
                        if (SelectedIndex == Options.Length)
                        {
                            SelectedIndex = 0;
                        }
                    }

                } while (keyPressed != ConsoleKey.Enter);
                Console.Clear();
                return SelectedIndex;
            
            }
        
    }
}
