using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBook.Models
{
    public class MovieListDto
    {
        public string MovieName { get; set; }
        public string Poster_Path { get; set; }
        public bool Adult { get; set; }
        public string? MovieFragman { get; set; }
        public string? Imdb { get; set; }
        public string? OrjinalName { get; set; }
        public string? Overview { get; set; }
        public string? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public string? TagLine { get; set; }
        public string? BackdropPath { get; set; }

        public List<MovieImagesList> MovieImages { get; set; }
        public List<MovieCategoryList> Categories { get; set; }

    }
}
