namespace Ovning2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ange ett heltal: ");
            string input = Console.ReadLine();
            int numberOne = int.Parse(input);

            Console.Write("Ange ett till heltal: ");
            input = Console.ReadLine();
            int numberTwo = int.Parse(input);

            int total = numberOne + numberTwo;

            Console.WriteLine($"Summa av dina tal är {total}.");
        }
    }
}