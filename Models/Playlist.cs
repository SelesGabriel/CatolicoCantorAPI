using System.ComponentModel.DataAnnotations;

namespace CatolicoCantorAPI.Models;

public class Playlist
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public int IdUsuario { get; set; }
    [Required]
    public bool Publica { get; set; }
    [Required]
    public DateTime DataCriacao { get; set; }

    public ICollection<Music> Musics { get; set; }
}
