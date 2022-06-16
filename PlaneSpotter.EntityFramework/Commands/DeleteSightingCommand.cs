using PlaneSpotter.Domain.Commands;
using PlaneSpotter.EntityFramework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.EntityFramework.Commands
{
    public class DeleteSightingCommand : iDeleteSightingCommand
    {
        private readonly SightingDbContextFactory _contextFactory;

        public DeleteSightingCommand(SightingDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Guid id)
        {
            using (PlaneSpotterDBContext context = _contextFactory.Create())
            {
                SightingDTO sightingDTO = new SightingDTO()
                {
                    PlaneID = id,
                };

                context.sightings.Remove(sightingDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
