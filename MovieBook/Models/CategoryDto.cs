using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.API.Dto.Category
{
    public class CategoryDto
    {
        public string CategoryName { get; set; }
        public IFormFile Categoryimage { get; set; }
    }
}
