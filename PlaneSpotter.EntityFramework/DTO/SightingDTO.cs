using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.EntityFramework.DTO
{
    public class SightingDTO
    {
        public Guid PlaneID { get; set; }
        public string Planemake { get; set; }
        public string Planemodel { get; set; }
        public string Planeregistration { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public string Photo { get; set; }

    }
}
