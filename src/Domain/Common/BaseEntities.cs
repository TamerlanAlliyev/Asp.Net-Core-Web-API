﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Domain.Common;

public class BaseEntities
{
    public int Id { get; set; } 
    public bool IsDeleted { get; set; }
}
