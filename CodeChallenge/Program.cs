using CodeChallenge.Domain.Entities;
using CodeChallenge.Domain.Services;
using CodeChallenge.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var scoreService = new ScoringService();

            var peopleList = FileRepository.ReadFile();

            var peopleScore = scoreService.RateClients(peopleList);

            FileRepository.WriteFile(SortAndFilter(peopleList, peopleScore));
        }

        private static IEnumerable<Person> SortAndFilter(IEnumerable<Person> people, IEnumerable<KeyValuePair<int, decimal>> peopleScores)
        {
            var top100 = peopleScores.OrderBy(x => x.Value).Select(p => p.Key).Take(100);

            return people.Where(p => top100.Contains(p.PersonId));
        }
    }
}
