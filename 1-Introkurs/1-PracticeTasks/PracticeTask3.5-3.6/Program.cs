namespace Ovning3_5__3_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ange nuvarande temperatur för Stockholm: ");
            int firstCityTemp = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ange nuvarande temperatur för Göteborg: ");
            int secondCityTemp = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ange nuvarande temperatur för Malmö: ");
            int thirdCityTemp = Convert.ToInt32(Console.ReadLine());

            if (firstCityTemp == secondCityTemp && firstCityTemp == thirdCityTemp)
            {
                Console.Write("I nuläget är det lika varmt i samtliga städer.");
            }
            else if (firstCityTemp > secondCityTemp && firstCityTemp > thirdCityTemp)
            {
                Console.Write("I nuläget är det varmare i Stockholm än de övriga två städerna.");
            }
            else if (secondCityTemp > firstCityTemp && secondCityTemp > thirdCityTemp)
            {
                Console.Write("I nuläget är det varmare i Göteborg än de övriga två städerna.");
            }
            else if (thirdCityTemp > firstCityTemp && thirdCityTemp > secondCityTemp)
            {
                Console.Write("I nuläget är det varmare i Malmö än de övriga två städerna.");
            }
            else if (firstCityTemp == secondCityTemp && firstCityTemp > thirdCityTemp)
            {
                Console.Write("I nuläget delar Stockholm och Göteborg den högsta temperaturen.");
            }
            else if (firstCityTemp == thirdCityTemp && firstCityTemp > secondCityTemp)
            {
                Console.Write("I nuläget delar Stockholm och Malmö den högsta temperaturen.");
            }
            else if (secondCityTemp == thirdCityTemp && secondCityTemp > firstCityTemp)
            {
                Console.Write("I nuläget delar Göteborg och Malmö den högsta temperaturen.");
            }


            /* Sparas till senare:
            Console.Write("Enter the current temperature for Stockholm: ");
            int firstTemp = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the current temperature for Gothenburg: ");
            int secondTemp = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the current temperature for Malmö: ");
            int thirdTemp = Convert.ToInt32(Console.ReadLine());

            string[] cities = { "Stockholm", "Gothenburg", "Malmö" };
            int[] temps = { firstTemp, secondTemp, thirdTemp };

            int maxTemp = temps.Max();
            int maxIndex = Array.IndexOf(temps, maxTemp);

            Console.Write($"At this moment, it is warmer in {cities[maxIndex]} than in the other two cities.");
            */

        }
    }
}