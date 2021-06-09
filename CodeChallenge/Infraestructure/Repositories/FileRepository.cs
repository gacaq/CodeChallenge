using CodeChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeChallenge.Infraestructure.Repositories
{
    internal static class FileRepository
    {
        internal static List<Person> ReadFile()
        {
            var values = new List<Person>();
            try
            {
                values = File.ReadAllLines("people.in")
                                               .Select(v => Person.FromCsv(v))
                                               .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading a file. Please check your file");
            }

            return values;
        }

        internal static void WriteFile(IEnumerable<Person> people)
        {
            try
            {
                var fields = typeof(Person).GetProperties();
                var peopleStrings = people.Select(x =>
                                 string.Join("|", fields.Select(f => f.GetValue(x)))
                             );


                File.WriteAllLines("people.out", peopleStrings.Select(x => x));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing a file. Please try again");
            }
        }
    }
}
