using System.ComponentModel.DataAnnotations;

namespace CatolicoCantorAPI.Models;

public class Playlist
{
    [Key]
    public int Id { get; set; }
    public string? Nome { get; set; }
    public int IdUsuario { get; set; }
    public bool Publica { get; set; }
    public DateTime DataCriacao { get; set; }

    public List<Music> Musics { get; set; } = new List<Music> { };
}
