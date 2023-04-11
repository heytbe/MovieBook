using Entity.API.Dto.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieBook.Models;
using MovieBook.Services;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace MovieBook.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private readonly CustomClient _client;
        public MovieController(CustomClient client)
        {
            _client = client;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _client._client.GetAsync("api/Movie/movieList");
            var respone = await result.Content.ReadFromJsonAsync<Response<List<MovieIndex>>>();
            return View(respone.data);
        }

        [HttpGet]
        public async Task<IActionResult> MovieDetail(int id)
        {
            var result = await _client._client.GetAsync($"api/Movie/movieid?id={id}");
            var response = await result.Content.ReadFromJsonAsync<Response<MovieListDto>>();
            return View(response.data);
        }

        [HttpGet]
        public async Task<IActionResult> MovieCreate()
        {
            var result = await _client._client.GetAsync("api/Category/categorylist");
            var response = await result.Content.ReadFromJsonAsync<Response<List<CategoryListDto>>>();
            return View(response.data);
        }

        [HttpPost]
        public async Task<IActionResult> MovieCreate(MovieCreateDto movieCreateDto)
        {
            using(var formContent = new MultipartFormDataContent())
            {
                formContent.Add(new StringContent(movieCreateDto.MovieName), "movieName");
                formContent.Add(new StreamContent(movieCreateDto.Poster_Path.OpenReadStream()), "poster_Path",Path.GetFileName(movieCreateDto.Poster_Path.FileName));
                formContent.Add(new StringContent(movieCreateDto.Adult.ToString()), "adult");
                formContent.Add(new StringContent(movieCreateDto.MovieFragman), "movieFragman");
                formContent.Add(new StringContent(movieCreateDto.Imdb), "imdb");
                formContent.Add(new StringContent(movieCreateDto.OrjinalName), "orjinalName");
                formContent.Add(new StringContent(movieCreateDto.Overview), "overview");
                formContent.Add(new StringContent(movieCreateDto.ReleaseDate), "releaseDate");
                formContent.Add(new StringContent(movieCreateDto.RunTime.ToString()), "runTime");
                formContent.Add(new StringContent(movieCreateDto.TagLine), "tagLine");
                formContent.Add(new StreamContent(movieCreateDto.BackdropPath.OpenReadStream()), "backdropPath", Path.GetFileName(movieCreateDto.BackdropPath.FileName));
                foreach (var item in movieCreateDto.MovieImages)
                {
                    formContent.Add(new StreamContent(item.OpenReadStream()), "movieImages",Path.GetFileName(item.FileName));
                }

                foreach (var item in movieCreateDto.Categories)
                {
                    formContent.Add(new StringContent(item.ToString()), "categories");
                }

               var movie = await _client._client.PostAsync("api/Movie/moviecreate", formContent);

                if (movie.IsSuccessStatusCode)
                {
                    Console.WriteLine("Ok");
                }
            }


            return RedirectToAction("MovieCreate");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var deletemovie = await _client._client.DeleteAsync($"api/Movie/deletemovie?id={id}");
            if (deletemovie.IsSuccessStatusCode)
            {
                ViewData["result"] = "Silindi";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}