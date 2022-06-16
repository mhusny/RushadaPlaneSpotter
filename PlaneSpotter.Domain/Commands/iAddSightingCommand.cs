﻿using PlaneSpotter.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.Domain.Commands
{
    public interface iAddSightingCommand
    {
        Task Execute(Sighting sighting);
    }
}
