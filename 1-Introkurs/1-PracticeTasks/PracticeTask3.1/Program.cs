namespace Ovning3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ange din ålder: ");
            string input = Console.ReadLine();
            int userAge = int.Parse(input);

            if (userAge >= 18)
            {
                Console.WriteLine("Användaren är myndig.");
            }
            else
            {
                Console.WriteLine("Användaren är inte myndig.");
            }

        }
    }
}