using PlaneSpotter.Commands;
using PlaneSpotter.Domain.Model;
using PlaneSpotter.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlaneSpotter.ViewModel
{
    public class PlaneSpotterListingViewModel : ViewModelBase
    {
        private SightingStore sightinsStore;
        private ModelNavigationStore modelNavigationStore;

        public Sighting Sighting { get; set; }

        public string Planemake => Sighting.Planemake;
        public string Planemodel => Sighting.Planemodel;
        public string Planeregistration => Sighting.Planeregistration;

        public ICommand Edit { get; }
        public ICommand Delete { get; }


        public PlaneSpotterListingViewModel(Sighting sighting, SightingStore sightinsStore, ModelNavigationStore modelNavigationStore)
        {
            Sighting = sighting;

            Edit = new OpenEditSightingCommand(this, sightinsStore, modelNavigationStore);
            Delete = new DeleteSightingCommand(this, sightinsStore);
        }

        public void Update(Sighting sighting)
        {
            Sighting = sighting;
            OnPropertyChanged(nameof(Planemake));
            OnPropertyChanged(nameof(Planemodel));
            OnPropertyChanged(nameof(Planeregistration));
        }
    }
}
