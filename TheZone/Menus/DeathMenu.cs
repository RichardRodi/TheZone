﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZone.Printer;

namespace TheZone.Menus
{
    public class DeathMenu
    {
        public void DeathScreen()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{ArtAssets.DeathHeader}");
            Console.ResetColor();
        }
    }
}
