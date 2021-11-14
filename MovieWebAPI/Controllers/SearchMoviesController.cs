using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieWebAPI.Models;

namespace MovieWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SearchMoviesController : ControllerBase
    {
        private IMovieRepository _movierepository;

        public SearchMoviesController(IMovieRepository movierepository)
        {
            _movierepository = movierepository;
        }

        
        [HttpGet("{SearchValue}/{UserId}")]
        [Route("GetSearchResult")]
        public Task<ActionResult<FirstApi>> GetSearchResult(string SearchValue, int UserId)
        {

            var result = _movierepository.get(SearchValue, UserId);

            return result;
        }

        [HttpGet("{Id}/{UserId}")]
        [Route("GetMovieById")]
        public Task<ActionResult<Movie>> GetMovieById(int Id, int UserId)
        {
            var result = _movierepository.FindMovieById(Id,UserId);
           
            return result;
        }

        [HttpGet("{Id}/{UserId}")]
        [Route("GetTvShowById")]
        public Task<ActionResult<TvShow>> GetTvShowById(int Id, int UserId)
        {
            var result = _movierepository.FindTvShowById(Id, UserId);
           
            return result;
        }

        [HttpGet("{Id}/{UserId}")]
        [Route("FindActorById")]
        public Task<ActionResult<Actor>> FindActorById(int Id, int UserId)
        {
            var result = _movierepository.FindActorById(Id, UserId);
           
            return result;
        }


        [HttpGet("{response}")]
        [Route("AlreadySearched")]
        public IActionResult AlreadySearched(string response)
        {
            return Ok(response);
        }
    }
}