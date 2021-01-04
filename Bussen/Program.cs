using System;

namespace Bussen
{
    class Program
    {
        static void Main()
        {
            // Skapar ett objekt av klassen Buss
            Buss buss = new Buss();
            // Kör metoden från klassen
            buss.Run();
            Console.Write("\n\nPress any key to exit:");
            Console.ReadKey();
        }
    }
}
