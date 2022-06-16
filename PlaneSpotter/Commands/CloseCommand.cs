using PlaneSpotter.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.Commands
{
    public class CloseCommand : CommandBase
    {
        private readonly ModelNavigationStore _modelNavigationStore;

        public CloseCommand(ModelNavigationStore modelNavigationStore)
        {
            _modelNavigationStore = modelNavigationStore;
        }

        public override void Execute(object parameter)
        {
            _modelNavigationStore.Close();
        }
    }
}
