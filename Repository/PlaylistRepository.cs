using CatolicoCantorAPI.Data;
using CatolicoCantorAPI.Interfaces;
using CatolicoCantorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CatolicoCantorAPI.Repository
{
    public class PlaylistRepository : IPlaylistRepository
    {
        readonly AppDbContext db;
        public PlaylistRepository(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<List<Playlist>> GetAllPlaylists() => await db.Playlists.Include(x => x.Musics).AsNoTracking().ToListAsync();
        public async Task<Playlist?> GetPlaylistById(int id) => await db.Playlists.Include(x => x.Musics).AsNoTracking().FirstAsync(x => x.PlaylistId == id);


        public async Task<Playlist> PostPlaylist(Playlist model)
        {
            await db.AddAsync(model);
            await db.SaveChangesAsync();
            return model;
        }

        public async Task<Playlist> PutPlaylist(Playlist model)
        {
            throw new NotImplementedException();
        }
        public async Task<Playlist> DeletePlaylist(int id)
        {
            throw new NotImplementedException();
        }
    }
}
