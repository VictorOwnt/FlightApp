using FlightAppApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Repository
{
    public class StewardRepository : IStewardRepository
    {
        private List<Steward> Stewards { get; set; }

        public Steward GetSteward(string firstName, string lastName)
        {
            return Stewards.SingleOrDefault(p => p.FirstName == firstName && p.LastName == lastName);
        }
    }
}

