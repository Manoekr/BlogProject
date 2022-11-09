﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class About : IEntity
    {
        public int AboutId { get; set; }
        public string AboutText { get; set; }
    }
}
