using System.ComponentModel.DataAnnotations.Schema;


[Table("glave")]
public class Chapter
{
    [Column("glava_id")]
    public long ChapterId {get; set;}

    [Column("glava_broj")]
    public long ChapterNumber {get; set;}

    [Column("stihovi")]
    public string? Verses {get; set;}

    [Column("knjiga_id")]
    public long BookId {get; set;}

    [Column("prevod_id")]
    public long TranslationId {get; set;}

    
}