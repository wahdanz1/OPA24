namespace Polisen
{
    public class Employee
    {
        public int StaffID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }

        public Employee(int staffID, string firstName, string lastName)
        {
            StaffID = staffID;
            FirstName = firstName;
            LastName = lastName;
        }

        public static void ViewAll(List<Employee> employeeList)
        {
            Console.Clear();

            Console.WriteLine("----- Personallista -----");
            Console.WriteLine("TjänsteID  |  Efternamn  |  förnamn");
            for (int i = 0; i < employeeList.Count; i++)
            {
                Console.WriteLine($"{employeeList[i].StaffID} | {employeeList[i].LastName}, {employeeList[i].FirstName}");
            }
        }

        public static void WaitForEmployeeCommand(List<Employee> employeeList, List<Employee> oldEmployeesList, List<Dispatch> dispatchList)
        {
            Console.WriteLine("[L]ägg till anställd  |  [T]a bort anställd  |  [G]å tillbaka till huvudmenyn");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.L)
            {
                AddNewEmployee(employeeList, oldEmployeesList);
            }
            else if (keyInfo.Key == ConsoleKey.T)
            {
                RemoveEmployee(employeeList, oldEmployeesList, dispatchList);
            }
            else if (keyInfo.Key == ConsoleKey.G) // Exit
            {
                return;
            }
        }

        public static void AddNewEmployee(List<Employee> employeeList, List<Employee> oldEmployeesList)
        {
            Console.Clear();
            Console.WriteLine("----- Registrering av ny personal -----");

            string firstName = getFirstName();
            string lastName = getLastName();
            int staffID = generateStaffID(employeeList, oldEmployeesList);

            Employee newEmployee = new Employee(staffID, firstName, lastName);

            ShowSummary(newEmployee);
            employeeList.Add(newEmployee);
        }

        private static string getFirstName()
        {
            Console.WriteLine("Ange den anställdes förnamn: ");
            string firstName = Console.ReadLine();

            Console.Clear();
            return firstName;
        }

        private static string getLastName()
        {
            Console.WriteLine("Ange den anställdes efternamn: ");
            string firstName = Console.ReadLine();

            // Make sure only first letter is uppercase (works for multiple last names)


            Console.Clear();
            return firstName;
        }

        private static int generateStaffID(List <Employee> employeeList, List <Employee> oldEmployeesList)
        {
            // Genererar ett slumpmässigt staffID back-end
            Random newRandomEmployeeNo = new Random();
            int staffID;

            do
            {
                // Loopar random-nummer tills ett som inte redan existerar hittas
                staffID = newRandomEmployeeNo.Next(1001, 5001);
            }
            while (employeeList.Any(e => e.StaffID == staffID) || oldEmployeesList.Any(e => e.StaffID == staffID));
            
            return staffID;
        }

        private static void ShowSummary(Employee newEmployee)
        {
            Console.WriteLine("\n----- Sammanfattning för ny personal -----");
            Console.WriteLine($"Tjänstenummer: {newEmployee.StaffID}");
            Console.WriteLine($"Efternamn, förnamn: {newEmployee.LastName}, {newEmployee.FirstName}");
            Console.WriteLine("--------------------------------------");

            Program.ReturnToMenu();
        }

        public static void RemoveEmployee(List<Employee> employeeList, List<Employee> oldEmployeesList, List<Dispatch> dispatchList)
        {
            ViewAll(employeeList);
            if (employeeList.Count == 0)
            {
                Console.WriteLine("Det finns inga anställda i systemet.");
                Program.ReturnToMenu();
                return;
            }
            Console.WriteLine("\nVem önskar du ta bort? Ange tjänstenummer följt av [Enter]");

            // Inväntar användarinmatning (tjänstenummer)
            int employeeToRemoveID = int.Parse(Console.ReadLine());
            Employee employeeToRemove = employeeList.FirstOrDefault(e => e.StaffID == employeeToRemoveID);
            
            // Kollar om tjänstenumret finns i employeeList
            if (employeeToRemove == null)
            {
                Console.WriteLine("Ingen anställd med det tjänstenumret hittades.");
                Program.ReturnToMenu();
                return;
            }

            // Kollar om tjänstenumret är kopplad till någon utryckning
            bool isEmployeeInDispatch = dispatchList.Any(d => d.AttendingEmployees.Any(e => e.StaffID == employeeToRemoveID));
            if (isEmployeeInDispatch)
            {
                Console.WriteLine("Anställd är kopplad till en eller flera utryckningar.");
                Console.WriteLine("Är du säker på att du vill flytta dem till listan för tidigare anställda? Detta går inte att ångra.");
                Console.WriteLine("Ja / Nej");

                if (ConfirmAction())
                {
                    // Om kopplad till utryckning, flyttar till arkivlista för tidigare anställda
                    oldEmployeesList.Add(employeeToRemove);
                    employeeList.Remove(employeeToRemove);
                    Console.WriteLine("Anställd flyttades till listan för tidigare anställda, då de är kopplade till en eller flera utryckningar.");
                }
                else 
                {
                    Console.WriteLine("Åtgärden avbröts.");
                }
                
            }
            else
            {
                Console.WriteLine("Är du säker på att du vill ta bort anställd från systemet? Detta går inte att ångra.");
                Console.WriteLine("Ja / Nej");
                if (ConfirmAction())
                {
                    // Om ej kopplad till utryckning, tar bort helt från systemet
                    employeeList.Remove(employeeToRemove);
                    Console.WriteLine("Anställd togs bort från systemet.");
                }
                else 
                {
                    Console.WriteLine("Åtgärden avbröts.");
                }                
            }

            Program.ReturnToMenu();
        }

        private static bool ConfirmAction()
        {
            var response = Console.ReadLine()?.Trim().ToLower();
            return response == "ja" || response == "j";
        }

        
    }
}