namespace KlassenHighscore
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Skapar Highscore-klassen, max 5 i listan
            HighScore hsList = new HighScore(5);

            // Fyll på med element i listan:
            hsList.Add("Mononoke Hime", 132);
            hsList.Add("Agent Mulder", 120);
            hsList.Add("Captain Picard", 40);
            hsList.Add("Leia", 180);
            hsList.Add("Rick Reckard", 110);
            
            // Testutskrift
            hsList.Print();

            // Fyll på med fler element
            hsList.Add("Hal9000", 403);
            hsList.Add("David Bowie", 712);
            
            // Ny testutskrift
            hsList.Print();
        }
    }
}