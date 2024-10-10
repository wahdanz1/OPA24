using static Polisen.Dispatch;

namespace Polisen
{
    public class DispatchHandler
    {
        public static void RegisterNew(List<Employee> employeeList, List<Dispatch> dispatchList)
        {
            Console.Clear();
            Console.WriteLine("----- Registrering av utryckning -----");

            CrimeType selectedCrimeType = GetCrimeType();
            string location = GetLocation();
            DateTime dateAndTime = GetDateTime();
            List<Employee> attendingEmployees = GetAttendingEmployees(employeeList);
            string comments = GetComments();

            Dispatch dispatch = new Dispatch(selectedCrimeType, location, dateAndTime, attendingEmployees, comments);

            // Shows summary + adds the new dispatch to the dispatch list
            ShowSummary(dispatch);
            dispatchList.Add(dispatch);
            Program.ReturnToMenu();
        }

        private static CrimeType GetCrimeType()
        {
            Console.WriteLine("Vilken typ av brott gäller det?"); // Val med piltangenter/siffror utifrån brottstyper?
            var crimeTypes = Enum.GetValues(typeof(CrimeType)).Cast<CrimeType>().ToList();
            for (int i = 0; i < crimeTypes.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {CrimeTypeTranslations[crimeTypes[i]]}");
            }
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > crimeTypes.Count)
            {
                Console.WriteLine("Ogiltigt val, försök igen.");
            }

            Console.Clear();
            return crimeTypes[choice - 1];
        }

        private static string GetLocation()
        {
            Console.WriteLine("Vilken plats? Ange i formatet Stad, område, exempelvis \"Göteborg, Majorna\"");
            string location = Console.ReadLine();

            Console.Clear();
            return location;
        }

        private static DateTime GetDateTime()
        {
            DateTime dateAndTime;
            Console.WriteLine("Ange datum och tid i formatet ÅÅÅÅ-MM-DD TT:MM (exempelvis 2024-09-28 13:22)");
            while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out dateAndTime))
            {
                Console.WriteLine("Felaktigt format. Försök igen med formatet ÅÅÅÅ-MM-DD TT:MM.");
            }

            Console.Clear();
            return dateAndTime;
        }

        private static List<Employee> GetAttendingEmployees(List<Employee> employeeList)
        {
            Console.WriteLine("Vilka poliser var närvarande?");

            // Listar alla anställda i employeeList
            foreach (var employee in employeeList)
            {
                Console.WriteLine($"{employee.StaffID} - {employee.LastName}, {employee.FirstName}");
            }

            Console.WriteLine("\nAnge Tjänste-ID för samtliga närvarande, separera med komma.");
            string input = Console.ReadLine();
            string[] ids = input.Split(',');

            List<Employee> attendingEmployees = new List<Employee>();
            foreach (string id in ids)
            {
                int parseId;
                if (int.TryParse(id.Trim(), out parseId))
                {
                    Employee employee = employeeList.FirstOrDefault(e => e.StaffID == parseId);
                    if (employee != null)
                    {
                        attendingEmployees.Add(employee);
                    }
                }
            }

            Console.Clear();
            return attendingEmployees;
        }

        private static string GetComments()
        {
            Console.WriteLine("Ange eventuella kommentarer (rapporten skrivs separat): ");
            string comments = Console.ReadLine();

            Console.Clear();
            return comments;
        }

        private static void ShowSummary(Dispatch dispatch)
        {
            Console.WriteLine("\n----- Utryckningssammanfattning -----");
            Console.WriteLine($"Brottstyp: {CrimeTypeTranslations[dispatch.Type]}");
            Console.WriteLine($"Plats: {dispatch.Location}");
            Console.WriteLine($"Tid och datum: {dispatch.DateAndTime}");
            Console.WriteLine("Närvarande poliser:");

            foreach (var employee in dispatch.AttendingEmployees)
            {
                Console.WriteLine($"[{employee.StaffID}] {employee.FirstName} {employee.LastName}");
            }

            Console.WriteLine($"Kommentarer: {dispatch.Comments}");
            Console.WriteLine("--------------------------------------\n");
        }

        public static void ViewAll(List<Dispatch> dispatchList, List<string> policeStationsList)
        {
            Console.Clear();
            Console.WriteLine("----- Utryckningar -----");
            for (int i = 0; i < dispatchList.Count; i++)
            {
                Dispatch dispatch = dispatchList[i];
                Console.Write($"[#{i}] ");
                Console.Write($"{dispatch.DateAndTime} | ");
                Console.Write($"{dispatch.Location} | ");
                Console.Write($"{CrimeTypeTranslations[dispatch.Type]}");
                Console.WriteLine();
                Console.WriteLine("Närvarande poliser: ");

                foreach (var employee in dispatch.AttendingEmployees)
                {
                    Console.WriteLine($"[{employee.StaffID}] {employee.FirstName} {employee.LastName}");
                }

                Console.WriteLine($"Ev. kommentar: {dispatch.Comments}");
                Console.WriteLine("--------------------------------------");
            }
            
            Console.WriteLine("Ange ID för att visa rapport"); // This opens up the Dispatch object with the same summary display as in the end of RegisterNew (ShowSummary-method), followed by the report (not yet implemented) and a "Uppdatera rapport"-option (or "Skriv rapport" if no report is present)
            GetDispatchToView(dispatchList, policeStationsList);
            
            Program.ReturnToMenu();
        }

        private static void GetDispatchToView(List<Dispatch> dispatchList, List<string> policeStationsList)
        {
            int idToView = int.Parse(Console.ReadLine());

            if (idToView < 0 || idToView >= dispatchList.Count - 1)
            {
                Console.WriteLine("Det finns ingen utryckning med detta ID. Ange ett giltigt ID.");
                Program.ReturnToMenu();
                return;
            }

            Dispatch selectedDispatch = dispatchList[idToView];
            ShowSummary(selectedDispatch);

            if (selectedDispatch.Report == null)
            {
                Console.WriteLine("Det finns ingen rapport kopplad till denna utryckning.");
                Console.WriteLine("Vill du skriva en ny rapport? (Ja / Nej)");
                if (ConfirmAction())
                {
                    selectedDispatch.Report = Report.WriteNew(idToView, policeStationsList);
                    Console.WriteLine("Rapporten skapad och kopplad till utryckningen.");
                }
                else
                {
                    Console.WriteLine("Åtgärden avbröts.");
                }
            }
            else
            {
                Report.ShowReport(selectedDispatch.Report);
            }
        }

        private static bool ConfirmAction()
        {
            var response = Console.ReadLine()?.Trim().ToLower();
            return response == "ja" || response == "j";
        }
    }
}