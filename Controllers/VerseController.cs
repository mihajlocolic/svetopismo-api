using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("/api/verses")]
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
        /*var verses = await _context.Verses.FromSqlInterpolated($"SELECT s.stih_id as Id, s.stih_broj as VerseNumber, s.stih_tekst as VerseText, s.glava_broj as ChapterNumber, k.knjiga_ime as BookName FROM stihovi AS s JOIN knjige AS k WHERE s.stih_tekst LIKE { '%' + verseText + '%'} AND s.knjiga_id = k.knjiga_id")
        .AsAsyncEnumerable()
        .Select(v => new VerseDTO
        {
        })
        .ToListAsync();        
        */

        var verses = await (
            from v in _context.Verses
            join b in _context.Books on v.BookId equals b.BookId
            where v.VerseText.Contains(verseText)
            select new VerseDTO
            {
                Id = (int) v.Id,
                VerseNumber = (int) v.VerseNumber,
                VerseText = v.VerseText,
                ChapterNumber = (int) v.ChapterNumber,
                BookName = b.BookName
            }
        
        ).ToListAsync();


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