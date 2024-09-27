namespace Ovning4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int times = 5;

            Console.WriteLine($"Jag kommer att kasta tärningen {times} gånger!");

            while (times > 0)
            {
                int dice = rnd.Next(1, 7);
                Console.WriteLine($"Tärningen visar {dice}");
                times -= 1;
            }
            Console.WriteLine($"Jag har kastat tärningen 5 gånger och är färdig!");

        }
    }
}