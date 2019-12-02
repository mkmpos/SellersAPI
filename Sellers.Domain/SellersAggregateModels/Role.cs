namespace Sellers.Domain.SellersAggregateModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Role
    {
        public int RoleID { get; set; }

        public string RoleTitle { get; set; }

        public int CommissionID { get; set; }

        public Commission Commission { get; set; }

    }
}
