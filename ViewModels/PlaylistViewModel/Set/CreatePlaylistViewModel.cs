using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.Music.Set;
using System.ComponentModel.DataAnnotations;

namespace CatolicoCantorAPI.ViewModels.Playlist.Set;

public class CreatePlaylistViewModel
{
    public int PlaylistId { get; set; }
    public string Nome { get; set; }
    [Required]
    public int IdUsuario { get; set; }
    [Required]
    public bool Publica { get; set; }
    [Required]
    public DateTime DataCriacao { get; set; }
    public ICollection<IncludeMusicPlaylist> Musics { get; set; }
}
