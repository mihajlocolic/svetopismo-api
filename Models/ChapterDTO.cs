public class ChapterDTO
{
    public required long ChapterId { get; set; }
    public required long ChapterNumber { get; set; }
    public long BookId { get; set; }
    public long TranslationId { get; set; }

    public string? Verses {get; set;}
}