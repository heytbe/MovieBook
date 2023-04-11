using System.Net.Http.Headers;

namespace MovieBook.Services
{
    public class CustomClient:DelegatingHandler
    {
        public HttpClient _client { get; set; }
        private IHttpContextAccessor _context { get;set; }
        public CustomClient(HttpClient client, IHttpContextAccessor context)
        {
            client.BaseAddress = new Uri("https://localhost:7233/");
            _context = context;
            _client = client;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _context.HttpContext.Session.GetString("token"));
        }
    }
}
