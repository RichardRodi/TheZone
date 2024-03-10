namespace TheAnomalousZone.Printer
{
    internal class SlowPrint
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
