using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hackernews.Models;

namespace hackernews.Controllers
{
    [Produces("application/json")]
    [Route("api/PostTypes")]
    public class PostTypesController : Controller
    {
        private readonly hackernewsContext _context;

        public PostTypesController(hackernewsContext context)
        {
            _context = context;
        }

        // GET: api/PostTypes
        [HttpGet]
        public IEnumerable<PostType> GetPostType()
        {
            return _context.PostType;
        }

        // GET: api/PostTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postType = await _context.PostType.SingleOrDefaultAsync(m => m.ID == id);

            if (postType == null)
            {
                return NotFound();
            }

            return Ok(postType);
        }

        // PUT: api/PostTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostType([FromRoute] int id, [FromBody] PostType postType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postType.ID)
            {
                return BadRequest();
            }

            _context.Entry(postType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostTypeExists(id))
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

        // POST: api/PostTypes
        [HttpPost]
        public async Task<IActionResult> PostPostType([FromBody] PostType postType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PostType.Add(postType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostType", new { id = postType.ID }, postType);
        }

        // DELETE: api/PostTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var postType = await _context.PostType.SingleOrDefaultAsync(m => m.ID == id);
            if (postType == null)
            {
                return NotFound();
            }

            _context.PostType.Remove(postType);
            await _context.SaveChangesAsync();

            return Ok(postType);
        }

        private bool PostTypeExists(int id)
        {
            return _context.PostType.Any(e => e.ID == id);
        }
    }
}