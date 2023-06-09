using System;
using System.Collections.Generic;

namespace moonCafeWebApp.Models;

public partial class CmMenu
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? ImagePath { get; set; }
}
