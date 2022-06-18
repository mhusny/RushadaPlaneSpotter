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
            _sightingStore.DeleteSighting += _sightingStore_DeleteSighting;
        }

        private void _sightingStore_DeleteSighting(Guid id)
        {
            if (id == SelectedSighting?.Id)
            {
                SelectedSighting = null;
            }
        }

        private void _sightingStore_EditSighting(Sighting sighting)
        {
            if(sighting.Id == SelectedSighting?.Id)
            {
                SelectedSighting = sighting;
            }
        }

       

    }
}
