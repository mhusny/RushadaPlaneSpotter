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
    public class AddViewModel :ViewModelBase
    {
        public AddEditComponantViewModel AddEditComponantViewModel { get; set; }
        public AddViewModel(SightingStore sightingStore, ModelNavigationStore modelNavigationStore)
        {
            ICommand Cancell = new CloseCommand(modelNavigationStore);
            ICommand Submit = new SubmitSightingCommand(this, sightingStore, modelNavigationStore);
            AddEditComponantViewModel = new AddEditComponantViewModel(Submit, Cancell);
        }


    }
}
