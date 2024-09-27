namespace Ovning4_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write($"Ange ett heltal: ");
            string input = Console.ReadLine();
            int number = int.Parse(input);
            int times = number;
            int times2;

            Console.WriteLine($"Jag kommer nu att göra en triangel med {number}:or:");

            while (times > 0)
            {
                times2 = times;
                while (times2 > 0)
                {
                    Console.Write(number);
                    times2 --;
                }
                Console.WriteLine();
                times--;
            } 

        }
    }
}