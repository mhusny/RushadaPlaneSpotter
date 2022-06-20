using PlaneSpotter.Domain.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.EntityFramework.DTO
{
    public class SightingDTO
    {
        public Guid Id { get; set; }

        [MaxLength(128)]
        public string Planemake { get; set; }

        [MaxLength(128)]
        public string Planemodel { get; set; }

        [PlaneRgistration("99-99999", ErrorMessage = "{0} value does not match the mask {1}.")]
        public string Planeregistration { get; set; }

        [MaxLength(255)]
        public string Location { get; set; }

        [MaximumDate]
        public DateTime DateTime { get; set; }
        public string Photo { get; set; }

    }
}
