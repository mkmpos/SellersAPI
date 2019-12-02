using Sellers.Domain.SellersAggregateModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sellers.Domain
{
    public interface ISellerRepository
    {
        //Task<Seller> Add(Seller seller);

        //Task<Seller> Update(Seller seller);

        //Task<Seller> Delete(int sellerid);

        Task<Seller> GetSeller(int sellerid);

        Task<IEnumerable<Seller>> GetSellers();

        Task UpdateSeller(Seller seller);

        Task CreateSeller(Seller seller);

        Task RemoveSeller(Seller seller);

        bool SellerExist(int sellerid);
    }
}
