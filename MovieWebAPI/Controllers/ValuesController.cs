using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieWebAPI.Models;

namespace MovieWebAPI.Controllers
{

    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private IMovieRepository _db;

        public ValuesController(IMovieRepository db)
        {
            _db = db;
        }


        //GET api/values
       [HttpGet("{SearchValue}/{Id}")]
        public Task<FirstApi> GetSearchResult(string SearchValue,int Id)
        {
            var result = _db.get(SearchValue,Id);
            return result;
        }

    }
}
