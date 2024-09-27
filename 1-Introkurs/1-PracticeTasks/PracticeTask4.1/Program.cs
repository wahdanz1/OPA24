namespace Ovning4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = 0;
            while (value < 20)
            {
                value = value + 1;
                Console.Write(value);
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.WriteLine("Jag har räknat färdigt till 20!");

        }
    }
}