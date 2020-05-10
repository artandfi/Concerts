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
    public class SongArtistConcertsController : ControllerBase
    {
        private readonly ConcertsContext _context;

        public SongArtistConcertsController(ConcertsContext context)
        {
            _context = context;
        }

        // GET: api/SongArtistConcerts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongArtistConcert>>> GetSongsArtistsConcerts()
        {
            return await _context.SongsArtistsConcerts.ToListAsync();
        }

        // GET: api/SongArtistConcerts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongArtistConcert>> GetSongArtistConcert(int id)
        {
            var songArtistConcert = await _context.SongsArtistsConcerts.FindAsync(id);

            if (songArtistConcert == null)
            {
                return NotFound();
            }

            return songArtistConcert;
        }

        // PUT: api/SongArtistConcerts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongArtistConcert(int id, SongArtistConcert songArtistConcert)
        {
            if (id != songArtistConcert.Id)
            {
                return BadRequest();
            }

            _context.Entry(songArtistConcert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongArtistConcertExists(id))
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

        // POST: api/SongArtistConcerts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SongArtistConcert>> PostSongArtistConcert(SongArtistConcert songArtistConcert)
        {
            _context.SongsArtistsConcerts.Add(songArtistConcert);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongArtistConcert", new { id = songArtistConcert.Id }, songArtistConcert);
        }

        // DELETE: api/SongArtistConcerts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SongArtistConcert>> DeleteSongArtistConcert(int id)
        {
            var songArtistConcert = await _context.SongsArtistsConcerts.FindAsync(id);
            if (songArtistConcert == null)
            {
                return NotFound();
            }

            _context.SongsArtistsConcerts.Remove(songArtistConcert);
            await _context.SaveChangesAsync();

            return songArtistConcert;
        }

        private bool SongArtistConcertExists(int id)
        {
            return _context.SongsArtistsConcerts.Any(e => e.Id == id);
        }
    }
}
