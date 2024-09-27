namespace Ovning4_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write($"Ange ett heltal: ");
            string input = Console.ReadLine();
            int number = int.Parse(input);
            int times = 0;

            Console.WriteLine($"Jag kommer nu att göra en triangel med {number}:or:");

            while (times < number)
            {
                times++;
                int times2 = 0; // Nollställer times2 innan varje inre while-loop-genomgång, så att times ligger +1 före per varv
                while (times > times2)
                {
                    Console.Write(number);
                    times2++;
                }
                Console.WriteLine();
            }

            /*
            while (times < number)
            {
                times++;
                for (int times2 = 0; times > times2; times2++)
                {
                    Console.Write(number);
                }
                Console.WriteLine();
            }
            */

        }
    }
}