using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sellers.API.Models;
using Sellers.Domain;
using Sellers.Domain.SellersAggregateModels;

namespace Sellers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly ISellerRepository _sellerRepository;

        public SellersController(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        // GET: api/Sellers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seller>>> GetSeller()
        {
            var sellerslist = await _sellerRepository.GetSellers();
            return sellerslist.ToList();
        }

        // GET: api/Sellers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seller>> GetSeller(int id)
        {
            var seller = await _sellerRepository.GetSeller(id);

            if (seller == null)
            {
                return NotFound();
            }

            return seller;
        }

        // PUT: api/Sellers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeller(int id, Seller seller)
        {
            if (id != seller.SellerID)
            {
                return BadRequest();
            }

            try
            {
                await _sellerRepository.UpdateSeller(seller);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sellers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Seller>> PostSeller(Seller seller)
        {
            await _sellerRepository.CreateSeller(seller);

            return CreatedAtAction("GetSeller", new { id = seller.SellerID }, seller);
        }

        // DELETE: api/Sellers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Seller>> DeleteSeller(int id)
        {
            var seller = await _sellerRepository.GetSeller(id);
            if (seller == null)
            {
                return NotFound();
            }

            await _sellerRepository.RemoveSeller(seller);

            return seller;
        }

        private bool SellerExists(int id)
        {
            return _sellerRepository.SellerExist(id);
        }
    }
}
