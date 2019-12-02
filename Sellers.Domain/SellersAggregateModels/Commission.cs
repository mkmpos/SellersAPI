

namespace Sellers.Domain.SellersAggregateModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Commission
    {
        public int CommissionID { get; set; }
        public string Type { get; set; }

        public double Value { get; set; }
    }
}
