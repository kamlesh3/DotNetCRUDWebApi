using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoProject.Model;
using WebApiCoreNew.Model;

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblDesignationsController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public TblDesignationsController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/TblDesignations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblDesignation>>> GettblDesignation()
        {
            return await _context.tblDesignation.ToListAsync();
        }

        // GET: api/TblDesignations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblDesignation>> GetTblDesignation(int id)
        {
            var tblDesignation = await _context.tblDesignation.FindAsync(id);

            if (tblDesignation == null)
            {
                return NotFound();
            }

            return tblDesignation;
        }

        // PUT: api/TblDesignations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblDesignation(int id, TblDesignation tblDesignation)
        {
            if (id != tblDesignation.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblDesignation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblDesignationExists(id))
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

        // POST: api/TblDesignations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblDesignation>> PostTblDesignation(TblDesignation tblDesignation)
        {
            _context.tblDesignation.Add(tblDesignation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblDesignation", new { id = tblDesignation.Id }, tblDesignation);
        }

        // DELETE: api/TblDesignations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblDesignation(int id)
        {
            var tblDesignation = await _context.tblDesignation.FindAsync(id);
            if (tblDesignation == null)
            {
                return NotFound();
            }

            _context.tblDesignation.Remove(tblDesignation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblDesignationExists(int id)
        {
            return _context.tblDesignation.Any(e => e.Id == id);
        }
    }
}
