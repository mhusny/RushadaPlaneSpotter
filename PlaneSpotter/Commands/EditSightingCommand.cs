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
    public class EditSightingCommand : AsyncCommandBase
    {
        private readonly SightingStore _sightingStore;
        private readonly EditViewModel _editViewModel;
        private readonly ModelNavigationStore _modelNavigationStore;

        public EditSightingCommand(EditViewModel editViewModel, SightingStore sightinsStore, ModelNavigationStore modelNavigationStore)
        {
            _sightingStore = sightinsStore;
            _editViewModel = editViewModel;
            _modelNavigationStore = modelNavigationStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            AddEditComponantViewModel formViewModel = _editViewModel.AddEditComponantViewModel;

            Sighting sighting = new Sighting(_editViewModel.PlaneID, formViewModel.PlaneMake, formViewModel.PlaneModel, formViewModel.PlaneRegistration, formViewModel.Location, formViewModel.DatenTime, formViewModel.Photo);

            try
            {
                await _sightingStore.edit(sighting);
                _modelNavigationStore.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
