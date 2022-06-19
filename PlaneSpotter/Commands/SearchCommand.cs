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
        private readonly string _searchBy;
        private readonly string _searchPara;

        public SearchCommand(SightingStore sightingStore, string searchBy, string searchPara)
        {
            _sightingStore = sightingStore;
            _searchBy = searchBy;
            _searchPara = searchPara;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _sightingStore.GetSightingsByPara(_searchBy, _searchPara);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
