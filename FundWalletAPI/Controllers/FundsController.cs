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




        //// PUT api/funds/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Fund fund)
        {

            _context.Update(fund);
        }

        //// DELETE api/funds/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            var fund = await _context.Funds.FindAsync(id);
           _context.Remove(fund);
        }


        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<Fund>>> GetAllByName(string name)
        {
            return _context.Funds.FromSql($"SELECT * FROM funds where name LIKE {name}").ToList();
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Fund>>> GetCountOfFundByName()
        //{
        //    return await _context.Funds.ToListAsync();
        //}
    }
}