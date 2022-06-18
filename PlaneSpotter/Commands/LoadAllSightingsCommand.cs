using PlaneSpotter.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.Commands
{
    public class LoadAllSightingsCommand : AsyncCommandBase
    {
        private readonly SightingStore _sightingStore;

        public LoadAllSightingsCommand(SightingStore sightingStore)
        {
            _sightingStore = sightingStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _sightingStore.GetAllSightings();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
