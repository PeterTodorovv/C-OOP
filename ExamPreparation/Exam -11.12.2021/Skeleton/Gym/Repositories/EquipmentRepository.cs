using Gym.Models.Athletes.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IAthlete>
    {
        public List<IAthlete> athletes;
        public EquipmentRepository() 
        {
            athletes = new List<IAthlete>();
        }

        public IReadOnlyCollection<IAthlete> Models => athletes;

        public void Add(IAthlete model)
        {
            throw new NotImplementedException();
        }

        public IAthlete FindByType(string type)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IAthlete model)
        {
            throw new NotImplementedException();
        }
    }
}
