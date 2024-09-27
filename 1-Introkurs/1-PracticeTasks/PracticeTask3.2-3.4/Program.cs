namespace Ovning3_2__3_3__3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Är vädret fint idag? \nSvara med J / N: ");
            string answer = Console.ReadLine();
            answer = answer.ToUpper();

            if (answer == "J") {
                Console.WriteLine("Fantastiskt! Låt oss ha picnick!");
            }
            else if (answer == "N") {
                Console.WriteLine("Vad synd. Låt oss läsa en bok istället!");
            } else {
                    Console.WriteLine("Jag förstår inte vad du menar.");
            }

        }
    }
}