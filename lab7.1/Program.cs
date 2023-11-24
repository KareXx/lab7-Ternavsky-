using lab7._1;
using System;
using System.Collections.Generic;

namespace lab7._1{


    class Program
{
        static void Main()
        {
            Repository<Person> personRepository = new Repository<Person>();
            personRepository.Add(new Person("John", 26));
            personRepository.Add(new Person("Jane", 30));
            personRepository.Add(new Person("Bob", 22));

            Criteria<Person> criteria = person => person.Age > 25;

            List<Person> result = personRepository.Find(criteria);

            Console.WriteLine("Результати пошуку:");
            foreach (var person in result)
            {
                Console.WriteLine($"{person.Name}, {person.Age} років");
            }
        }
    }

}
