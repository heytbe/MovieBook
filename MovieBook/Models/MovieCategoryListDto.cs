using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBook.Models
{
    public class MovieCategoryListDto
    {
        public int MovieId { get; set; }
        public int CategoryId { get; set; }

        public MovieListDto Movie { get; set; }
    }
}
