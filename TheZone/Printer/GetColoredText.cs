using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheZone.Printer
{
    public class GetColoredText
    {
        public static string GetCyanText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string cyanText = text;
           
            return cyanText;
        }
        public static string GetDarkYellowText(string text) 
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string darkYellowText = text;
            
            return darkYellowText;
          
        }
    }
}
