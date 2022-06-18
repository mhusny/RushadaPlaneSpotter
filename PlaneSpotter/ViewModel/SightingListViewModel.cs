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

        public ICommand GetAllSightingsCommand { get; }

        public SightingListViewModel(SightingStore sightingStore, SelectedSightingStore selectedSightingStore, ModelNavigationStore modelNavigationStore)
        {
            _sightingStore = sightingStore;
            _selectedSightingStore = selectedSightingStore;
            _modelNavigationStore = modelNavigationStore;
            _listings  = new ObservableCollection<PlaneSpotterListingViewModel>();


            GetAllSightingsCommand = new LoadAllSightingsCommand(sightingStore);
            //GetAllSightingsCommand.Execute(null);

            _sightingStore.SightingsLoaded += _sightingStore_GetAllSighting;
            _sightingStore.AddSighting += sightingStore_AddSighting;
            _sightingStore.EditSighting += sightingStore_EditSighting;
            _sightingStore.DeleteSighting += sightingStore_DeleteSighting;
        }

        private void sightingStore_DeleteSighting(Guid id)
        {
            PlaneSpotterListingViewModel listingViewModel =  _listings.FirstOrDefault(x => x.Sighting.Id == id);
            if (listingViewModel != null)
            {
                _listings.Remove(listingViewModel);
            }
        }

        private void _sightingStore_GetAllSighting()
        {
            _listings.Clear();

            foreach (Sighting sighting in _sightingStore.Sightings)
            {
                AddSighting(sighting);
            }
        }

        //facory method to exetute getall command
        //public static SightingListViewModel LoadViewModel(SightingStore sightingStore, SelectedSightingStore selectedSightingStore, ModelNavigationStore modelNavigationStore)
        //{

        //}
        internal class LoadViewModel : SightingListViewModel
        {
            public LoadViewModel(SightingStore sightingStore, SelectedSightingStore selectedSightingStore, ModelNavigationStore modelNavigationStore) : base(sightingStore, selectedSightingStore, modelNavigationStore)
            {
                SightingListViewModel viewModel = new SightingListViewModel(sightingStore, selectedSightingStore, modelNavigationStore);

                viewModel.GetAllSightingsCommand.Execute(null);

                //return viewModel;
            }
        }


        private void sightingStore_EditSighting(Sighting sighting)
        {
            PlaneSpotterListingViewModel planeSpotterListing = _listings.FirstOrDefault(x => x.Sighting.Id == sighting.Id);
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
