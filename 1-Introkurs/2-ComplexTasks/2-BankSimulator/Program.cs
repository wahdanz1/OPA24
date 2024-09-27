namespace Komplex_Banksimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;

            // Saldot tilldelas 500 kr från start (om ingen balance.txt-fil existerar)
            int balance = 500;

            // Plats för saldo-fil
            string balanceFilePath = "balance.txt";

            //Inläsning av saldo om saldo-fil finns
            if (File.Exists(balanceFilePath))
            {
                string savedBalance = File.ReadAllText(balanceFilePath);
                balance = int.Parse(savedBalance);
            }

            // PIN-koden anges manuellt i koden
            int pin = 1337;

            // Antalet PIN-försök är 3 från början
            int pinTries = 3;

            Console.WriteLine("Välkommen! Var god ange din PIN-kod: ");
            string input = Console.ReadLine();
            int enteredPin = int.Parse(input);
            while (enteredPin != pin)
            {
                Console.WriteLine($"Fel PIN-kod. Var god försök igen ({pinTries} försök kvar): ");
                pinTries--; // Sänker antalet försök med 1 per gång
                input = Console.ReadLine(); // Väntar på nytt PIN-kodsförsök
                enteredPin = int.Parse(input);
                if (pinTries == 0)
                {
                    Console.WriteLine("Du har skrivit fel PIN-kod för många gånger. Var god kontakta din bank.");
                    Environment.Exit(0);
                }
            }

            Console.WriteLine("Vad vill du göra idag?");

            while (choice == 0)
            {
                Console.WriteLine("1 - Sätta in pengar");
                Console.WriteLine("2 - Ta ut pengar");
                Console.WriteLine("3 - Visa saldo");
                Console.WriteLine("4 - Avsluta");

                // Användaren matar in sitt val
                Console.Write("Ange val med 1-4: ");
                input = Console.ReadLine();
                choice = int.Parse(input);
                Console.Write("");

                // Sätta in pengar
                if (choice == 1)
                {
                    Console.WriteLine("Hur mycket vill du sätta in?");
                    input = Console.ReadLine();
                    int depositAmount = int.Parse(input);
                    balance += depositAmount;
                    Console.WriteLine("Tack för din insättning!");
                    choice = 0;
                    while (depositAmount == 0)
                    {
                        // Om användaren försöker sätta in 0 kr
                        Console.WriteLine("Du kan inte sätta in 0 kr.");
                        Console.Write("Försök igen med ett positivt belopp: ");
                        input = Console.ReadLine();
                        depositAmount = int.Parse(input);
                    }
                }

                // Ta ut pengar
                else if (choice == 2)
                {
                    Console.WriteLine("Hur mycket vill du ta ut?");
                    input = Console.ReadLine();
                    int withdrawAmount = int.Parse(input);
                    while (withdrawAmount > balance)
                    {
                        // Om användaren försöker ta ut ett belopp som är högre än saldot
                        Console.WriteLine($"Ditt angivna belopp är för högt. Ditt saldo är {balance}.");
                        Console.Write("Försök igen med ett lägre belopp: ");
                        input = Console.ReadLine();
                        withdrawAmount = int.Parse(input);
                    }
                    while (withdrawAmount == 0)
                    {
                        // Om användaren försöker ta ut 0 kr
                        Console.WriteLine($"Kan ej ta ut {withdrawAmount} kr.");
                        Console.Write("Försök igen med ett faktiskt belopp: ");
                        input = Console.ReadLine();
                        withdrawAmount = int.Parse(input);
                    }

                    if (withdrawAmount <= balance)
                    {
                        // Om användaren försöker ta ut ett belopp som är högre än saldot
                        choice = 0;
                        balance -= withdrawAmount;
                        Console.WriteLine($"Matar ut {withdrawAmount} kr.");
                    }
                }

                // Visa saldo
                else if (choice == 3)
                {
                    Console.WriteLine($"Ditt saldo är {balance} kr.");
                    choice = 0;
                }

                // Avsluta
                else if (choice == 4)
                {
                    Console.WriteLine("Ha en fin dag!");

                    // Sparar aktuellt saldo till saldo-filen
                    File.WriteAllText(balanceFilePath, balance.ToString());

                    Environment.Exit(0);
                }
                Console.WriteLine();
                Console.WriteLine("Vill du göra något mer?");
            }
        }
    }
}