using System;

namespace CodeChallenge.Domain.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }
        public string CurrentRole { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
        public int NumberOfRecommendations { get; set; }
        public int NumberOfConnections { get; set; }

        public static Person FromCsv(string fileLine)
        {
            var line = fileLine.Split('|');

            return new Person
            { 
                PersonId = Convert.ToInt32(line[0]),
                Name = Convert.ToString(line[1]),
                LastName = Convert.ToString(line[2]),
                CurrentRole = Convert.ToString(line[3]),
                Country = Convert.ToString(line[4]),
                Industry = Convert.ToString(line[5]),
                NumberOfRecommendations = Convert.ToInt32(line[6]),
                NumberOfConnections = Convert.ToInt32(line[7])
            };
        }
    }
}
