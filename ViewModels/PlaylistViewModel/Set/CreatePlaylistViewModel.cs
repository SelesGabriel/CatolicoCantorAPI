using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.Music.Set;
using System.ComponentModel.DataAnnotations;

namespace CatolicoCantorAPI.ViewModels.Playlist.Set;

public class CreatePlaylistViewModel
{
    public string Nome { get; set; }
    public int IdUsuario { get; set; }
    public bool Publica { get; set; }
    public ICollection<int>? IdMusics { get; set; }
}
