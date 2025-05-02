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
    public class InventoryItemTypesController : ControllerBase
    {
        private readonly InventoryContext _context;

        public InventoryItemTypesController(InventoryContext context)
        {
            _context = context;
        }

        // GET: api/InventoryItemTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryItemType>>> GetInventoryItemTypes()
        {
            return await _context.InventoryItemTypes.ToListAsync();
        }

        // GET: api/InventoryItemTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryItemType>> GetInventoryItemType(Guid id)
        {
            var inventoryItemType = await _context.InventoryItemTypes.FindAsync(id);

            if (inventoryItemType == null)
            {
                return NotFound();
            }

            return inventoryItemType;
        }

        // PUT: api/InventoryItemTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryItemType(Guid id, InventoryItemType inventoryItemType)
        {
            if (id != inventoryItemType.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventoryItemType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryItemTypeExists(id))
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

        // POST: api/InventoryItemTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InventoryItemType>> PostInventoryItemType(InventoryItemType inventoryItemType)
        {
            _context.InventoryItemTypes.Add(inventoryItemType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventoryItemType", new { id = inventoryItemType.Id }, inventoryItemType);
        }

        // DELETE: api/InventoryItemTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryItemType(Guid id)
        {
            var inventoryItemType = await _context.InventoryItemTypes.FindAsync(id);
            if (inventoryItemType == null)
            {
                return NotFound();
            }

            _context.InventoryItemTypes.Remove(inventoryItemType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryItemTypeExists(Guid id)
        {
            return _context.InventoryItemTypes.Any(e => e.Id == id);
        }
    }
}
