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

        public async Task<ActionResult<Actor>> FindActorById(int Id, int UserId)
        {
            var result = _db.Actors.Find(Id);
            return result;
        }

        public async Task<ActionResult<Movie>> FindMovieById(int Id, int UserId)
        {
            var result = _db.Movies.Include(a => a.actor).Include(a => a.director).Include(a => a.producer).Where(x => x.MovieId == Id).FirstOrDefault();
            return result;
        }

        public async Task<ActionResult<TvShow>> FindTvShowById(int Id, int UserId)
        {
            var result = _db.TvShows.Include(a => a.actor).Include(a => a.director).Include(a => a.producer).Where(x=> x.TvShowId ==Id).FirstOrDefault();
            return result;
        }

        public async Task<ActionResult<FirstApi>> get(string searchvalue,int Id)
        {
            var Keys = searchvalue.Split(' ');
            var movies = _db.Movies.Include(a=> a.actor).Include(a => a.director).Include(a => a.producer).Where(x => Keys.Any(key => x.MovieName.ToLower().Contains(key.ToLower()))).ToList();
            var tvshows = _db.TvShows.Include(a => a.actor).Include(a => a.director).Include(a => a.producer).Where(x => Keys.Any(key => x.TvShowName.ToLower().Contains(key.ToLower()))).ToList();
            var person = _db.Actors.Where(x => Keys.Any(key => x.ActorName.ToLower().Contains(key.ToLower()))).ToList();
            FirstApi result = new FirstApi();

            if(movies.Count > 0)
                result.movies = movies; 

            if (tvshows.Count > 0)
                result.tvshows = tvshows;

            if (person.Count > 0)
                result.person = person;

            return result;

        }

    }
}
