using System.ComponentModel.DataAnnotations.Schema;


[Table("knjige")]
public class Book
{
    [Column("knjiga_id")]
    public long BookId {get; set;}

    [Column("knjiga_ime")]
    public string? BookName {get; set;}

    [Column("prevod_id")]
    public long TranslationId {get; set;}

    [Column("skracenica")]
    public string? Abbreviation {get; set;}

}