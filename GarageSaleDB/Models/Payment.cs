using System;
using System.Collections.Generic;

namespace GarageSaleDB.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public string Type { get; set; } = null!;

    public int GarageSaleId { get; set; }

    public virtual GarageSale GarageSale { get; set; } = null!;
}
