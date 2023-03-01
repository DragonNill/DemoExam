using System;
using System.Collections.Generic;

namespace ООО__Ткани_.Models;

public partial class Unit
{
    public int UnitId { get; set; }

    public string UnitName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
