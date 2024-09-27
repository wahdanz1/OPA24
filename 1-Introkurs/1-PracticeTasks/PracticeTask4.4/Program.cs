namespace Ovning4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer;
            do
            {
                Console.WriteLine("Är vi framme snart?");
                answer = Console.ReadLine();
            }
            while (answer == "nej");

            /*
             * Lösningen var att korrigera den sista raden (while).
             * Innan så var den tilldelade, när den egentligen ska
             * vara jämförande.
             */

        }
    }
}