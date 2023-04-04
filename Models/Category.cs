namespace CatolicoCantorAPI.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Music> Musics { get; set; }
}
