using PlaneSpotter.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.Stores
{
    public class SelectedSightingStore
    {
        private Sighting _sighting;

        private readonly SightingStore _sightingStore;
        public Sighting SelectedSighting
        {
            get { return _sighting; }
            set 
            { 
                _sighting = value;
                SelectedSightingChanged?.Invoke();
            }
        }

        public event Action SelectedSightingChanged;

        public SelectedSightingStore(SightingStore sightingStore)
        {
            _sightingStore = sightingStore;

            _sightingStore.EditSighting += _sightingStore_EditSighting;
        }

        private void _sightingStore_EditSighting(Sighting sighting)
        {
            if(sighting.PlaneID == SelectedSighting?.PlaneID)
            {
                SelectedSighting = sighting;
            }
        }
    }
}
