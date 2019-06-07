using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundsWallet_API.Data;
using FundWalletAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FundWalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundsController : ControllerBase
    {
        private readonly DataContext _context;

        public FundsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fund>>> GetFunds()
        {
            return await _context.Funds.ToListAsync();
        }

        // GET: api/Funds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fund>> GetFund(int id)
        {
            var fund = await _context.Funds.FindAsync(id);

            if (fund == null)
            {
                return NotFound();
            }

            return fund;
        }

        // POST: api/Funds
        [HttpPost]
        public async Task<ActionResult<Fund>> PostFund(Fund fund)
        {
            _context.Funds.Add(fund);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFund", new { id = fund.FundId }, fund);
        }




        // PUT: api/Funds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStock(int id, Fund fund)
        {
            if (id != fund.FundId)
            {
                return BadRequest();
            }

            _context.Entry(fund).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundsExists(id))
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

        // DELETE: api/Funds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fund>> DeleteStock(int id)
        {
            var stock = await _context.Funds.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            _context.Funds.Remove(stock);
            await _context.SaveChangesAsync();

            return stock;
        }



        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<Fund>>> GetAllByName(string name)
        {
            return _context.Funds.FromSql($"SELECT * FROM funds where name LIKE {name}").ToList();
        }

        private bool FundsExists(int id)
        {
            return _context.Funds.Any(e => e.FundId == id);
        }


        [HttpGet("total/{name}")]
        public async Task<Double> GetTotalInvestedByNameAsync(string name)
        {
            //return await _context.Funds.ToListAsync();
            var listOfFunds = _context.Funds.FromSql($"SELECT * FROM funds where name LIKE {name}").ToList();
            var count = 0.0;

            foreach (Fund item in listOfFunds)
            {
                count += item.Quantity * item.UnitPrice;
            }

            return count;
        }
    }
}