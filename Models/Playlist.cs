using System.ComponentModel.DataAnnotations;

namespace CatolicoCantorAPI.Models;

public class Playlist
{
    [Key]
    public int PlaylistId { get; set; }
    public string? Nome { get; set; }
    public int IdUsuario { get; set; }
    public bool Publica { get; set; }
    public DateTime DataCriacao { get; set; }

    public ICollection<Music>? Musics { get; set; }
}
