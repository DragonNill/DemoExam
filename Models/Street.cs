using System;
using System.Collections.Generic;

namespace ООО__Ткани_.Models;

public partial class Street
{
    public int StreetId { get; set; }

    public string StreetName { get; set; } = null!;

    public virtual ICollection<Pickuppoint> Pickuppoints { get; } = new List<Pickuppoint>();
}
