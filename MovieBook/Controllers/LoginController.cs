using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MovieBook.Models;
using MovieBook.Services;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace MovieBook.Controllers
{
    public class LoginController : Controller
    {
        private readonly CustomClient _client;

        public LoginController(CustomClient client)
        {
            _client = client;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            var client = await _client._client.PostAsJsonAsync<LoginDto>("api/Authentication", loginDto);
            var response =  await client.Content.ReadFromJsonAsync<Response<TokenDto>>();
            if(response.data.AccessToken != null)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name ,loginDto.Email)
                };
                var claimidentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimidentity), authProperties);
                
                HttpContext.Session.SetString("token", response.data.AccessToken);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
