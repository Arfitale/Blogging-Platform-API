using App.Database;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogController(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
    {
        return await _context.Blogs.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Blog>> GetBlog(int id)
    {
        var blog = await _context.Blogs.FindAsync(id);

        if (blog == null)
        {
            return NotFound();
        }

        return blog;
    }

    [HttpPost]
    public async Task<ActionResult<Blog>> CreateBlog(Blog blog)
    {
        _context.Blogs.Add(blog);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBlogs), new { id = blog.Id }, blog);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBlog(int id, Blog blog)
    {
        if (id != blog.Id)
        {
            return BadRequest();
        }

        _context.Entry(blog).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Blogs.Any(e => e.Id == id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlog(int id)
    {
        var blog = await _context.Blogs.FindAsync(id);
        if (blog == null)
        {
            return NotFound();
        }

        _context.Blogs.Remove(blog);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
