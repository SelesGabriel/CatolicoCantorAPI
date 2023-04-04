using CatolicoCantorAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CatolicoCantorAPI.ViewModels.Playlist.Set;

public class CreatePlaylistViewModel
{
    public string Nome { get; set; }
    [Required]
    public int IdUsuario { get; set; }
    [Required]
    public bool Publica { get; set; }
    [Required]
    public DateTime DataCriacao { get; set; }
    public List<int>? idMusics { get; set; }
}
