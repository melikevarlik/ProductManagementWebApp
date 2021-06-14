using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KocDigital.Models;
using System.Net.Http;
using System.Net.Http.Headers;


namespace KocDigital.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;
        private static readonly HttpClient client = new HttpClient();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
           

            //HttpClient.PostAsync("https://localhost:44316/api/Product/createproduct?", product);
            //HttpResponseMessage response = await objHttpClient.Post(this.AppSettings.WebApiPath + Constant.SubOperatorInsert, subOperator);

            return View();
        }

       
        public ActionResult create()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> createAsync(Product product)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/Product/createproduct");


                var postTask = await client.PostAsJsonAsync<Product>("createproduct", product);
                

                
                if (postTask.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(product);
        }



        public async Task<IActionResult> PrivacyAsync(String productName)
        {
            int asa = 12;
            //var values = new Product
            //{
            //    productID = new Guid("CEBA954D-29FE-4AC7-9098-175CC063439A"),
            //    productName = "Book",
            //    productDescription = "Book is white",
            //    productPrice = 12,
            //};


        //    var content = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)values);

        //var response = await client.PostAsync("https://localhost:44316/api/Product/createproduct", content);

        //var responseString = await response.Content.ReadAsStringAsync();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
