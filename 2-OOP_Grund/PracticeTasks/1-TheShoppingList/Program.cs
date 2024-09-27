using System.Text.Json;

namespace Shoppinglistan
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Deklarerar JSON-fil för listan
            string filePath = "ShoppingList.json";
            List<string> shoppingList = new List<string>();

            // Laddar lista från JSON-fil
            LoadList(filePath, ref shoppingList);

            while (true)
            {
                Console.WriteLine("---------- Shoppinglistan ----------");
                Console.WriteLine("1 - Visa hela listan");
                Console.WriteLine("2 - Lägg till artikel");
                Console.WriteLine("3 - Ta bort artikel");
                Console.WriteLine("4 - Sök i listan");
                Console.WriteLine("5 - Avsluta programmet");
                Console.Write("Mitt val: ");
                string input = Console.ReadLine();
                int choice = int.Parse(input);
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        ShowList(shoppingList);
                        ReturnToMenu();
                        break;

                    case 2:
                        AddItem(shoppingList);
                        break;

                    case 3:
                        ShowList(shoppingList);
                        RemoveItem(shoppingList);
                        break;

                    case 4:
                        SearchList(shoppingList);
                        break;

                    case 5:
                        SaveListBeforeExit(filePath, shoppingList);
                        break;
                }
            }
        }

        public static void ReturnToMenu()
        {
            Console.WriteLine("Tryck på valfri knapp för att återgå till menyn.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ShowList(List<string> shoppingList)
        {
            Console.Clear();
            if (shoppingList.Count == 0)
            {
                Console.WriteLine("Din lista är tom.");
            }
            foreach (string item in shoppingList)
            {
                Console.WriteLine($"{item}");
            }
        }

        public static void AddItem(List<string> shoppingList)
        {
            Console.WriteLine("Vad vill du lägga till i listan?");
            string itemToAdd = Console.ReadLine();
            shoppingList.Add(itemToAdd);
            Console.Clear();
            Console.WriteLine($"{itemToAdd} har lagts till i listan.");
            ReturnToMenu();
        }

        public static void RemoveItem(List<string> shoppingList)
        {
            Console.WriteLine("\nVad vill du ta bort från listan?");
            string itemToRemove = Console.ReadLine();
            shoppingList.Remove(itemToRemove);
            Console.Clear();
            Console.WriteLine($"{itemToRemove} har tagits bort från listan.");
            ReturnToMenu();
        }

        public static void SearchList(List<string> shoppingList)
        {
            Console.WriteLine("Vad vill du söka efter?");
            string itemToLookFor = Console.ReadLine();
            Console.Clear();
            if (!shoppingList.Contains(itemToLookFor))
            {
                Console.WriteLine("Denna artikel finns inte i listan.");
            }
            else
            {
                Console.WriteLine($"{itemToLookFor} finns i listan.");
                ReturnToMenu();
            }
        }

        public static void LoadList(string filePath, ref List<string> shoppingList)
        {
            try
            {
                if (File.Exists(filePath)) // Kollar om listan finns...
                {
                    string json = File.ReadAllText(filePath);
                    shoppingList = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
                }
                else // ...eller om den inte finns, och initierar då en ny lista
                {
                    shoppingList = new List<string>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod vid laddning av listan: {ex.Message}");
                shoppingList = new List<string>(); // Vid eventuellt fel, initierar en ny lista
            }
        }
        public static void SaveListBeforeExit(string filePath, List<string> shoppingList)
        {
            try { 
            // Sparar ner listan till JSON-filen
            string json = JsonSerializer.Serialize(shoppingList);
            File.WriteAllText(filePath, json);

            // Visar användarmeddelanden
            Console.WriteLine("Sparar listan...");
            Thread.Sleep(2000);
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
}