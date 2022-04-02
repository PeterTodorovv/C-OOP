using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Repositories
{
    internal class VesselRepository : IRepository<IVessel>
    {
        public List<IVessel> vessels;

        public VesselRepository()
        {
            vessels = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models => vessels;

        public void Add(IVessel model)
        {
            vessels.Add(model);
        }

        public IVessel FindByName(string name)
        {
            IVessel vessel = Models.FirstOrDefault(v => v.Name == name);
            return vessel;
        }

        public bool Remove(IVessel model)
        {
            return vessels.Remove(model);
            
        }
    }
}
