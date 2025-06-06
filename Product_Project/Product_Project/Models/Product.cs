using System;
using System.Collections.Generic;

namespace Product_Project.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Category { get; set; }

    public DateOnly? Orderdate { get; set; }

    public DateOnly? Receiveddate { get; set; }
}
