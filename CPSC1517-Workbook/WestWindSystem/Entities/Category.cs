using System;
using System.Collections.Generic;

namespace WestWindSystem.Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    public string? PictureMimeType { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
