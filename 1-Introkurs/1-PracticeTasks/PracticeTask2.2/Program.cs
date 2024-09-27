namespace Ovning2_2
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

            Console.Write("Ange ett tredje heltal: ");
            input = Console.ReadLine();
            int numberThree = int.Parse(input);

            int total = numberOne + numberTwo + numberThree;
            int average = total / 3;

            Console.WriteLine($"Summan av dina angivna tal är {total}. \nMedelvärdet av talen är {average}");
        }
    }
}

