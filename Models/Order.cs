using System;
using System.Collections.Generic;

namespace ООО__Ткани_.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int OrderStatusId { get; set; }

    public int PickupPointCode { get; set; }

    public int? OrderUser { get; set; }

    public DateTime OrderDeliveryDate { get; set; }

    public DateTime OrderDate { get; set; }

    public int OrderPickupPointId { get; set; }

    public virtual Pickuppoint OrderPickupPoint { get; set; } = null!;

    public virtual ICollection<Orderproduct> Orderproducts { get; } = new List<Orderproduct>();
}
