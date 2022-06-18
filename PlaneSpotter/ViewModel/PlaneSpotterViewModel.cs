using PlaneSpotter.Commands;
using PlaneSpotter.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlaneSpotter.ViewModel
{
    public class PlaneSpotterViewModel : ViewModelBase
    {
        public SightingListViewModel SightingListViewModel { get; }
        public SightingDetailViewModel SightingDetailViewModel { get; }
        public ICommand AddNewSighting { get; }

        public PlaneSpotterViewModel(SightingStore sightingStore, SelectedSightingStore selectedSightingStore, ModelNavigationStore modelNavigationStore)
        {
            SightingListViewModel = new SightingListViewModel.LoadViewModel(sightingStore, selectedSightingStore, modelNavigationStore);
            SightingDetailViewModel = new SightingDetailViewModel(selectedSightingStore);

            AddNewSighting = new OpenAddSightingCommand(sightingStore, modelNavigationStore);
        }
    }
}
