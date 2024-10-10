namespace DebugExample
{
    public class Person
    {
        public string name;
        public int personalNr;

        public Person(string name, int personalNr)
        {
            this.name = name;
            this.personalNr = personalNr;
        }
    }
    // There is something wrong with this code.
    // 1) Just run this code and see what happens. Do NOT google or chatgpt how binary search
    //      is supposed to work. That will spoil this exercise.
    // 2) Try to search with different personal numbers - do some seem to work?
    // 3) Try different numbers while using the debugger, and step trough the search algorithm step
    //      --> what happens?
    // 4) What conclutions can you draw from this?
    // 5) Ok. Now that you've found the error. Can you find a way to solve it? Now you can use google...

    public class BinarySearch
    {
        public static void TestBS()
        {
            List<Person> people = new List<Person>
            {
                new Person("Anna Andersson", 50125),
                new Person("Bertil Bengtsson", 50232),
                new Person("Carl Carlsson", 50315),
                new Person("David Davidsson", 50375)
            };

            // Sort the list before searchning. Necessary for binary search.
            people.Sort((a, b) => a.personalNr.CompareTo(b.personalNr));

            
            int personalNrToFind = 50315;
            int index = DoBinarySearch(people, personalNrToFind);

            if(index != -1)
            {
                Console.WriteLine($"Personen {people[index].name} med personnummer {personalNrToFind} hittades på index {index}.");
            }
            else
            {
                Console.WriteLine($"Personen med personnummer {personalNrToFind} hittades inte.");
            }
        }


        private static int DoBinarySearch(List<Person> persons, int personalNr)
        {
            // bra ställe att sätta break point?
            // Första varvet: firstIndex = 0, lastIndex = 3, indexToCheck = (0+3)/2 = 1.5 avrundat ner till 1
            // Andra varvet: firstIndex = 1, lastIndex = 3, indexToCheck = (1+3)/2 = 2
            // Tredje varvet: firstIndex = 2, lastIndex = 3, indexToCheck = (2+3)/2 = 2.5 avrundat ner till 2
            
            // Om jag lägger till en inkrementering på "indexToCheck" innan jag tilldelar det till firstIndex:
            // Första varvet: firstIndex = 0, lastIndex = 3, indexToCheck = (0+3)/2 = 1.5 avrundat ner till 1
            // Andra varvet: firstIndex = 2, lastIndex = 3, indexToCheck = (2+3)/2 = 2.5 avrundat ner till 2
            // Tredje varvet: firstIndex = 2, lastIndex = 3, indexToCheck = (2+4)/2 = 3

            int firstIndex = 0;
            int lastIndex = persons.Count - 1;

            while (firstIndex <= lastIndex)
            {
                int indexToCheck = (firstIndex + lastIndex) / 2; // Deklarar var sökningen ska börja (mitten), och uppdaterar varje varv för att söka ett steg upp/ner
                if (persons[indexToCheck].personalNr == personalNr) // Om personnumret som söks efter är det som är på aktuellt index...
                {
                    return indexToCheck; // ...skicka tillbaka värdet
                }
                else if (persons[indexToCheck].personalNr < personalNr) // Om "aktuellt" personnummer befinner sig i det högre intervallet...
                {
                    indexToCheck++;
                    firstIndex = indexToCheck; // ...flytta ner firstIndex till aktuell plats
                }
                else // Om "aktuellt" personnummer befinner sig i det lägre intervallet...
                {
                    lastIndex = indexToCheck; // ...flytta upp lastIndex till aktuell plats
                }
            }

            return -1; // Inte funnet
        }
    }
}
