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
                    PlaneID = sightingDTO.PlaneID,
                    Planemake = sightingDTO.Planemake,
                    Planemodel = sightingDTO.Planemodel,
                    Planeregistration = sightingDTO.Planeregistration,
                    Location = sightingDTO.Location,
                    DateTime = sightingDTO.DateTime,
                    Photo = sightingDTO.Photo,
                };

                context.sightings.Update(sightingDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
