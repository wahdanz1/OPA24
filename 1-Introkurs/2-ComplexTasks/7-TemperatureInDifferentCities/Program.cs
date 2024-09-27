namespace Komplex_TemperaturIOlikaStäder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Deklarerar alla menyval
            Menu menuChoice1 = new Menu("Visa temperatur för alla städer");
            Menu menuChoice2 = new Menu("Visa medeltemperatur för städerna");
            Menu menuChoice3 = new Menu("Var är det kallast?");
            Menu menuChoice4 = new Menu("Var är det varmast?");
            Menu menuChoice5 = new Menu("Lägg till ny stad");

            // Skapar en array som innehåller alla menyval
            Menu[] menuArray = new Menu[] { menuChoice1, menuChoice2, menuChoice3, menuChoice4, menuChoice5 };

            // Skapar en tom array för att hålla alla städer
            City[] cityArray = new City[] { };

            while (true)
            {
                // Visar menyn
                Console.WriteLine("Gör ett val: ");
                DisplayMenu(menuArray);

                // Inväntar användarens val
                Console.Write("Mitt val: ");
                string input = Console.ReadLine();
                int choice = int.Parse(input);

                // Kollar så att angivet val är giltigt (1-5)
                if (choice > 0 && choice < menuArray.Length + 1)
                {
                    if (choice == 1) // Visar temp
                    {
                        // Kollar så att listan inte är tom
                        CheckIfListIsEmpty(cityArray);
                        Console.Clear();
                        Console.WriteLine("Lista för alla städer och dess temperatur: ");
                        City(cityArray);
                        ReturnToMenu();
                    }
                    else if (choice == 2) // Visar medelvärde
                    {
                        // Kollar så att listan inte är tom
                        CheckIfListIsEmpty(cityArray);
                        Console.Clear();
                        CityAverageTemp(cityArray);
                        ReturnToMenu();
                    }
                    else if (choice == 3) // Kallast?
                    {
                        // Kollar så att listan inte är tom
                        CheckIfListIsEmpty(cityArray);
                        Console.Clear();
                        ColdestCity(cityArray);
                        ReturnToMenu();
                    }
                    else if (choice == 4) // Varmast?
                    {
                        // Kollar så att listan inte är tom
                        CheckIfListIsEmpty(cityArray);
                        Console.Clear();
                        WarmestCity(cityArray);
                        ReturnToMenu();
                    }
                    else if (choice == 5) // Ny stad
                    {
                        Console.Clear();
                        // Användaren matar in namn + temp för ny stad
                        Console.Write("Ange namnet på staden: ");
                        string newTownName = Console.ReadLine();
                        Console.Write("Ange temperaturen i staden: ");
                        int newTownTemp = int.Parse(Console.ReadLine());
                        Console.WriteLine("Tack för din inmatning!");

                        // Lägger till den nya staden i arrayen
                        cityArray = NewCity(cityArray, newTownName, newTownTemp);
                        ReturnToMenu();
                    }
                }
            }
        }

        // Metod för att visa menyval
        public static void DisplayMenu(Menu[] menuArray)
        {
            for (int i = 0; i < menuArray.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {menuArray[i].title}");
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


        // Metod för att kolla att listan inte är tom
        public static void CheckIfListIsEmpty(City[] cityArray)
        {
            Console.Clear();
            if (cityArray.Length == 0)
            {
                Console.WriteLine("Din lista är tom. Var god lägg till minst en stad först via huvudmenyn.");
                return;
            }
        }


        // Metod för att visa alla städers temperatur
        public static void City(City[] cityArray)
        {
            // Kollar så att listan inte är tom
            CheckIfListIsEmpty(cityArray);

            for (int i = 0; i < cityArray.Length; i++)
            {
                Console.WriteLine($"{cityArray[i].name}, {cityArray[i].temp} °C");
            }
        }


        // Metod för att visa alla städers medelvärde
        public static void CityAverageTemp(City[] cityArray)
        {
            // Deklarerar variabeln att lagra alla städers temperaturer i
            int sumTemp = 0;

            // Loopar igenom alla städer och lägger ihop dessa i variabeln sumTemp
            for (int i = 0; i < cityArray.Length; i++)
            {
                sumTemp += cityArray[i].temp;
            }
            // Deklarerar en variabel med total antal städer i arrayen
            int totalCities = cityArray.Length;

            // När loopen är klar, tar summan av temperaturerna och delar med antalet städer i arrayen
            int averageTemp = sumTemp / totalCities;
            Console.WriteLine($"Medeltemperaturen för samtliga städer är {averageTemp} °C");
        }


        // Metod för att visa den kallaste staden
        public static void ColdestCity(City[] cityArray)
        {
            // Kollar så att listan inte är tom
            CheckIfListIsEmpty(cityArray);

            // Deklarerar variabler för att spåra kallaste staden
            City coldestCity = cityArray[0];
            int minTemp = coldestCity.temp;

            // Loopar igenom städerna i arrayen
            for (int i = 1; i < cityArray.Length; i++) // Börjar på 1 då 0 redan används ovan
            {
                if (cityArray[i].temp < minTemp) // Startar loopen om aktuell stad är den kallaste såhär långt
                {
                    minTemp = cityArray[i].temp; // Lagrar stadens temperatur
                    coldestCity = cityArray[i]; // Lagrar stadens namn
                }
            }
            Console.WriteLine($"Den kallaste staden är {coldestCity.name} med {coldestCity.temp} °C.");
        }


        // Metod för att visa den varmaste staden
        public static void WarmestCity(City[] cityArray)
        {
            // Kollar så att listan inte är tom
            CheckIfListIsEmpty(cityArray);

            // Deklarerar variabler för att spåra varmaste staden
            City warmestCity = cityArray[0];
            int maxTemp = warmestCity.temp;

            // Loopar igenom städerna i arrayen
            for (int i = 1; i < cityArray.Length; i++) // Börjar på 1 då 0 redan används ovan
            {
                if (cityArray[i].temp > maxTemp) // Startar loopen om aktuell stad är den varmaste såhär långt
                {
                    maxTemp = cityArray[i].temp; // Lagrar stadens temperatur
                    warmestCity = cityArray[i]; // Lagrar stadens namn
                }
            }
            Console.WriteLine($"Den varmaste staden är {warmestCity.name} med {warmestCity.temp} °C.");
        }


        // Metod för att lägga till en stad+temp i arrayen
        public static City[] NewCity(City[] cityArray, string newTownName, int newTownTemp)
        {
            // Skapar en ny stad
            City newCity = new City(newTownName, newTownTemp);

            // Skapar en ny array som är en plats större än den gamla arrayen
            City[] newArray = new City[cityArray.Length + 1];

            // Kopierar alla element från den gamla till den nya arrayen
            for (int i = 0; i < cityArray.Length; i++)
            {
                newArray[i] = cityArray[i];
            }

            // Lägger till den nya staden på sista platsen i den nya arrayen
            newArray[cityArray.Length] = newCity;

            // Returnerar den nya arrayen
            return newArray;
        }
    }
}

public class City
{
    public string name;
    public int temp;
    public City(string name, int temp)
    {
        this.name = name;
        this.temp = temp;
    }
}

public class Menu
{
    public string title;
    public Menu(string title)
    {
        this.title = title;
    }
}