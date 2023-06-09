using System;
using System.Collections.Generic;

namespace ServicePrj.Models;

public partial class CmUser
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
