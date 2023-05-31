using System;
using System.Collections.Generic;

namespace GarageSaleDB.Models;

public partial class GarageSale
{
    public int GarageSaleId { get; set; }

    public string Name { get; set; } = null!;

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public string Description { get; set; } = null!;

    public int? TypeId { get; set; }

    public int? ApproxNumOfItems { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
