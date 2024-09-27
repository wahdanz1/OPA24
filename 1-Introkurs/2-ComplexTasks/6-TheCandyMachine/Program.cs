namespace Komplex_Godisuatomaten
{
    class Program
    {
        static void Main(string[] args)
        {
            // Deklarerar tillgängliga godisar i maskinen med hjälp av Candy-klassen
            Candy obj1 = new Candy("Snickers", 15, 8);
            Candy obj2 = new Candy("Kexchoklad", 20, 4);
            Candy obj3 = new Candy("Milkyway", 10, 10);
            Candy obj4 = new Candy("Mars", 12, 11);

            // Skapar en array som innehåller alla godisar
            Candy[] candyArray = new Candy[] { obj1, obj2, obj3, obj4 };

            while (true)
            {
                // Visar godisalternativen
                DisplayCandy(candyArray);

                // Väntar på användarinmatning
                string input = Console.ReadLine();

                // Avslutar programmet om användaren skriver "Q"
                if (input.ToLower() == "q")
                {
                    Environment.Exit(0);
                }

                // Försöker omvandla inmatningen till en integer
                if (int.TryParse(input, out int choice))
                {
                    choice--; // Korrigering pga att indexeringen börjar på 0

                    // Kollar om inmatningen är inom intervallet av godisalternativ (1-4)
                    if (choice >= 0 && choice < candyArray.Length)
                    {
                        if (candyArray[choice].remaining > 0) // Köper vald godis om den finns kvar
                        {
                            candyArray[choice].remaining--;
                            Console.Clear();
                            Console.WriteLine($"Du köpte en {candyArray[choice].name}.");
                            Console.WriteLine($"*Matar ut en {candyArray[choice].name}*");
                            Console.WriteLine($"Det finns nu {candyArray[choice].remaining} st {candyArray[choice].name} kvar.");
                            Console.WriteLine("-----------------------------------------------------------------");
                        }
                        else // Visar felmeddelande om godisen är slut
                        {
                            Console.Clear();
                            Console.WriteLine("Denna godis är tyvärr slut. Var god välj en annan godis!");
                            Console.WriteLine("-----------------------------------------------------------------");
                        }
                    }
                    else // Visar felmeddelande om användaren väljer en lucka som inte finns
                    {
                        Console.Clear();
                        Console.WriteLine("Luckan du försöker välja finns inte. Var god gör ett nytt val!");
                        Console.WriteLine("-----------------------------------------------------------------");
                    }
                }
                else // Hanterar felaktig inmatning (icke-numeriska värden som "a", "b", etc.)
                {
                    Console.Clear();
                    Console.WriteLine("Ogiltig inmatning! Var god skriv in ett nummer som motsvarar ett godisval.");
                    Console.WriteLine("-----------------------------------------------------------------");
                }
            }
        }

        public static void DisplayCandy(Candy[] candyArray)
        {
            for (int i = 0; i < candyArray.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {candyArray[i].name} ({candyArray[i].remaining} st finns) - pris: {candyArray[i].price}");
            }
            Console.WriteLine("Q - Avsluta");
            Console.WriteLine();
            Console.WriteLine("Vilken godis vill du ha?: ");
        }
    }
}

public class Candy
{
    public string name;
    public int price;
    public int remaining;
    public Candy(string name, int price, int remaining)
    {
        this.name = name;
        this.price = price;
        this.remaining = remaining;
    }
}