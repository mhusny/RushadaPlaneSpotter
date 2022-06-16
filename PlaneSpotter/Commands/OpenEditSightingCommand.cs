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
    public class OpenEditSightingCommand : CommandBase
    {
        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly PlaneSpotterListingViewModel _planeSpotterListingViewModel;
        private readonly SightingStore _sightingStore;

        public OpenEditSightingCommand(PlaneSpotterListingViewModel planeSpotterListingViewModel, SightingStore sightinsStore, ModelNavigationStore modelNavigationStore)
        {
            _modelNavigationStore = modelNavigationStore;
            _planeSpotterListingViewModel = planeSpotterListingViewModel;
            _sightingStore = sightinsStore;
        }

        public override void Execute(object parameter)
        {
            Sighting sighting = _planeSpotterListingViewModel.Sighting;

            EditViewModel addViewModel = new EditViewModel(sighting, _sightingStore, _modelNavigationStore);
            _modelNavigationStore.CurrentViewModel = addViewModel;
        }
    }
}
