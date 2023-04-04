﻿using CatolicoCantorAPI.Data;
using CatolicoCantorAPI.Interfaces;
using CatolicoCantorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CatolicoCantorAPI.Repository
{
    public class MusicRepository : IMusicRepository
    {
        readonly AppDbContext db;
        public MusicRepository(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<List<Music>> GetAllMusics() => await db.Musics.Include(x=>x.Categories).ToListAsync();
        public async Task<Music?> GetMusicById(int id) => await db.Musics.Include(x => x.Categories).FirstAsync(x=>x.Id == id);


        public async Task<Music> PostMusic(Music model)
        {
            await db.AddAsync(model);
            await db.SaveChangesAsync();
            return model;
        }

        public async Task<Music> PutMusic(Music model)
        {
            throw new NotImplementedException();
        }
        public async Task<Music> DeleteMusic(int id)
        {
            throw new NotImplementedException();
        }
    }
}