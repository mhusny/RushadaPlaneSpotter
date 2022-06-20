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
        private readonly iGetSightingByParaQuery _iGetSightingByParaQuery;
        private readonly iAddSightingCommand _iAddSightingCommand;
        private readonly iEditSightingCommand _iEditSightingCommand;
        private readonly iDeleteSightingCommand _iDeleteSightingCommand;
        private readonly List<Sighting> _sightings;

        public IEnumerable<Sighting> Sightings => _sightings;

        public event Action<Sighting> AddSighting;
        public event Action<Sighting> EditSighting;
        public event Action<Guid> DeleteSighting;
        public event Action SightingsLoaded;
        public event Action SightingsLoadedByPara;

        public SightingStore(iGetAllSightingsQuery iGetAllSightingsQuery, iAddSightingCommand iAddSightingCommand, iEditSightingCommand iEditSightingCommand, iDeleteSightingCommand iDeleteSightingCommand, iGetSightingByParaQuery iGetSightingByParaQuery)
        {
            _iGetAllSightingsQuery = iGetAllSightingsQuery;
            _iAddSightingCommand = iAddSightingCommand;
            _iEditSightingCommand = iEditSightingCommand;
            _iDeleteSightingCommand = iDeleteSightingCommand;
            _iGetSightingByParaQuery = iGetSightingByParaQuery;

            _sightings = new List<Sighting>();
        }


        public async Task GetAllSightings()
        {
            IEnumerable<Sighting> sightings = await _iGetAllSightingsQuery.Execute();

            _sightings.Clear();
            _sightings.AddRange(sightings);

            SightingsLoaded?.Invoke();
        }

        public async Task GetSightingsByPara()
        {
            IEnumerable<Sighting> sightings = await _iGetSightingByParaQuery.Execute();

            _sightings.Clear();
            _sightings.AddRange(sightings);

            SightingsLoadedByPara?.Invoke();
        }

        public async Task add(Sighting sighting) 
        {
            await _iAddSightingCommand.Execute(sighting);

            _sightings.Add(sighting);

            AddSighting?.Invoke(sighting);
        }

        public async Task edit(Sighting sighting)
        {
            await _iEditSightingCommand.Execute(sighting);

            int currentIndex = _sightings.FindIndex(x => x.Id == sighting.Id);

            if (currentIndex == -1)
            {
                _sightings[currentIndex] = sighting;
            }
            else
            {
                _sightings.Add(sighting);
            }

            EditSighting?.Invoke(sighting);
        }

        public async Task Delete(Guid id)
        {
            await _iDeleteSightingCommand.Execute(id);

            _sightings.RemoveAll(x => x.Id == id);

            DeleteSighting?.Invoke(id);
        }
    }
}
