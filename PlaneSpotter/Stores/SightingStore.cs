using PlaneSpotter.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.Stores
{
    public class SightingStore
    {
        public event Action<Sighting> AddSighting;
        public event Action<Sighting> EditSighting;

        public async Task add(Sighting sighting) 
        {
            AddSighting?.Invoke(sighting);
        }

        public async Task edit(Sighting sighting)
        {
            EditSighting?.Invoke(sighting);
        }
    }
}
