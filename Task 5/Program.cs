using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    public struct Person
    {
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            Console.WriteLine("Please, give names and birth year of a person. Empty input will stop the input.");

            while (true)
            {
                Console.Write("Give a name: ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                string[] parts = input.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[1], out int yearOfBirth))
                {
                    var person = new Person
                    {
                        Name = parts[0].Trim(),
                        YearOfBirth = yearOfBirth
                    };

                    people.Add(person);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter data in the format 'Name, YearOfBirth'.");
                }
            }

            if (people.Count > 0)
            {
                Console.WriteLine($"You entered {people.Count} names.");
                Console.WriteLine("Names sorted by age (youngest to oldest):");
                

                var sortedPeople = people.OrderBy(p => DateTime.Now.Year - p.YearOfBirth).ToList();

                foreach (var person in sortedPeople)
                {
                    int age = DateTime.Now.Year - person.YearOfBirth;
                    Console.WriteLine($"{person.Name} is {age} years old");
                }
            }
            else
            {
                Console.WriteLine("No names were entered.");
            }
        }
    }
}
