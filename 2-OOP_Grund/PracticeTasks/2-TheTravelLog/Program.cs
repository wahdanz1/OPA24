using System.Text.Json;

namespace Reseloggen
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Deklarerar JSON-fil för listan
            string filePath = "TravelLog.json";
            List<TravelLogEntry> myTravelLog = new List<TravelLogEntry>();

            // Laddar lista från JSON-fil
            LoadList(filePath, ref myTravelLog);

            Console.WriteLine("---------- Reseloggen ----------");
            while (true)
            {
                DisplayMenu();
                string input = Console.ReadLine();
                int choice = int.Parse(input);
                Console.Clear();

                switch (choice)
                {
                    case 1: ShowTravelLog(myTravelLog, true); break;
                    case 2: AddNewEntry(myTravelLog); break;
                    case 3: DeleteEntry(myTravelLog); break;
                    case 4: ShowStatistics(myTravelLog); break;
                    case 5: ClearList(myTravelLog); break;
                    case 6: SaveListBeforeExit(filePath, myTravelLog); break;
                }
            }
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("1 - Visa alla resmål");
            Console.WriteLine("2 - Lägg till resmål");
            Console.WriteLine("3 - Ta bort resmål");
            Console.WriteLine("4 - Visa statistik");
            Console.WriteLine("5 - Rensa loggen");
            Console.WriteLine("6 - Avsluta programmet");
            Console.Write("Mitt val: ");
        }

        public static void ReturnToMenu()
        {
            Console.WriteLine("\nTryck på valfri knapp för att återgå till huvudmenyn.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ShowTravelLog(List<TravelLogEntry> myTravelLog, bool showSortingOptions)
        {
            while (true)
            {
                Console.Clear();
                if (myTravelLog.Count == 0)
                {
                    Console.WriteLine("Din lista är tom! Lägg till minst ett resmål först.");
                    return;
                }
                else
                {
                    int indexWidth = 5;
                    int ratingWidth = 5;
                    int locationWidth = 20;
                    int yearWidth = 5;
                    int descriptionWidth = 50;

                    Console.WriteLine("------------- Dina resmål -------------");
                    Console.WriteLine($"{PadRight("Index", indexWidth)} | {PadRight("Resmål", locationWidth)} | {PadRight("Betyg", ratingWidth)} | {PadRight("År", yearWidth)} | {PadRight("Beskrivning (stad, med vem, etc)", descriptionWidth)}");
                    Console.WriteLine(new string('-', indexWidth + locationWidth + ratingWidth + yearWidth + descriptionWidth + 12)); // 12 for the separators and spaces

                    for (int i = 0; i < myTravelLog.Count; i++)
                    {
                        var logEntry = myTravelLog[i];
                        Console.WriteLine($"{PadRight((i + 1).ToString(), indexWidth)} | {PadRight(logEntry.Location, locationWidth)} | {PadRight(logEntry.Rating.ToString(), ratingWidth)} | {PadRight(logEntry.Year.ToString(), yearWidth)} | {PadRight(logEntry.Description, descriptionWidth)}");
                    }
                }

                if (showSortingOptions)
                {
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    Console.WriteLine("1 - Sortera resmål i alfabetisk ordning");
                    Console.WriteLine("2 - Sortera resmål i omvänd alfabetisk ordning");
                    Console.WriteLine("3 - Sortera resmål efter år (senaste först)");
                    Console.WriteLine("4 - Sortera resmål efter år (äldsta först)");
                    Console.WriteLine("5 - Gå tillbaka till huvudmenyn");
                    Console.Write("Mitt val: ");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1: myTravelLog.Sort((x, y) => x.Location.CompareTo(y.Location)); break;
                        case 2: myTravelLog.Sort((x, y) => y.Location.CompareTo(x.Location)); break;
                        case 3: myTravelLog.Sort((x, y) => y.Year.CompareTo(x.Year)); break;
                        case 4: myTravelLog.Sort((x, y) => x.Year.CompareTo(y.Year)); break;
                        case 5: Console.Clear(); return;
                    }
                } else { return; }
            }
        }

        public static string PadRight(string text, int length)
        {
            return text.PadRight(length);
        }

        public static void AddNewEntry(List<TravelLogEntry> myTravelLog)
        {
            Console.WriteLine("----- Uppgifter om ditt resmål -----");

            string location = GetValidLocation();
            int year = GetValidYear();
            string description = GetValidDescription();
            int rating = GetValidRating();

            TravelLogEntry logEntry = new TravelLogEntry
            {
                Location = location,
                Year = year,
                Description = description,
                Rating = rating
            };

            myTravelLog.Add(logEntry);
            Console.Write("Lägger till resmål");
            DotPause();

            Console.Clear();
            Console.WriteLine("Resmålet har lagts till i loggen!");
            ReturnToMenu();
        }

        public static string GetValidLocation()
        {
            string location;
            do
            {
                Console.Write("Ange namnet på resmålet: ");
                location = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(location))
                {
                    Console.WriteLine("Resmålet kan inte vara tomt. Försök igen.");
                }
            } while (string.IsNullOrWhiteSpace(location));

            return location;
        }

        public static int GetValidYear()
        {
            int year;
            int currentYear = DateTime.Now.Year;
            do
            {
                Console.Write($"Ange året du var där: ");
                if (!int.TryParse(Console.ReadLine(), out year) || year < 1960 || year > currentYear)
                {
                    Console.WriteLine("Ogiltigt år. Försök igen.");
                }
            } while (year < 1960 || year > currentYear);

            return year;
        }

        public static string GetValidDescription()
        {
            Console.Write("Ange en beskrivning: ");
            return Console.ReadLine();
        }

        public static int GetValidRating()
        {
            int rating;
            do
            {
                Console.Write("Ange betyg (1-5): ");
                if (!int.TryParse(Console.ReadLine(), out rating) || rating < 1 || rating > 5)
                {
                    Console.WriteLine("Ogiltigt betyg. Ange ett värde mellan 1 och 5.");
                }
            } while (rating < 1 || rating > 5);

            return rating;
        }

        public static void DeleteEntry(List<TravelLogEntry> myTravelLog)
        {
            ShowTravelLog(myTravelLog, false);

            if (myTravelLog.Count == 0)
            {
                Console.WriteLine("Det finns inga resmål att ta bort.");
                ReturnToMenu();
                return;
            }

            Console.WriteLine("\nAnge med index-siffran vilket resmål du vill ta bort eller tryck 'Esc' för att avbryta:");
            Console.Write("Index: ");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                return;
            }

            Console.Write(keyInfo.KeyChar);

            string input = keyInfo.KeyChar + Console.ReadLine();
            int i;

            if (int.TryParse(input, out i) && i > 0 && i <= myTravelLog.Count)
            {
                myTravelLog.RemoveAt(i - 1);
                Console.Clear();
                Console.WriteLine("Resmålet har tagits bort.");
            }
            else
            {
                Console.WriteLine("Ogiltigt index. Försök igen.");
            }

            ReturnToMenu();
        }

        public static void ShowStatistics(List<TravelLogEntry> myTravelLog)
        {
            Console.Write($"Totalt antal resor: {myTravelLog.Count}");
            ReturnToMenu();

        }

        public static void ClearList(List<TravelLogEntry> myTravelLog)
        {
            Console.WriteLine("Är du helt säker på att du vill rensa loggen?");
            Console.Write("J / N: ");
            string choice = Console.ReadLine();
            choice.ToLower();
            switch (choice)
            {
                case "j":
                    myTravelLog.Clear();
                    Console.Write("Rensar loggen");
                    DotPause();
                    Console.Clear();
                    Console.WriteLine("Loggen har rensats!");
                    ReturnToMenu();
                    break;

                case "n": Console.Clear(); return;
            }
        }

        public static void DotPause()
        {
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(250);
                Console.Write(".");
                Thread.Sleep(250);
            }
        }

        public static void LoadList(string filePath, ref List<TravelLogEntry> myTravelLog)
        {
            try
            {
                if (File.Exists(filePath)) // Kollar om listan finns...
                {
                    string json = File.ReadAllText(filePath);
                    myTravelLog = JsonSerializer.Deserialize<List<TravelLogEntry>>(json) ?? new List<TravelLogEntry>();
                }
                else // ...eller om den inte finns, och initierar då en ny lista
                {
                    myTravelLog = new List<TravelLogEntry>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod vid laddning av listan: {ex.Message}");
                myTravelLog = new List<TravelLogEntry>(); // Vid eventuellt fel, initierar en ny lista
            }
        }
        public static void SaveListBeforeExit(string filePath, List<TravelLogEntry> myTravelLog)
        {
            try
            {
                // Sparar ner listan till JSON-filen
                string json = JsonSerializer.Serialize(myTravelLog);
                File.WriteAllText(filePath, json);

                // Visar användarmeddelanden
                Console.Write("Sparar listan");
                DotPause();
                Console.Clear();
                Console.WriteLine("Sparningen lyckades!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod vid sparningen av listan: {ex.Message}");
            }

            Console.WriteLine("Tryck på valfri knapp för att avsluta programmet.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }

    public class TravelLogEntry
    {
        public string Location { set; get; }
        public int Year { set; get; }
        public string Description { set; get; }
        public int Rating { set; get; }
    }
}