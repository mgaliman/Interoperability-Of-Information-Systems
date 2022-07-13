using Microsoft.AspNetCore.Mvc;

namespace IIS_07_UI.Controllers
{
    public class FreeNewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DataAsync(string? data)
        {

            if (!String.IsNullOrEmpty(data))
            {
                string ouputString = data.Replace(" ", "%20");

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://free-news.p.rapidapi.com/v1/search?q={ouputString}"),
                    Headers =
                {
                    { "X-RapidAPI-Key", "f5f6a736c2msh09bb7fefe450e43p1fd77cjsn249c11a02cfa" },
                    { "X-RapidAPI-Host", "free-news.p.rapidapi.com" },
                },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    ViewBag.data = body;
                }
            }
            else
            {
                ViewBag.Data = "Data not valid!";
            }

            return View();
        }
    }
}
