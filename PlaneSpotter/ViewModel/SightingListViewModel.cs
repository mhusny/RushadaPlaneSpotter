using PlaneSpotter.Commands;
using PlaneSpotter.Domain.Model;
using PlaneSpotter.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlaneSpotter.ViewModel
{
    public class SightingListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<PlaneSpotterListingViewModel> _listings;
        private readonly SightingStore _sightingStore;
        private readonly SelectedSightingStore _selectedSightingStore;
        private readonly ModelNavigationStore _modelNavigationStore;

        public IEnumerable<PlaneSpotterListingViewModel> Listings => _listings;

        private PlaneSpotterListingViewModel _planeSpotterListingViewModel;
        //private SightingStore _sightingStore;

        public PlaneSpotterListingViewModel SelectedSightingViewModel
        {
            get { return _planeSpotterListingViewModel; }
            set 
            {
                _planeSpotterListingViewModel = value;
                OnPropertyChanged(nameof(PlaneSpotterListingViewModel));

                _selectedSightingStore.SelectedSighting = _planeSpotterListingViewModel?.Sighting;
            }
        }

        public SightingListViewModel(SightingStore sightingStore, SelectedSightingStore selectedSightingStore, ModelNavigationStore modelNavigationStore)
        {
            _sightingStore = sightingStore;
            _selectedSightingStore = selectedSightingStore;
            _modelNavigationStore = modelNavigationStore;
            _listings  = new ObservableCollection<PlaneSpotterListingViewModel>();

            _sightingStore.AddSighting += sightingStore_AddSighting;
            _sightingStore.EditSighting += sightingStore_EditSighting;

            }

        private void sightingStore_EditSighting(Sighting sighting)
        {
            PlaneSpotterListingViewModel planeSpotterListing = _listings.FirstOrDefault(x => x.Sighting.PlaneID == sighting.PlaneID);
            if (planeSpotterListing != null)
            {
                planeSpotterListing.Update(sighting);
            }
        }

        //public override void Dispose()
        //{
        //    _sightingStore.AddSighting -= sightingStore_AddSighting;
        //    base.Dispose();
        //}

        private void sightingStore_AddSighting(Sighting sighting)
        {
            AddSighting(sighting);
        }

        private void AddSighting(Sighting sighting)
        {
            PlaneSpotterListingViewModel itemViewModel = new PlaneSpotterListingViewModel(sighting, _sightingStore, _modelNavigationStore);
            _listings.Add(itemViewModel);
        }
    }
}
