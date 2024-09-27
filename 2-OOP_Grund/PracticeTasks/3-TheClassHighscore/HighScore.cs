namespace KlassenHighscore
{
    internal class HighScore
    {
        int MaxInList {get; set;}

        // Konstruktor för klassen
        public HighScore(int maxInList)
        {
            MaxInList = maxInList;
        }

        // Lista för att hålla alla highscores
        public List<HSItem> hsItems = new List<HSItem>();

        // Lägger till nytt namn+poäng i listan om högre än de som redan finns i listan
        public void Add(string name, int points)
        {
            HSItem newItem = new HSItem { Name = name, Points = points};
            hsItems.Add(newItem);
            Sort();
        }

        // Printar ut hela listan
        public void Print()
        {
            Console.WriteLine("---------- Highscore ----------");
            for (int i = 0; i < hsItems.Count ; i++)
            {
                Console.WriteLine($"{i+1}. {hsItems[i].Name} ({hsItems[i].Points}p)");
            }
            Console.WriteLine();
        }

        // Sorterar listan
        private void Sort()
        {
            hsItems.Sort((x,y) => y.Points.CompareTo(x.Points)); // Sorterar från högt till lågt
            if (hsItems.Count > MaxInList)
            {
                hsItems.RemoveAt(hsItems.Count - 1); // Tar bort det lägsta poänget efter sorteringen
            }
        }
    }
}
