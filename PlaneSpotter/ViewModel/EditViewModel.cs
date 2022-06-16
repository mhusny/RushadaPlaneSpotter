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
    public class EditViewModel :ViewModelBase
    {
        public Guid PlaneID { get; }
        public AddEditComponantViewModel AddEditComponantViewModel { get; set; }
        public EditViewModel(Sighting sighting, SightingStore sightinsStore, ModelNavigationStore modelNavigationStore)
        {
            PlaneID = sighting.PlaneID;

            ICommand Edit = new EditSightingCommand(this, sightinsStore, modelNavigationStore);
            ICommand Cancell = new CloseCommand(modelNavigationStore);
            AddEditComponantViewModel = new AddEditComponantViewModel(Edit, Cancell)
            {
                PlaneMake = sighting.Planemake,
                PlaneModel = sighting.Planemodel,
                PlaneRegistration = sighting.Planeregistration,
                Location = sighting.Location,
                DateTime = sighting.DateTime,
                Photo = sighting.Photo
            };
        }
    }
}
