namespace Ovning4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hur många gångar ska jag kasta myntet? ");
            string input = Console.ReadLine();
            int times = int.Parse(input);

            Random rnd = new Random();

            while (times > 0)
            {
                int coin = rnd.Next(1, 3);
                if (coin == 1) // Krona
                {
                    Console.WriteLine($"Myntet visar krona!");
                } else if (coin == 2) // Klave
                {
                    Console.WriteLine($"Myntet visar klave!");
                }
                times -= 1;
            }
            Console.WriteLine("Jag har singlat färdigt!");
            
        }
    }
}