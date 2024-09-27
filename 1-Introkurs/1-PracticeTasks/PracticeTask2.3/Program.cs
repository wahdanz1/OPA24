namespace Ovning2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ange ett namn: ");
            string firstName = Console.ReadLine();

            Console.Write("Ange ett till namn: ");
            string secondName = Console.ReadLine();

            string storyBeginning = $"Det är en tisdag, och {firstName} och {secondName} har precis vaknat och gått upp.\n";
            string storyMiddle = $"{firstName} hade inte sovit så gott, på grund av mardrömmar. I de hemska drömmarna så jagade {secondName} efter {firstName} med en gigantisk gurka, och ropande upprepande \"JAG VILL INTE HA DINA PENGAR!\".\n";
            string storyEnd = $"Under frukosten så berättade {firstName} om mardrömmen för {secondName}. När {secondName} öppnade kylskåpet, och såg gurkan, så fanns det bara en sak att göra.";
            string story = storyBeginning+storyMiddle+storyEnd;

            Console.WriteLine($"{story}");
        }
    }
}