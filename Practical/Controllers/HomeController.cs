using Microsoft.AspNetCore.Mvc;
using Practical.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Practical.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        

        public IActionResult Index()
        {
            string url = "https://gorest.co.in/public/v2/users";

            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;

            string result = response.Content.ReadAsStringAsync().Result;

            List<gorest> data = JsonSerializer.Deserialize<List<gorest>>(result);

            //ViewBag.dataresponse = data;
            
            return View(data);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}