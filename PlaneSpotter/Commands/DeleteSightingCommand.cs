using PlaneSpotter.Domain.Model;
using PlaneSpotter.Stores;
using PlaneSpotter.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.Commands
{
    public class DeleteSightingCommand : AsyncCommandBase
    {
        private readonly PlaneSpotterListingViewModel _planeSpotterListingViewModel;
        private readonly SightingStore _sightingStore;


        public DeleteSightingCommand(PlaneSpotterListingViewModel planeSpotterListingViewModel, SightingStore sightinsStore)
        {
            _planeSpotterListingViewModel = planeSpotterListingViewModel;
            _sightingStore = sightinsStore;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            Sighting sighting = _planeSpotterListingViewModel.Sighting;

            try
            {
                await _sightingStore.Delete(sighting.Id);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
