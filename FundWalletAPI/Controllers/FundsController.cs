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

        //TODO: Ask the client the necessity of.
        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
    }
}