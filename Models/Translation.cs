using System.ComponentModel.DataAnnotations.Schema;


[Table("prevodi")]
public class Translation
{
    [Column("prevod_id")]
    public long TranslationId {get; set;} 

    [Column("prevod_ime")]
    public string? TranslationName {get; set;}

    [Column("skracenica")]
    public string? Abbreviation {get; set;}
}