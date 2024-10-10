namespace Komplex_HöjaTalet
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            int currentNumber = 0;
            int currentPlayer = 1;

            // Spelinstruktioner
            Console.WriteLine("Detta spel går ut på att...");
            Console.ReadKey();
            Console.Clear();

            // Loopar spelarnas tur tills choice-variabeln är 21
            while (choice != 21)
            {
                choice = playerTurn(choice, currentPlayer, currentNumber); // Spelare 1:s tur
                bool isValidChoice = choiceUpdate(choice, ref currentNumber); // Uppdaterar choice-variabeln så att nästa spelare får nya siffror att välja på
                if (isValidChoice)
                {
                    currentPlayer = playerSwap(currentPlayer); // Uppdaterar variabeln så att det blir nästa spelares tur
                }
            }
            Console.WriteLine($"Spelare {currentPlayer} vann!");
        }

        // -------------------- FUNKTIONER --------------------

        // Funktion för varje spelares tur
        public static int playerTurn(int choice, int currentPlayer, int currentNumber)
        {
            playerChoices(currentNumber, currentPlayer);
            Console.Write("Jag väljer: ");
            string input = Console.ReadLine();
            choice = int.Parse(input);
            Console.Clear();
            return choice;
        }

        // Spelarval för att inte visa för många när man närmar sig 21
        public static void playerChoices(int currentNumber, int currentPlayer)
        {
            if (currentNumber <= 18) // Om alternativen inte överstiger 21
            {
                Console.WriteLine($"Spelare {currentPlayer} - välj något av följande tal:");
                Console.WriteLine($"| {currentNumber + 1} | {currentNumber + 2} | {currentNumber + 3} |");
            }
            else if (currentNumber == 19) // Om alternativen överstiger 21 med +1
            {
                Console.WriteLine($"Spelare {currentPlayer} - välj något av följande tal:");
                Console.WriteLine($"| {currentNumber + 1} | {currentNumber + 2} |");
            }
            else if (currentNumber == 20) // Om alternativen överstiger 21 med +2
            {
                Console.WriteLine($"Spelare {currentPlayer} - du är körd! Du har bara ett val kvar:");
                Console.WriteLine($"| {currentNumber + 1} |");
            }
        }

        public static bool choiceUpdate(int choice, ref int currentNumber)
        {
            // Siffrorna uppdateras baserat på spelarens val
            if (choice > currentNumber && choice <= currentNumber + 3 && choice < 22)
            {
                currentNumber = choice;
                return true;
            }
            else
            {
                Console.WriteLine("Du måste välja ett av dina alternativ.\n");
                return false;
            }
        }

        // Funktion för att skifta spelare i varabeln currentPlayer
        public static int playerSwap(int currentPlayer)
        {
            if (currentPlayer == 1)
            {
                return 2;
            }
            else if (currentPlayer == 2)
            {
                return 1;
            }
            return currentPlayer;
        } // p = 1 - p (Kristers förenkling)

    }
}