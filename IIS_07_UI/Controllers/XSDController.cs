using IIS_0102_XSD_RNG.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using System.Text.Json;

namespace IIS_07_UI.Controllers
{
    public class XSDController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(FreeNewsModel freeNewsModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", freeNewsModel);
            }

            var url = "http://localhost:5001/api/FreeNewsXSD";

            var request = WebRequest.Create(url);
            request.Method = "POST";

            var json = JsonSerializer.Serialize(freeNewsModel);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            using var reqStream = request.GetRequestStream();
            reqStream.Write(byteArray, 0, byteArray.Length);

            using var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using var respStream = response.GetResponseStream();

            using var reader = new StreamReader(respStream);
            string data = reader.ReadToEnd();
            Console.WriteLine(data);

            ViewBag.data = data;

            return View("Data");
        }

        public IActionResult Data()
        {
            return View();
        }
    }
}
