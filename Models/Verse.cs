using System.ComponentModel.DataAnnotations.Schema;

[Table("stihovi")]
public class Verse
{
    [Column("stih_id")]
    public long Id {get; set;}
    
    [Column("stih_broj")]
    public long VerseNumber {get; set;}

    [Column("stih_tekst")]
    public required string VerseText {get; set;}
    
    [Column("knjiga_id")]
    public long BookId {get; set;}

    [Column("glava_id")]
    public long ChapterId {get; set;}

    [Column("glava_broj")]
    public long ChapterNumber {get; set;}
    
}