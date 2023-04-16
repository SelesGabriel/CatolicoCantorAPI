using System.ComponentModel.DataAnnotations;

namespace CatolicoCantorAPI.Models;

public class Music
{
    [Key]
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cantor { get; set; }
    public string? Letra { get; set; }
    public string? Cifra { get; set; }
    public string? Youtube { get; set; }
    public string? Tags { get; set; }


    public List<Category> Categories { get; set; } = new List<Category> { };
}
