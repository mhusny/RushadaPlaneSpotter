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
    public class GetSightingByParaQuery : iGetSightingByParaQuery
    {
        public readonly SightingDbContextFactory _contextFactory;
        public readonly string _searchBy;
        public readonly string _searchPara;

        public GetSightingByParaQuery(SightingDbContextFactory contextFactory, string SearchBy, string SearchPara)
        {
            _contextFactory = contextFactory;
            _searchBy = SearchBy;
            _searchPara = SearchPara;
        }

        public async Task<IEnumerable<Sighting>> Execute(string SearchBy, string SearchPara)
        {
            using (PlaneSpotterDBContext context = _contextFactory.Create())
            {
                IEnumerable<SightingDTO> sightingDTO = await context.sightings.ToListAsync();

                return sightingDTO.Where(x => x.Planemake == SearchPara).Select(x => new Sighting(x.Id, x.Planemake, x.Planemodel, x.Planeregistration, x.Location, x.DateTime, x.Photo));
            }
        }
    }
}
