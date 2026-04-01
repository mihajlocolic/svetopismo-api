using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("/api/books")]
public class BookController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BookController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await (
            from b in _context.Books
            select new BookDTO
            {
                BookId = b.BookId,
                BookName = b.BookName
            }
            
        ).ToListAsync();
        if(books.Count < 1) return NotFound();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(long id)
    {
        
        List<ChapterDTO> bookChapters = await _context.Chapters.Where(c => c.BookId == id).Select(c => new ChapterDTO
        {
            ChapterId = c.ChapterId,
            ChapterNumber = c.ChapterNumber,
            BookId = c.BookId,
            TranslationId = c.TranslationId,
            Verses = c.Verses

        }).OrderBy(c => c.ChapterNumber).ToListAsync();
        if(bookChapters == null) return NotFound();


        return Ok(bookChapters); 
    }
    
}