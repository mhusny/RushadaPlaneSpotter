using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.EntityFramework
{
    public class SightingDesighTimeDbContextFactory : IDesignTimeDbContextFactory<PlaneSpotterDBContext>
    {

        public PlaneSpotterDBContext CreateDbContext(string[] args = null)
        {
            return new PlaneSpotterDBContext(new DbContextOptionsBuilder().UseSqlServer("Data Source=HP-LAP;Initial Catalog=RushadaPlaneSpotter;User ID=sa;Password=Vx@7190").Options);
        }
    }
}
