using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("/api/[controller]")]
public class VerseController : ControllerBase
{

    private readonly ApplicationDbContext _context;
    public VerseController(ApplicationDbContext context)    
    {
        _context = context;
    }


    [HttpGet("search")]
    public async Task<IActionResult> GetVerse([FromQuery] string verseText)
    {

        var verses = await _context.Verses.FromSqlInterpolated($"SELECT * FROM stihovi WHERE stih_tekst LIKE { '%' + verseText + '%'}").ToListAsync();
        
            
        if(verses == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(verses);
        }
    }
}