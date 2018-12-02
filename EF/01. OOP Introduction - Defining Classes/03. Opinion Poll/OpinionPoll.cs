using System;
using System.Linq;
using System.Collections.Generic;

public class OpinionPoll
{
    static void Main(string[] args)
    {
        int numberOfInputLines = Convert.ToInt16(Console.ReadLine());

        ICollection<Person> givenPersons = new List<Person>();

        for (int count = 0; count < numberOfInputLines; count++)
        {
            string[] currentInputLine = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string name = currentInputLine[0];
            int age = Convert.ToInt32(currentInputLine[1]);

            Person newPerson = new Person(name, age);
            givenPersons.Add(newPerson);
        }

        Console.WriteLine(string.Join(Environment.NewLine, 
            givenPersons.Where(x => x.Age > 30).OrderBy(x => x.Name)));
    }
}
