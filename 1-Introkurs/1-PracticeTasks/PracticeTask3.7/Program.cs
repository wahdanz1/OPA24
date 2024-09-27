namespace Ovning3_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hur varmt är vattnet?: ");
            int waterTemp = Convert.ToInt32(Console.ReadLine());

            if (waterTemp >= 100)
            {
                Console.Write("Vattnet kokar!");
            }
            else if (waterTemp >= 90)
            {
                Console.Write("Vattnet är väldigt varmt och börjar snart att koka!");
            }
            else if (waterTemp >= 65)
            {
                Console.Write("Vattnet är väldigt hett!");
            }
            else if (waterTemp >= 46)
            {
                Console.Write("Vattnet är varmt men inte jättehett!");
            }
            else if (waterTemp >= 30 && waterTemp <= 45)
            {
                if (waterTemp == 37)
                {
                    Console.Write("Vattnet är kropstempererat!");
                } else { 
                Console.Write("Vattnet är ljummet!");
                }
            }
            else if (waterTemp >= 10)
            {
                Console.Write("Vattnet är lite kallt men inte fruset!");
            }
            else if (waterTemp >= 1)
            {
                Console.Write("Vattnet är väldigt kallt, men inte fruset!");
            }
            else if (waterTemp == 0)
            {
                Console.Write("Vattnet är precis vid fryspunkten och har börjat frysa!");
            }
            else if (waterTemp < 0)
            {
                Console.Write("Vattnet är fruset!");
            }

        }
    }
}