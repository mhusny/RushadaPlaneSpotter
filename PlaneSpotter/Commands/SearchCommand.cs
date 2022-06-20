using PlaneSpotter.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.Commands
{
    public class SearchCommand : AsyncCommandBase
    {
        private readonly SightingStore _sightingStore;

        public SearchCommand(SightingStore sightingStore)
        {
            _sightingStore = sightingStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _sightingStore.GetSightingsByPara();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
