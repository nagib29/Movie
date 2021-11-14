using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebAPI.Models
{
    public class MockMovieRepository :IMovieRepository
    {
        private AppDbContext _db;

        public MockMovieRepository(AppDbContext db)
        {
            _db = db;
        }

        
        public async Task<Movie> FindMovieById(int Id, int UserId)
        {
            var result = _db.Movies.Include(a => a.actor).Include(a => a.director).Include(a => a.producer).Where(x => x.MovieId == Id).FirstOrDefault();
            return result;
        }

        public async Task<TvShow> FindTvShowById(int Id, int UserId)
        {
            var result = _db.TvShows.Include(a => a.actor).Include(a => a.director).Include(a => a.producer).Where(x=> x.TvShowId ==Id).FirstOrDefault();
            return result;
        }

        public async Task<FirstApi> get(string searchvalue,int Id)
        {
            var Keys = searchvalue.Split(' ');
            var movies = _db.Movies.Include(a=> a.actor).Include(a => a.director).Include(a => a.producer).Where(x => Keys.Any(key => x.MovieName.Contains(key))).ToList();
            var tvshows = _db.TvShows.Include(a => a.actor).Include(a => a.director).Include(a => a.producer).Where(x => Keys.Any(key => x.TvShowName.Contains(key))).ToList();
            FirstApi result = new FirstApi();

            result.movies = movies;
            result.tvshows = tvshows;
            return result;

        }

    }
}
