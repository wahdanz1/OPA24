using System.Text.Json;

namespace Polisen
{
    class Program
    {
        // Initierar nödvändiga listor (utryckningar, rapporter, personal)
        public static List<Dispatch> dispatchList = new List<Dispatch>();
        public static List<Employee> employeeList = new List<Employee>();
        public static List<Employee> oldEmployeesList = new List<Employee>();
        public static List<string> policeStationsList = new List<string>
        {
            "Stockholm",
            "Göteborg",
            "Malmö",
            "Visby",
            "Uddevalla",
            "Trollhättan",
            "Umeå"
        };
        
        public static void Main(string[] args)
        {
            // Deklarerar JSON-fil för listorna
            string dispatchFilePath = "dispatchlist.json";
            string employeeFilePath = "employeelist.json";
            string oldEmployeesFilePath = "oldemployeelist.json";

            // Laddar listor (om de finns) från JSON-fil
            LoadDispatchList(dispatchFilePath, ref dispatchList);
            LoadEmployeeList(employeeFilePath, ref employeeList);
            // LoadOldEmployees(oldEmployeesFilePath, ref oldEmployeesList);

            // Visar menyn
            DisplayMenu();
        }

        public static void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("----- RAPPORTSYSTEM 80 -----");
                Console.WriteLine("Vad vill du göra?");
                Console.WriteLine();
                Console.WriteLine("[R]egistrera utryckning");
                Console.WriteLine("[V]isa brottsfall");
                Console.WriteLine("[L]ägg till/ta bort personal");
                Console.WriteLine("[A]vsluta");

                Console.WriteLine("\nAnge första bokstaven för att göra ditt val  |  [A] för att avsluta");

                WaitForMenuChoice();
            }
        }

        public static void WaitForMenuChoice()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.R)
                {
                    DispatchHandler.RegisterNew(employeeList, dispatchList);
                    SaveDispatchList();
                }
                else if (keyInfo.Key == ConsoleKey.V)
                {
                    DispatchHandler.ViewAll(dispatchList, policeStationsList);
                }
                else if (keyInfo.Key == ConsoleKey.L)
                {
                    Employee.ViewAll(employeeList);
                    Employee.WaitForEmployeeCommand(employeeList, oldEmployeesList, dispatchList);
                    SaveEmployeeList();
                }
                else if (keyInfo.Key == ConsoleKey.A) // Exit
                {
                    return;
                }
                Console.Clear();
        }

        public static void ReturnToMenu()
        {
            Console.WriteLine("\nTryck på valfri knapp för att gå tillbaka/fortsätta");
            Console.ReadKey();
            Console.Clear();
        }

        public static void LoadDispatchList(string dispatchFilePath, ref List<Dispatch> dispatchList)
        {
            try
            {
                if (File.Exists(dispatchFilePath)) // Kollar om listan finns...
                {
                    string json = File.ReadAllText(dispatchFilePath);
                    dispatchList = JsonSerializer.Deserialize<List<Dispatch>>(json) ?? new List<Dispatch>();
                }
                else // ...eller om den inte finns, och initierar då en ny lista
                {
                    dispatchList = new List<Dispatch>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod vid laddning av listan: {ex.Message}");
                dispatchList = new List<Dispatch>(); // Vid eventuellt fel, initierar en ny lista
            }
        }

        public static void LoadEmployeeList(string employeeFilePath, ref List<Employee> employeeList)
        {
            try
            {
                if (File.Exists(employeeFilePath)) // Kollar om listan finns...
                {
                    string json = File.ReadAllText(employeeFilePath);
                    employeeList = JsonSerializer.Deserialize<List<Employee>>(json) ?? new List<Employee>();
                }
                else // ...eller om den inte finns, och initierar då en ny lista
                {
                    employeeList = new List<Employee>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod vid laddning av listan: {ex.Message}");
                employeeList = new List<Employee>(); // Vid eventuellt fel, initierar en ny lista
            }
        }

        public static void SaveDispatchList()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(dispatchList, options);
            File.WriteAllText("DispatchList.json", jsonString);
        }

        public static void SaveEmployeeList()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(employeeList, options);
            File.WriteAllText("EmployeeList.json", jsonString);
        }
    }
}