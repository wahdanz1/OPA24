namespace Ovning3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Is the weather good today? \nReply with Y / N: ");
            string answer = Console.ReadLine();
            answer = answer.ToUpper();

            if (answer == "Y")
            {
                Console.WriteLine("That's great! Let's have a picnic!");
            }
            else
            {
                Console.WriteLine("That's sad. Let's stay inside and read a book instead.");
            }

        }
    }
}