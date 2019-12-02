
namespace Sellers.Domain.SellersAggregateModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Seller
    {
        public int SellerID { get; set; }
        public string NIT { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public int RoleID { get; set; }

        public Role Role { get; set; }

        public bool Active { get; set; }

        public double Commision { get; set; }
    }
}
