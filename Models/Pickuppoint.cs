using System;
using System.Collections.Generic;

namespace ООО__Ткани_.Models;

public partial class Pickuppoint
{
    public int PickupPointId { get; set; }

    public string PickupPointIndex { get; set; } = null!;

    public int PickupPointCityId { get; set; }

    public int PickupPointStreetId { get; set; }

    public int PickupPointHome { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual City PickupPointCity { get; set; } = null!;

    public virtual Street PickupPointStreet { get; set; } = null!;
}
