using System;
using System.Collections.Generic;

namespace ServicePrj.Models;

public partial class CmOrder
{
    public int Id { get; set; }

    public int TableNo { get; set; }

    public string Name { get; set; } = null!;
}
