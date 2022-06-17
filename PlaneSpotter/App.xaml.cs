using Microsoft.EntityFrameworkCore;
using PlaneSpotter.Domain.Commands;
using PlaneSpotter.Domain.Queries;
using PlaneSpotter.EntityFramework;
using PlaneSpotter.EntityFramework.Commands;
using PlaneSpotter.EntityFramework.Queries;
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

        private readonly SightingDbContextFactory _sightingDbContextFactory;
        private readonly iGetAllSightingsQuery _iGetAllSightingsQuery;
        private readonly iAddSightingCommand _iAddSightingCommand;
        private readonly iEditSightingCommand _iEditSightingCommand;
        private readonly iDeleteSightingCommand _iDeleteSightingCommand;
        public App()
        {
            string _connectionString = "Data Source =RushadaPlaneSpotter.db";

            _modelNavigationStore = new ModelNavigationStore();
            _selectedSightingStore = new SelectedSightingStore(_sightingStore);

            _sightingDbContextFactory = new SightingDbContextFactory(
                new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options
                );
            _iGetAllSightingsQuery = new GetAllSightingsQuery(_sightingDbContextFactory);
            _iAddSightingCommand = new AddSightingCommand(_sightingDbContextFactory);
            _iEditSightingCommand = new EditSightingCommand(_sightingDbContextFactory);
            _iDeleteSightingCommand = new DeleteSightingCommand(_sightingDbContextFactory);

            _sightingStore = new SightingStore(_iGetAllSightingsQuery, _iAddSightingCommand, _iEditSightingCommand, _iDeleteSightingCommand);
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
