using PlaneSpotter.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.ViewModel
{
    public class MainViewModel :ViewModelBase
    {
        private readonly ModelNavigationStore _modelNavigationStore;

        public ViewModelBase CurrentModalViewModel => _modelNavigationStore.CurrentViewModel;

        public bool IsShown => _modelNavigationStore.IsShown;
        public PlaneSpotterViewModel PlaneSpotterViewModel { get; }

        public MainViewModel(ModelNavigationStore modelNavigationStore, PlaneSpotterViewModel planeSpotterViewModel)
        {
            _modelNavigationStore = modelNavigationStore;
            PlaneSpotterViewModel = planeSpotterViewModel;

            _modelNavigationStore.CurrentViewModelChanged += ModelNavigationStore_CurrentViewModelChanged;

        }

        private void ModelNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsShown));
        }
    }
}
