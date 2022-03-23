using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    internal class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> racers;
        public IReadOnlyCollection<IRacer> Models => racers;

        public void Add(IRacer model)
        {
            if(model == null)
            {
                throw new ArgumentException("Cannot add null in Racer Repository");
            }

            racers.Add(model);
        }

        public IRacer FindBy(string property)
        {
            return racers.FirstOrDefault(r => r.Username == property);
        }

        public bool Remove(IRacer model)
        {
            return racers.Remove(model);
        }
    }
}
