using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebApiTest.Dto.HotelDto;

namespace WebApiTest.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HotelController : Controller
    {
        public IActionResult Index()
        {
            var httpClient = new HttpClient();
            if (httpClient != null)
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token").ToString());
                var request = httpClient.GetAsync("http://localhost:5262/api/Hotel/GetHotel").Result;
                var response = request.Content.ReadAsStringAsync().Result;
                var value = JsonConvert.DeserializeObject<List<HotelListDto>>(response);
                return View(value);
            }
            return NotFound();
        }
    }
}
