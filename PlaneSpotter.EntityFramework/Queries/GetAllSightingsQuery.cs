using Microsoft.EntityFrameworkCore;
using PlaneSpotter.Domain.Model;
using PlaneSpotter.Domain.Queries;
using PlaneSpotter.EntityFramework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.EntityFramework.Queries
{
    public class GetAllSightingsQuery : iGetAllSightingsQuery
    {
        private readonly SightingDbContextFactory _contextFactory;

        public GetAllSightingsQuery(SightingDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Sighting>> Execute()
        {
            using(PlaneSpotterDBContext context = _contextFactory.Create())
            {
                IEnumerable<SightingDTO> sightingDTO = await context.sightings.ToListAsync();

                return sightingDTO.Select(x => new Sighting(x.Id, x.Planemake, x.Planemodel, x.Planeregistration, x.Location, x.DateTime ,x.Photo));
            }
        }
    }
}
