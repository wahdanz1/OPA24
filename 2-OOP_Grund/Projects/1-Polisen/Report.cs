using System.Reflection.Metadata;

namespace Polisen
{
    public class Report
    {
        public int ReportID { set; get; }
        public DateTime DateAndTime { set; get; }
        public string PoliceStation { set; get; }
        public string Description { set; get; }

        public static Report WriteNew(int dispatchID, List<string> policeStationsList)
        {
            Console.Clear();
            Console.WriteLine("Välj ansvarig polisstation: ");
            ViewAllStations(policeStationsList);
            int policeStation = GetStationChoice(policeStationsList);
            Console.WriteLine("Beskriv utryckningen: ");
            string description = Console.ReadLine();

            return new Report
            {
                ReportID = dispatchID,
                PoliceStation = policeStationsList[policeStation -1],
                DateAndTime = DateTime.Now,
                Description = description
            };
        }

        private static void ViewAllStations(List<string> policeStationsList)
        {
            for (int i = 0; i < policeStationsList.Count; i++)
            {
                Console.WriteLine($"[{i+1}] {policeStationsList[i]}");
            }
        }

        private static int GetStationChoice(List<string> policeStationsList)
        {
            int policeStationChoice;
            while (true)
            {
                Console.WriteLine("\nAnge ID för ansvarig polisstation, följt av [Enter]:");
                if (int.TryParse(Console.ReadLine(), out policeStationChoice) && policeStationChoice > 0 && policeStationChoice <= policeStationsList.Count)
                {
                    return policeStationChoice;
                }
                Console.WriteLine("Ogiltigt val, vänligen försök igen.");
            }
        }

        public static void ShowReport(Report report)
        {
            Console.WriteLine($"----- Detaljer för rapport #{report.ReportID} -----");
            Console.WriteLine($"Upprättad {report.DateAndTime} på {report.PoliceStation}s Polisstation");
            Console.WriteLine("Beskrivning: ");
            Console.WriteLine(report.Description);
            Console.WriteLine("--------------------------------------");
        }
    }
}