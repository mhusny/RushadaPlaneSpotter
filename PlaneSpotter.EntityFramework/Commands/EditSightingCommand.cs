using PlaneSpotter.Domain.Commands;
using PlaneSpotter.Domain.Model;
using PlaneSpotter.EntityFramework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.EntityFramework.Commands
{
    public class EditSightingCommand : iEditSightingCommand
    {
        private readonly SightingDbContextFactory _contextFactory;

        public EditSightingCommand(SightingDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Sighting sighting)
        {
            using (PlaneSpotterDBContext context = _contextFactory.Create())
            {
                SightingDTO sightingDTO = new SightingDTO()
                {
                    PlaneID = sighting.PlaneID,
                    Planemake = sighting.Planemake,
                    Planemodel = sighting.Planemodel,
                    Planeregistration = sighting.Planeregistration,
                    Location = sighting.Location,
                    DateTime = sighting.DateTime,
                    Photo = sighting.Photo,
                };

                context.sightings.Update(sightingDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
