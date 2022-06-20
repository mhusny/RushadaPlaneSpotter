using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PlaneSpotter.Domain.CustomAttributes;

namespace PlaneSpotter.Domain.Model
{
    public class Sighting
    {

        public Guid Id { get;  }

        [MaxLength(128)]
        public string Planemake { get; }

        [MaxLength(128)]
        public string Planemodel { get; }

        [PlaneRgistration("xx-xxxx", ErrorMessage = "{0} value does not match the mask {1}.")]
        public string Planeregistration { get;}

        [MaxLength(255)]
        public string Location { get;  }

        
        [MaximumDate]
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
