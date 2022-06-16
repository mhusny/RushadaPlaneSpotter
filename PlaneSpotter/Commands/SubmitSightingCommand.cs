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
    public class SubmitSightingCommand : AsyncCommandBase
    {
        private readonly AddViewModel _addViewModel;
        private readonly SightingStore _sightingStore;
        private readonly ModelNavigationStore _modelNavigationStore;

        public SubmitSightingCommand(AddViewModel addViewModel, SightingStore sightingStore, ModelNavigationStore modelNavigationStore)
        {
            _addViewModel = addViewModel;
            _sightingStore = sightingStore;
            _modelNavigationStore = modelNavigationStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            AddEditComponantViewModel formViewModel = _addViewModel.AddEditComponantViewModel;

            Sighting sighting = new Sighting(Guid.NewGuid(), formViewModel.PlaneMake, formViewModel.PlaneModel, formViewModel.PlaneRegistration, formViewModel.Location, formViewModel.DateTime, formViewModel.Photo);

            try
            {
                await _sightingStore.add(sighting);
                _modelNavigationStore.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
