namespace Polisen
{
    public class Dispatch
    {
        public CrimeType Type { set; get; }
        public string Location { set; get; }
        public DateTime DateAndTime { set; get; }
        public List<Employee> AttendingEmployees { set; get; }
        public string Comments { set; get; }
        public Report Report { set; get; }

        public Dispatch(CrimeType type, string location, DateTime dateAndTime, List<Employee> attendingEmployees, string comments)
        {
            Type = type;
            Location = location;
            DateAndTime = dateAndTime;
            AttendingEmployees = attendingEmployees;
            Comments = comments;
            Report = null;
        }

        public enum CrimeType
        {
            Robbery,
            Theft,
            Assault,
            Vandalism,
            Traffic,
            Other
        }

        public static Dictionary<CrimeType, string> CrimeTypeTranslations = new Dictionary<CrimeType, string>()
        {
            { CrimeType.Robbery, "Rån" },
            { CrimeType.Theft, "Stöld" },
            { CrimeType.Assault, "Misshandel" },
            { CrimeType.Vandalism, "Skadegörelse" },
            { CrimeType.Traffic, "Trafikbrott" },
            { CrimeType.Other, "Annat" }
        };

    }
}