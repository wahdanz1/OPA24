// This is a classic one. Most integers will work in this example, but one will fail in one case...
// No need to debug here really, but how would you solve it?
namespace DebugExample
{
    class Division
    {
        public static void Calculator()
        {
            Console.WriteLine("Welcome to the Division Program!");
            while(true) // loop to restart if the user enters things that are not numbers...
            {
                Console.Write("Enter the numerator: ");
                if(!int.TryParse(Console.ReadLine(), out int numerator))
                {
                    Console.WriteLine("Only numbers allowed!");
                    continue;
                }
                Console.Write("Enter the denominator: ");
                if(!int.TryParse(Console.ReadLine(), out int denominator) || denominator == 0)
                {
                    Console.WriteLine("Only numbers allowed (except for '0'!");
                    continue;
                }

                float quotient = numerator / (float)denominator;

                Console.WriteLine($"The quotient of {numerator} and {denominator} is: {quotient}");
                break; // if we reach this code, the user has not entered anything wrong and we can end this method.
            }
        }
    }
}