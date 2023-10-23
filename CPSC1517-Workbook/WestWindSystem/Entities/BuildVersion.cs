using System;
using System.Collections.Generic;

namespace WestWindSystem.Entities;

public partial class BuildVersion
{
    public int Id { get; set; }

    public int Major { get; set; }

    public int Minor { get; set; }

    public int Build { get; set; }

    public DateTime ReleaseDate { get; set; }
}
