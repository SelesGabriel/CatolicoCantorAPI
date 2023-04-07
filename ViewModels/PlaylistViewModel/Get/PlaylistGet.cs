using CatolicoCantorAPI.ViewModels.Music.Get;
using System.ComponentModel.DataAnnotations;

namespace CatolicoCantorAPI.ViewModels.Playlist.Get
{
    public class PlaylistGet
    {
        public int PlaylistId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public bool Publica { get; set; }
        [Required]
        public DateTime DataCriacao { get; set; }

        public ICollection<MusicGet> Musics { get; set; }
    }
}
