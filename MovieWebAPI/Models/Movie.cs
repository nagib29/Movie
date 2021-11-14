using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebAPI.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string ShortDesc { get; set; }
        public int ReleaseYear { get; set; }
        public IEnumerable<Actor> actor { get; set; }
        public IEnumerable<Director> director { get; set; }
        public IEnumerable<Producer> producer { get; set; }
    }

    public class TvShow
    {
        [Key]
        public int TvShowId { get; set; }
        public string TvShowName { get; set; }
        public string ShortDesc { get; set; }
        public string ReleaseYear { get; set; }
        public IEnumerable<Actor> actor { get; set; }
        public IEnumerable<Director> director { get; set; }
        public IEnumerable<Producer> producer { get; set; }
    }

    public class Actor
    {
        [Key]
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
    }

    public class Director
    {
        [Key]
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
    }

    public class Producer
    {
        [Key]
        public int ProducerId { get; set; }
        public string ProducerName { get; set; }
    }


    public class FirstApi
    {
        public IEnumerable<Movie> movies { get; set; }
        public IEnumerable<TvShow> tvshows { get; set; }
        public IEnumerable<Actor> person { get; set; }
    }
}
