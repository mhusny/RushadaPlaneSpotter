using PlaneSpotter.Domain.Commands;
using PlaneSpotter.Domain.Model;
using PlaneSpotter.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.Stores
{
    public class SightingStore
    {
        private readonly iGetAllSightingsQuery _iGetAllSightingsQuery;
        private readonly iAddSightingCommand _iAddSightingCommand;
        private readonly iEditSightingCommand _iEditSightingCommand;
        private readonly iDeleteSightingCommand _iDeleteSightingCommand;

        public SightingStore(iGetAllSightingsQuery iGetAllSightingsQuery, iAddSightingCommand iAddSightingCommand, iEditSightingCommand iEditSightingCommand, iDeleteSightingCommand iDeleteSightingCommand)
        {
            _iGetAllSightingsQuery = iGetAllSightingsQuery;
            _iAddSightingCommand = iAddSightingCommand;
            _iEditSightingCommand = iEditSightingCommand;
            _iDeleteSightingCommand = iDeleteSightingCommand;
        }

        public event Action<Sighting> AddSighting;
        public event Action<Sighting> EditSighting;

        public async Task add(Sighting sighting) 
        {
            await _iAddSightingCommand.Execute(sighting);
            AddSighting?.Invoke(sighting);
        }

        public async Task edit(Sighting sighting)
        {
            await _iEditSightingCommand.Execute(sighting);
            EditSighting?.Invoke(sighting);
        }
    }
}
