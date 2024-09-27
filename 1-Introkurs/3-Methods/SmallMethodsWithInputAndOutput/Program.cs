using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Småmetoder
{
    class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Välj vilken metod du vill använda: ");
                Console.WriteLine("1 - AddTwo: Ökar värdet på ett heltal med 2");
                Console.WriteLine("2 - Cube: Beräknar kuben av ett tal");
                Console.WriteLine("3 - MultiplyByTen: Multiplicerar ett heltal med 10");
                Console.WriteLine("4 - SubtractFive: Minskar värdet på ett heltal med 5");
                Console.WriteLine("5 - Half: Dividerar ett tal med 2 och returnerar resultatet");
                Console.WriteLine("6 - ToUpper: Konverterar en textsträng till versaler");
                Console.WriteLine("7 - GetFirstCharacter: Returnerar den första bokstaven i en textsträng");
                Console.WriteLine("8 - Square: Beräknar kvadraten av ett tal");
                Console.WriteLine("9 - CToF: Konverterar en temperatur från Celsius till Fahrenheit");
                Console.WriteLine("10 - IsEven: Kontrollerar om ett heltal är jämnt");

                int number;

                // Inväntar användarinmatning
                Console.Write("Mitt val: ");
                string input = Console.ReadLine();
                int choice = int.Parse(input);

                if (choice == 1)
                {
                    Console.WriteLine("AddTwo: Ökar värdet på ett heltal med 2");
                    Console.Write("Skriv ett heltal: ");
                    input = Console.ReadLine();
                    choice = int.Parse(input);
                    choice = AddTwo(choice);
                    Console.WriteLine($"Efter att ha adderat 2 blir ditt tal {choice}");
                    ReturnToMenu();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Cube: Beräknar kuben av ett tal");
                    Console.Write("Skriv ett heltal: ");
                    input = Console.ReadLine();
                    number = int.Parse(input);
                    number = Cube(number);
                    Console.WriteLine($"Kuben av ditt tal är {number}");
                    ReturnToMenu();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("MultiplyByTen: Multiplicerar ett heltal med 10");
                    Console.Write("Skriv ett heltal: ");
                    input = Console.ReadLine();
                    number = int.Parse(input);
                    number = MultiplyByTen(number);
                    Console.WriteLine($"Ditt tal multiplicerat med 10 är {number}");
                    ReturnToMenu();
                }
                else if (choice == 4)
                {
                    Console.WriteLine("SubtractFive: Minskar värdet på ett heltal med 5");
                    Console.Write("Skriv ett heltal: ");
                    input = Console.ReadLine();
                    number = int.Parse(input);
                    number = SubtractFive(number);
                    Console.WriteLine($"Ditt tal minus 5 är {number}");
                    ReturnToMenu();
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Half: Dividerar ett tal med 2 och returnerar resultatet");
                    Console.Write("Skriv ett heltal: ");
                    input = Console.ReadLine();
                    number = int.Parse(input);
                    number = Half(number);
                    Console.WriteLine($"Ditt tal delat på 2 är {number}");
                    ReturnToMenu();
                }
                else if (choice == 6)
                {
                    Console.WriteLine("ToUpper: Konverterar en textsträng till versaler");
                    Console.Write("Skriv en textsträng: ");
                    input = Console.ReadLine();
                    string text = ToUpper(input);
                    Console.WriteLine($"Din text i versaler: {text}");
                    ReturnToMenu();
                }
                else if (choice == 7)
                {
                    Console.WriteLine("ToUpper: Konverterar en textsträng till versaler");
                    Console.Write("Skriv en textsträng: ");
                    input = Console.ReadLine();
                    char text = GetFirstCharacter(input);
                    Console.WriteLine($"Den första bokstaven i textsträngen: {text}");
                    ReturnToMenu();
                }
                else if (choice == 8)
                {
                    Console.WriteLine("Square: Beräknar kvadraten av ett tal");
                    Console.Write("Skriv ett heltal: ");
                    input = Console.ReadLine();
                    number = int.Parse(input);
                    number = Square(number);
                    Console.WriteLine($"Kvadraten av ditt tal är {number}");
                    ReturnToMenu();
                }
                else if (choice == 9)
                {
                    Console.WriteLine("CToF: Konverterar en temperatur från Celsius till Fahrenheit");
                    Console.Write("Skriv en temperatur (i Celsius): ");
                    input = Console.ReadLine();
                    double temp = double.Parse(input);
                    temp = CToF(temp);
                    Console.WriteLine($"Din angivna temperatur i Fahrenheit: {temp}");
                    ReturnToMenu();
                }
                else if (choice == 10)
                {
                    Console.WriteLine("IsEven: Kontrollerar om ett heltal är jämnt");
                    Console.Write("Skriv ett heltal: ");
                    input = Console.ReadLine();
                    number = int.Parse(input);
                    IsEven(number);
                    ReturnToMenu();
                }
            }
        }

        // Metod för att återgå till huvudmenyn
        public static void ReturnToMenu()
        {
            // Inväntar inmatning för att återgå till huvudmenyn
            Console.WriteLine("Tryck på valfri knapp för att återgå till huvudmenyn.");
            Console.ReadKey();
            Console.Clear();
        }

        // 1 - AddTwo
        public static int AddTwo(int number)
        {
            number += 2;
            return number;
        }

        // 2 - Cube
        public static int Cube(int number)
        {
            number = number * number * number;
            return number;
        }

        // 3 - MultiplyByTen 
        public static int MultiplyByTen(int number)
        {
            number = number * 10;
            return number;
        }

        // 4 - SubtractFive 
        public static int SubtractFive(int number)
        {
            number = number - 5;
            return number;
        }

        // 5 - Half 
        public static int Half(int number)
        {
            number = number / 2;
            return number;
        }

        // 6 - ToUpper 
        public static string ToUpper(string text)
        {
            //Deklarerar variabeln för att lagra den konverterade texten i
            string convertedText = "";

            for (int i = 0; i < text.Length; i++) // Loopar igenom varje bokstav
            {
                if (text[i] >= 'a' && text[i] <= 'z') // Kollar om bokstaven är en gemen...
                {
                    convertedText += (char)(text[i] - 'a' + 'A'); // ...och ersätter den med en versal
                }
                else
                {
                    convertedText += text[i]; // Om allt redan är skrivet i versaler
                }
            }
            return convertedText;
        }

        // 7 - GetFirstCharacter
        public static char GetFirstCharacter(string text)
        {
            //Deklarerar variabeln för att lagra den första bokstaven i
            char firstLetter = '\0';

            for (int i = 0; i < text.Length; i++) // Loopar igenom textsträngen, bokstav för bokstav
            {
                char currentChar = text[i]; // Lagrar aktuellt tecken

                // Kollar om lagrat tecken är en bokstav
                if ((currentChar >= 'A' && currentChar <= 'Z') || (currentChar >= 'a' && currentChar <= 'z'))
                {
                    firstLetter = currentChar; // Tilldelar aktuell bokstav till variabeln
                    break; // Avslutar loopen när en bokstav är funnen
                }
            }
            return firstLetter;
        }

        // 8 - Square
        public static int Square(int number)
        {
            number = number * number;
            return number;
        }

        // 9 - CToF
        public static double CToF(double temp)
        {
            double fahrenheit = (temp * 9) / 5 + 32;
            return fahrenheit;
        }

        // 10 - IsEven
        public static void IsEven(int number)
        {
            // Delar talet på 2 och dumpar ev remainder (decimal)
            int evenCheck = number % 2;
            if (evenCheck == 1)
            {
                Console.WriteLine("Ditt tal är inte ett heltal");
            } else
            {
                Console.WriteLine("Ditt tal är ett heltal");
            }
        }


    }
}