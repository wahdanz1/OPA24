namespace Ovning2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ange ett tal: ");
            string input = Console.ReadLine();
            int numberOne = int.Parse(input);

            Console.Write("Ange ett till tal: ");
            input = Console.ReadLine();
            int numberTwo = int.Parse(input);

            int temp = numberOne;
            numberOne = numberTwo;
            numberTwo = temp;

            Console.WriteLine($"Efter att ha speglat talen så är de nu {numberOne} och {numberTwo}");
        }
    }
}