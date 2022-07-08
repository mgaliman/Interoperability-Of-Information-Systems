using Microsoft.AspNetCore.Mvc;

namespace IIS_07_UI.Controllers
{
    public class SOAPController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result(string? data)
        {

            if (!String.IsNullOrEmpty(data))
            {
                ServiceReference1.SOAPSoapClient service = new ServiceReference1.SOAPSoapClient(ServiceReference1.SOAPSoapClient.EndpointConfiguration.SOAPSoap);

                string result = service.SearchAsync(data).Result.Body.SearchResult;

                if (!String.IsNullOrEmpty(result))
                {
                    ViewBag.Data = result;
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
