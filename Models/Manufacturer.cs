﻿using System;
using System.Collections.Generic;

namespace ООО__Ткани_.Models;

public partial class Manufacturer
{
    public int ManufacturerId { get; set; }

    public string ManufacturerName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
