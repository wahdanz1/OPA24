namespace Ovning2_7
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

            Console.WriteLine($"Talen du har angett är {numberOne} och {numberTwo}");

            // Variabelbyte enligt nedan exempelförklaring
            // Första siffran: 10
            // Andra siffran: 20

            // numberOne = 10 + 20
            // (numberOne är nu 30)
            numberOne = numberOne + numberTwo;

            // numberTwo = 30 - 20
            // (numberTwo är nu 10)
            numberTwo = numberOne - numberTwo;

            // numberOne = 30 - 10
            // (numberOne är nu 20)
            numberOne = numberOne - numberTwo;

            /* En annan lösning
            numberOne, numberTwo = numberTwo, numberOne;
            */

            Console.WriteLine($"Efter att ha speglat talen så är de nu {numberOne} och {numberTwo}");
        }
    }
}