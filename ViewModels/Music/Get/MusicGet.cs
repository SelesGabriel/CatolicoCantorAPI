﻿using CatolicoCantorAPI.ViewModels.Category.Get;

namespace CatolicoCantorAPI.ViewModels.Music.Get
{
    public class MusicGet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cantor { get; set; }
        public string Letra { get; set; }
        public string Cifra { get; set; }
        public string Youtube { get; set; }
        public string Tags { get; set; }
        public ICollection<CategoryGet> Categories { get; set; }
    }
}
