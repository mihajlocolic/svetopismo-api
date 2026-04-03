using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/chapters")]
public class ChapterController : ControllerBase
{

    private readonly ApplicationDbContext _context;
    public ChapterController(ApplicationDbContext context)    
    {
        _context = context;
    }

    [HttpGet("{chapterNumber}")]
    public async Task<IActionResult> GetChapter(int chapterNumber)
    {        
        var chapter = await _context.Chapters
            .Where(c => c.ChapterNumber == chapterNumber)
            .FirstOrDefaultAsync();

        if(chapter == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(chapter);
        }
    }
    
}