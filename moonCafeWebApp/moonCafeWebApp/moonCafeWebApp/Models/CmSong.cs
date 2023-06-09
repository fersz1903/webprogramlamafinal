using System;
using System.Collections.Generic;

namespace moonCafeWebApp.Models;

public partial class CmSong
{
    public int Id { get; set; }

    public string SongName { get; set; } = null!;

    public int TableNo { get; set; }
}
