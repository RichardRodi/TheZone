using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheZone.Printer
{
    public class SlowPrint

    {
        public static void Print(string text, int speed = 25)
        {
            foreach (char c in text) 
            { 
                Console.Write(c);
                Thread.Sleep(speed);
            }
            Console.WriteLine();
        }
    }
}
