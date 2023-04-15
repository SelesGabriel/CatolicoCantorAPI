using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.CategoryViewModel.Get;
using CatolicoCantorAPI.ViewModels.CategoryViewModel.Set;

namespace CatolicoCantorAPI.ViewModels.Music.Set
{
    public class CreateMusicViewModel
    {
        public string? Nome { get; set; }
        public string? Cantor { get; set; }
        public string? Letra { get; set; }
        public string? Cifra { get; set; }
        public string? Youtube { get; set; }
        public string? Tags { get; set; }
        public List<IncludeCategoryMusic> Categories { get; set; }
    }
}
