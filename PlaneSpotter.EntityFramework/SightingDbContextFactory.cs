using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.EntityFramework
{
    public class SightingDbContextFactory
    {
        private readonly string _dbConnectionString;
        private readonly DbContextOptions _options;

        public SightingDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public PlaneSpotterDBContext Create()
        {
            return new PlaneSpotterDBContext(_options);
        }
    }
}
