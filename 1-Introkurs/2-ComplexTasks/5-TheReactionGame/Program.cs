namespace Komplex_Reaktionsspelet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Visar start-meddelande
            Console.WriteLine("Gör dig redo...");

            // Initierar timer och genererar ett tal mellan 3-7 sekunder
            Random timer = new Random();
            int randomTime = timer.Next(3000, 7001);

            // "Stoppar" programmet i antalet ticks som är framslumpat ovan
            System.Threading.Thread.Sleep(randomTime);
            int startTick = Environment.TickCount;

            // Uppmanar användaren till att trycka på en knapp
            Console.WriteLine("...NU!");

            // Inväntar att användaren trycker på en knapp
            Console.ReadKey();
            Console.WriteLine();
            int endTick = Environment.TickCount;

            int elapsedMs = endTick - startTick;

            // Om användaren trycker för tidigt
            if (elapsedMs == 0)
            {
                Console.WriteLine($"Du tryckte för tidigt!");
                Environment.Exit(0);
            }
            else if (elapsedMs > 0)
            {
                Console.WriteLine($"Det tog dig {elapsedMs} millisekunder att trycka!");
            }

        }
    }
}