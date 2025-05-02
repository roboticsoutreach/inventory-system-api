using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoboticsOutreach.Inventory.Domain.Models;
using RoboticsOutreach.Inventory.Infrastructure;

namespace RoboticsOutreach.Inventory.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BomItemsController : ControllerBase
    {
        private readonly InventoryContext _context;

        public BomItemsController(InventoryContext context)
        {
            _context = context;
        }

        // GET: api/BomItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BomItem>>> GetBomItems()
        {
            return await _context.BomItems.ToListAsync();
        }

        // GET: api/BomItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BomItem>> GetBomItem(Guid id)
        {
            var bomItem = await _context.BomItems.FindAsync(id);

            if (bomItem == null)
            {
                return NotFound();
            }

            return bomItem;
        }

        // PUT: api/BomItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBomItem(Guid id, BomItem bomItem)
        {
            if (id != bomItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(bomItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BomItemExists(id))
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

        // POST: api/BomItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BomItem>> PostBomItem(BomItem bomItem)
        {
            _context.BomItems.Add(bomItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBomItem", new { id = bomItem.Id }, bomItem);
        }

        // DELETE: api/BomItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBomItem(Guid id)
        {
            var bomItem = await _context.BomItems.FindAsync(id);
            if (bomItem == null)
            {
                return NotFound();
            }

            _context.BomItems.Remove(bomItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BomItemExists(Guid id)
        {
            return _context.BomItems.Any(e => e.Id == id);
        }
    }
}
