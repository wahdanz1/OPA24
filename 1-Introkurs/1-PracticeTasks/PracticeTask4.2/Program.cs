namespace Ovning4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ange ett heltal: ");
            string input = Console.ReadLine();
            int value = int.Parse(input);

            if (value < 100)
            {
                while (value <= 100)
                {
                    Console.Write(value++);
                    Console.Write(" ");
                }
                Console.WriteLine();
                Console.WriteLine("Jag har räknat klart till 100!"); 
            }
            else
            {
                Console.WriteLine("Jag kommer inte att räkna från ett tal högre än eller lika med 100!");
            }
            

        }
    }
}