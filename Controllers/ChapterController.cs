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

    [HttpGet("{chapterId}")]
    public async Task<IActionResult> GetChapter(int chapterId)
    {
        var chapter = await _context.Chapters
            .Where(c => c.ChapterId == chapterId)
            .FirstOrDefaultAsync();

        if (chapter == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(chapter);
        }
    }

}