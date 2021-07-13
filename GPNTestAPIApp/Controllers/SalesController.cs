using GPNTestWeb.Data;
using GPNTestWeb.Model.Entity;
using GPNTestWeb.Model.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPNTestAPIApp.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SalesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Report
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleItem>>> GetSaleItems()
        {
            return await _context.SaleItems.ToListAsync();
        }

		[HttpGet("quarters")]
		public IEnumerable<KeyValuePair<string, int>> GetQuarterItems()
		{

			return GPNTestWeb.Model.Enums.EnumExtensions.GetValues<Quarter>().ToList();
		}

		// GET: api/Report/5
		[HttpGet("{id}")]
        public async Task<ActionResult<SaleItem>> GetSaleItem(long id)
        {
            var saleItem = await _context.SaleItems.FindAsync(id);

            if (saleItem == null)
            {
                return NotFound();
            }

            return saleItem;
        }

        // PUT: api/Report/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaleItem(long id, SaleItem saleItem)
        {
            if (id != saleItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(saleItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleItemExists(id))
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

        // POST: api/Report
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SaleItem>> PostSaleItem(SaleItem saleItem)
        {

            _context.SaleItems.Add(saleItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSaleItem), new { id = saleItem.Id }, saleItem);
        }

        // DELETE: api/Report/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaleItem(long id)
        {
            var saleItem = await _context.SaleItems.FindAsync(id);
            if (saleItem == null)
            {
                return NotFound();
            }

            _context.SaleItems.Remove(saleItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaleItemExists(long id)
        {
            return _context.SaleItems.Any(e => e.Id == id);
        }
    }
}
