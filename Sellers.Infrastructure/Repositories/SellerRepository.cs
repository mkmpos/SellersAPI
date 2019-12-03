using Microsoft.EntityFrameworkCore;
using Sellers.API.Models;
using Sellers.Domain;
using Sellers.Domain.SellersAggregateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sellers.Infrastructure
{
    public class SellerRepository : ISellerRepository
    {
        private readonly SellersContext _context;

        public SellerRepository(SellersContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Seller>> GetSellers()
        {
            return await _context.Sellers.ToListAsync();
        }

        public async Task<Seller> GetSeller(int sellerid)
        {
            return await _context.Sellers.AsNoTracking().SingleOrDefaultAsync(s => s.SellerID == sellerid);
        }

        public async Task UpdateSeller(Seller seller)
        {
            _context.Sellers.Update(seller);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task CreateSeller(Seller seller)
        {
            _context.Sellers.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveSeller(Seller seller)
        {
            _context.Sellers.Remove(seller);
            await _context.SaveChangesAsync();
        }

        public bool SellerExist(int sellerid)
        {
            return _context.Sellers.Any(e => e.SellerID == sellerid);
        }


    }
}
