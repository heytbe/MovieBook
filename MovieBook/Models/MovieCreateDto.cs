using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBook.Models
{
    public class MovieCreateDto
    {
        public string MovieName { get; set; }
        public IFormFile Poster_Path { get; set; }
        public bool Adult { get; set; }
        public string? MovieFragman { get; set; }
        public string? Imdb { get; set; }
        public string? OrjinalName { get; set; }
        public string? Overview { get; set; }
        public string? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public string? TagLine { get; set; }
        public IFormFile BackdropPath { get; set; }

        public List<IFormFile> MovieImages { get; set; }
        public List<int> Categories { get; set; }

    }
}
