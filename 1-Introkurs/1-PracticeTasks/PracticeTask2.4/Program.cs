namespace Ovning2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ange ett tal med minst 3 decimaler: ");
            string input = Console.ReadLine();
            double numberOne = double.Parse(input);

            double twoDecimals = Math.Round(numberOne, 2);

            Console.WriteLine($"Ditt tal med endast två decimaler: {twoDecimals}.");
        }
    }
}