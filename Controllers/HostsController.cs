using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Concerts.Models;

namespace Concerts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostsController : ControllerBase
    {
        private readonly ConcertsContext _context;

        public HostsController(ConcertsContext context)
        {
            _context = context;
        }

        // GET: api/Hosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Host>>> GetHosts()
        {
            return await _context.Hosts.ToListAsync();
        }

        // GET: api/Hosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Host>> GetHost(int id)
        {
            var host = await _context.Hosts.FindAsync(id);

            if (host == null)
            {
                return NotFound();
            }

            return host;
        }

        // PUT: api/Hosts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHost(int id, Host host)
        {
            if (id != host.Id)
            {
                return BadRequest();
            }

            _context.Entry(host).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HostExists(id))
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

        // POST: api/Hosts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Host>> PostHost(Host host)
        {
            _context.Hosts.Add(host);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHost", new { id = host.Id }, host);
        }

        // DELETE: api/Hosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Host>> DeleteHost(int id)
        {
            var host = await _context.Hosts.FindAsync(id);
            if (host == null)
            {
                return NotFound();
            }

            _context.Hosts.Remove(host);
            await _context.SaveChangesAsync();

            return host;
        }

        private bool HostExists(int id)
        {
            return _context.Hosts.Any(e => e.Id == id);
        }
    }
}
