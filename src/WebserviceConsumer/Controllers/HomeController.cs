using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace WebserviceConsumer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Calculator()
        {
            ViewData["Message"] = "Your Calculator page.";

            return View();
        }

        public IActionResult Docker()
        {
            //ViewData["Message"] = "Your Docker 5.0 page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public string Add(int param1, int param2)
        {
            return Adder.call(param1, param2);
        }

    }

    class Adder
    {
        private const string URL = "http://188.166.197.0:5010/api/add";

        public static string call(int param1, int param2)
        {
            string urlParameters = "?param1=" + param1 + "&param2=" + param2;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                //var result = response.Content.ToString();
                var result = response.Content.ReadAsStringAsync().Result;
                //var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;
                Console.WriteLine("Managed to successfull call Add Webservice with this result: {0}", result);
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return "Error";
            }
        }
    }
}
