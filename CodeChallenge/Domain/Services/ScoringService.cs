using CodeChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Domain.Services
{
    public class ScoringService
    {
        private const int ROLE_WEIGTH = 40;
        private const int INDUSTRY_WEIGTH = 30;
        private const decimal CONNECTIONS_FACTOR = 1 / 30;
        private const decimal RECOMENDATIONS_FACTOR = 1 / 50;

        private readonly string[] baires_roles = new string[] { "PRODUCT MANAGER", "VP OF ENGINEERING", "SVP", "MANAGING DIRECTOR", "PROGRAM MANAGER", "CTO", "BUSINESS DEVELOPMENT", "DIRECTOR OF ARCHITECTURE", "VP TECHNOLOGY SERVICES", "CEO", "FOUNDER", "OWNER", "CHIEF EXECUTIVE OFFICER", "VICE PRESIDENT", "PRESIDENT", "PROJECT MANAGER", "DIRECTOR", "SUPERVISOR" };
        private readonly string[] baires_indistries = new string[] { "BANKING", "BUSINESS SERVICES", "FINANCIAL SERVICES", "CAPITAL MARKETS", "COMPUTER GAMES", "CONSUMER GOODS", "DESIGN", "ELECTRICAL MANUFACTURING", "ELECTRONICS", "ELECTRONIC MANUFACTURING", "ENERGY", "RESOURCES", "UTILITIES", "ENTERTAINMENT", "SPORTS", "GOVERNMENT", "HEALTHCARE", "HIGH TECH", "HUMAN RESOURCES", "INFORMATION TECHNOLOGY", "INSURANCE", "MANUFACTURING", "MEDIA & INFORMATION SERVICES", "PHARMACEUTICALS", "BIOTECH", "PUBLISHING", "REAL ESTATE", "RETAIL", "CONSUMER PRODUCTS", "STAFFING", "RECRUITING", "TELECOMMUNICATIONS", "TEXTILES", "TOLLING", "AUTOMATION", "TRAVEL", "TRANSPORTATION", "HOSPITALITY" };

        public IEnumerable<KeyValuePair<int, decimal>> RateClients(IEnumerable<Person> peopleList)
        {
            var peopleScore = new List<KeyValuePair<int, decimal>>();
            foreach (var people in peopleList)
            {
                try
                {
                    peopleScore.Add(new KeyValuePair<int, decimal>(people.PersonId, PersonScore(people)));
                }
                catch (Exception)
                {
                    Console.WriteLine($"Error generando calificación para usuario con identificación: {people.PersonId}");
                }
            }

            return peopleScore;
        }

        private decimal PersonScore(Person people)
        {
            var score = 0M;

            score += baires_roles.Any(r => people.CurrentRole.ToUpper().Contains(r)) ? ROLE_WEIGTH : 0;
            score += baires_indistries.Any(r => people.Industry.ToUpper().Contains(r)) ? INDUSTRY_WEIGTH : 0;

            score += people.NumberOfConnections * CONNECTIONS_FACTOR;
            score += people.NumberOfRecommendations * RECOMENDATIONS_FACTOR;

            return score;
        }
    }
}
