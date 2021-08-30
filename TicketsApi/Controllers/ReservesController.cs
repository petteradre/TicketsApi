using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketsApi.DBContext;
using TicketsApi.Models;

namespace TicketsApi.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class ReservesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ReservesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Reserves
        [HttpGet("GetAllReserves")]
        public async Task<ActionResult<IEnumerable<Reserve>>> GetReserves()
        {
            return await _context.Reserves.ToListAsync();
        }

        // POST: api/Reserves
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("CreateReserve")]
        public async Task<ActionResult<Reserve>> PostReserve(Reserve reserve)
        {
            var Response = "";
            var validateTicket = _context.Tickets.Where(tck => tck.Active == true && tck.DateExpiration < reserve.FinishDate).ToList();
            if(validateTicket != null)
            {
                Response = "Reserve Succesfuly";
                _context.Reserves.Add(reserve);
                await _context.SaveChangesAsync();
            }
            else
            {
                Response = "Not have tickets Aviable";
            }
            return CreatedAtAction(Response, new { id = reserve.ReserveId }, reserve);
        }

        // DELETE: api/Reserves/5
        [HttpDelete("DeleteReserve{id}")]
        public async Task<ActionResult<Reserve>> DeleteReserve(int id)
        {
            var reserve = await _context.Reserves.FindAsync(id);
            if (reserve == null)
            {
                return NotFound();
            }

            _context.Reserves.Remove(reserve);
            await _context.SaveChangesAsync();

            return reserve;
        }

        private bool ReserveExists(int id)
        {
            return _context.Reserves.Any(e => e.ReserveId == id);
        }
    }
}
