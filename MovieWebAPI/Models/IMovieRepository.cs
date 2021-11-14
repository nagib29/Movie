using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebAPI.Models
{
    public interface IMovieRepository
    {
        Task<FirstApi> get(string searchvalue,int Id);
        Task<Movie> FindMovieById(int Id, int UserId);
        Task<TvShow> FindTvShowById(int Id, int UserId);
    }
}
