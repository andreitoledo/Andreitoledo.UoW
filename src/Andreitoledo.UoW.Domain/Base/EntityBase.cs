﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreitoledo.UoW.Domain.Base
{
    public class EntityBase
    {
        public EntityBase()
        {
                Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
