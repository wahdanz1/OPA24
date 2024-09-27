namespace Komplex_GissaTalet
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 101);
            Console.Write($"Jag har slumpat ett tal mellan 1-100. Gissa talet: ");
            string input = Console.ReadLine();
            int guess = int.Parse(input);
            int numberOfGuesses = 0;

            while (guess != number)
            {
                if (guess > number)
                {
                    Console.WriteLine($"Fel! Mitt tal är lägre än {guess}.");
                    Console.Write($"Gissa igen: ");
                    input = Console.ReadLine();
                    guess = int.Parse(input);
                    numberOfGuesses++;
                }
                else if (guess < number)
                {
                    Console.WriteLine($"Fel! Mitt tal är högre än {guess}.");
                    Console.Write($"Gissa igen: ");
                    input = Console.ReadLine();
                    guess = int.Parse(input);
                    numberOfGuesses++;
                }
            }
            Console.WriteLine($"Rätt svar! Du gissade {numberOfGuesses} gånger.");
        }
    }
}