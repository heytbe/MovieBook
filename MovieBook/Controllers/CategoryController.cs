using Entity.API.Dto.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieBook.Models;
using MovieBook.Services;
using System.Net.Http.Headers;
using System.Threading;

namespace MovieBook.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly CustomClient _client;
        private readonly HttpRequestMessage _request;
        public CategoryController(CustomClient client, HttpRequestMessage request)
        {
            _client = client;
            _request = request;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _client._client.GetAsync("api/Category/categorylist");
            _request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            await _client._client.SendAsync(_request);
            var response = await result.Content.ReadFromJsonAsync<Response<List<CategoryContentLİstDto>>>();
            return View(response.data);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDto categoryDto)
        {
            using (var formContent = new MultipartFormDataContent())
            {
                formContent.Add(new StringContent(categoryDto.CategoryName), "CategoryName");
                formContent.Add(new StreamContent(categoryDto.Categoryimage.OpenReadStream()), "Categoryimage", Path.GetFileName(categoryDto.Categoryimage.FileName));
                var createCategory = await _client._client.PostAsync("api/Category/categorycreate", formContent);
                if(createCategory.IsSuccessStatusCode)
                {
                    Console.Write("Create Category");
                }
            }
            //var response = await _client._client.PostAsJsonAsync<CategoryDto>("api/Category/categorycreate", categoryDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> FindMovie(int id)
        {
            var result = await _client._client.GetAsync($"api/Category/findmovie?id={id}");
            var response = await result.Content.ReadFromJsonAsync<Response<List<MovieCategoryListDto>>>();
            return View(response.data);
        }
    }
}
