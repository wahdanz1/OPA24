namespace Ovning3_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int var = 10;
            if (var == 10)
            {
                Console.WriteLine("den är 10!");
            }
            else { }    

        }
    }
}

/*
 * På rad 8 så sker inte en jämförelse ("==", "är värdet för variabeln "var" 10?")
 * utan istället en tilldelning ("=") och därför har inte if-satsen något
 * sant/falskt värde att utgå ifrån.
 */