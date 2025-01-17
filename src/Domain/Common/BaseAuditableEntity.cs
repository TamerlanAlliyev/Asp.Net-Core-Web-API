﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Domain.Common;

public class BaseAuditableEntity
{
    public string CreatedBy { get; set; } = null!;
    public DateTime Created {  get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? Modified { get; set; }
    public string IPAddress { get; set; } = null!;
}
