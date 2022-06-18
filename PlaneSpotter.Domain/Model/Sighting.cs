using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.Domain.Model
{
    public class Sighting
    {

        public Guid Id { get;  }
        public string Planemake { get; }
        public string Planemodel { get; }
        public string Planeregistration { get;}
        public string Location { get;  }
        public DateTime DateTime { get;  }
        public string Photo { get;  }


        public Sighting(Guid planeid, string planemake, string planemodel, string planeregistration, string location, DateTime dateTime, string photo)
        {
            Id = planeid;
            Planemake = planemake;
            Planemodel = planemodel;
            Planeregistration = planeregistration;
            Location = location;
            DateTime = dateTime;
            Photo = photo;
        }
    }
}
