using Sellers.API.Models;
using Sellers.Domain.SellersAggregateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sellers.Infrastructure.Data
{
    public class DBSeed
    {
        public static void Initialize(SellersContext context)
        {
            context.Database.EnsureCreated();

            // Look for commisions.
            if (context.Commissions.Any())
            {
                return;   // DB has been seeded
            }

            var commissions = new Commission[]
            {
                new Commission{CommissionID=1, Type="Junior", Value=10},
                new Commission{CommissionID=2, Type="Mid", Value=15},
                new Commission{CommissionID=3, Type="Expert", Value=20}
            };

            foreach(Commission c in commissions)
            {
                context.Commissions.Add(c);
            }

            context.SaveChanges();

            var roles = new Role[]
            {
                new Role{RoleID=1, CommissionID=1, RoleTitle="New Seller"},
                new Role{RoleID=2, CommissionID=1, RoleTitle="Junior Seller"},
                new Role{RoleID=3, CommissionID=2, RoleTitle="Seller"},
                new Role{RoleID=4, CommissionID=2, RoleTitle="Semi Senior Seller"},
                new Role{RoleID=5, CommissionID=3, RoleTitle="Senior Seller"}
            };

            foreach (Role r in roles)
            {
                context.Roles.Add(r);
            }

            context.SaveChanges();

            var sellers = new Seller[]
            {
                new Seller{SellerID=1, Active=true, Address="30 Stret", FullName="Carlos Sosa", NIT="12352", Phone="3214553222", RoleID=1, Commision=23.4},
                new Seller{SellerID=2, Active=true, Address="45 Stret", FullName="Samuel Coba", NIT="13252", Phone="321545622", RoleID=2,Commision=12.3},
                new Seller{SellerID=3, Active=true, Address="21 Stret", FullName="Dario Vargas", NIT="134352", Phone="335743222", RoleID=3, Commision=3.45}
            };

            foreach (Seller s in sellers)
            {
                context.Sellers.Add(s);
            }

            context.SaveChanges();
        }
    }
}
