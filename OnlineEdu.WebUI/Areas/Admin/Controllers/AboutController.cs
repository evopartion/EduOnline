using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.AboutDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AboutController : Controller
    {
       private readonly HttpClient _client=HttpClientInstance.CreateClient();
        public IActionResult Index()
        {
            var values = _client.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View();
        }
    }
}
