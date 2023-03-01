using System;
using System.Collections.Generic;

namespace ООО__Ткани_.Models;

public partial class Orderproduct
{
    public int OrderProductId { get; set; }

    public int OrderId { get; set; }

    public string ProductArticleNumber { get; set; } = null!;

    public int ProductCount { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product ProductArticleNumberNavigation { get; set; } = null!;
}
