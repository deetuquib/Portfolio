using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab6Client.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Net;

namespace Lab6.Controllers
{
    public class HomeController : Controller
    {

        private IConfiguration _configuration;
        private string serviceUrl;
        public HomeController(IConfiguration config)
        {
            _configuration = config;
            serviceUrl = _configuration.GetValue<string>("ServerURL");
        }
        public IActionResult Index()
        {
            throw new NotImplementedException("Replace this line with your code");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound( );
            }
          
            throw new NotImplementedException("Replace this line with your code"); 
        }

        [HttpPost]
        public IActionResult Edit(RestaurantInfo restInfo)
        {
            throw new NotImplementedException("Replace this line with your code");
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(RestaurantInfo restInfo)
        {
            throw new NotImplementedException("Replace this line with your code");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            throw new NotImplementedException("Replace this line with your code");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }

}
