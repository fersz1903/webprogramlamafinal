using System;
using System.Collections.Generic;

namespace moonCafeWebApp.Models;

public partial class CmCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ImagePath { get; set; }
}
