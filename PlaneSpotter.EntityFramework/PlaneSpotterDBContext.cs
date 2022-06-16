using Microsoft.EntityFrameworkCore;
using PlaneSpotter.EntityFramework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.EntityFramework
{
    public class PlaneSpotterDBContext : DbContext
    {
        public PlaneSpotterDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SightingDTO> sightings { get; set; }
    }
}
