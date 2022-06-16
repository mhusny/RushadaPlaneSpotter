using PlaneSpotter.Stores;
using PlaneSpotter.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PlaneSpotter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public readonly ModelNavigationStore _modelNavigationStore;
        public readonly SelectedSightingStore _selectedSightingStore;
        public readonly SightingStore _sightingStore;
        public App()
        {
            _modelNavigationStore = new ModelNavigationStore();
            _sightingStore = new SightingStore();
            _selectedSightingStore = new SelectedSightingStore(_sightingStore);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            PlaneSpotterViewModel planeSpotterViewModel = new PlaneSpotterViewModel(_sightingStore, _selectedSightingStore, _modelNavigationStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modelNavigationStore, planeSpotterViewModel)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
