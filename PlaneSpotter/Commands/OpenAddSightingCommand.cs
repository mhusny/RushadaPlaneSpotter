using PlaneSpotter.Stores;
using PlaneSpotter.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlaneSpotter.Commands
{
    public class OpenAddSightingCommand : CommandBase
    {
        private readonly SightingStore _sightingStore;
        private readonly ModelNavigationStore _modelNavigationStore;
       
        public override void Execute(object parameter)
        {
            AddViewModel addViewModel = new AddViewModel(_sightingStore, _modelNavigationStore);
            _modelNavigationStore.CurrentViewModel = addViewModel;
        }
        public OpenAddSightingCommand(SightingStore sightingStore, ModelNavigationStore modelNavigationStore)
        {
            _sightingStore = sightingStore;
            _modelNavigationStore = modelNavigationStore;
        }
    }
}
