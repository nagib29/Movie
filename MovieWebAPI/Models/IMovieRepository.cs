using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebAPI.Models
{
    public interface IMovieRepository
    {
        Task<ActionResult<FirstApi>> get(string searchvalue,int Id);
        Task<ActionResult<Movie>> FindMovieById(int Id, int UserId);
        Task<ActionResult<TvShow>> FindTvShowById(int Id, int UserId);
        Task<ActionResult<Actor>> FindActorById(int Id, int UserId);
    }
}
