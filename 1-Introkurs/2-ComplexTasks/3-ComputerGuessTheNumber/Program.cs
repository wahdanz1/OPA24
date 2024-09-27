using System;

namespace Komplex_DatornGissarTalet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Jag kommer nu att gissa på ett tal:");
            Random random = new Random();
            int randomGuess = random.Next(1, 101);
            string answer = "";
            int previousGuess;
            int lowerValue = 1;
            int higherValue = 101;

            // Datorn gissar på ett tal fram tills användaren skriver "r" (rätt)
            while (answer != "r")
            {
                Console.WriteLine($"Jag gissar på talet {randomGuess}. Är det [h]ögre, [l]ägre eller [r]ätt?");
                string input = Console.ReadLine();
                answer = input;
                previousGuess = randomGuess;
                if (answer == "r")
                {
                    Console.Write($"Yay! Rätt svar är {previousGuess}!");
                } else if (answer == "h")
                {
                    // Uppdaterar det lägre intervallvärdet med den senaste gissningen
                    previousGuess++;
                    lowerValue = previousGuess;

                    // Genererar en ny gissning baserat på intervallet
                    randomGuess = random.Next(lowerValue, higherValue);
                }
                else if (answer == "l")
                {
                    // Uppdaterar det högre intervallvärdet med den senaste gissningen
                    higherValue = previousGuess;

                    // Genererar en ny gissning baserat på intervallet
                    randomGuess = random.Next(lowerValue, higherValue);
                }
            }
        }
    }
}