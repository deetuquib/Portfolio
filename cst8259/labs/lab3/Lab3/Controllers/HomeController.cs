using Lab3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // deserialize data from xml
            // take local path
            string xmlFilePath = Path.GetFullPath("Data/restaurant_reviews.xml");
            // open file stream
            FileStream xmlFileStream = new FileStream(xmlFilePath, FileMode.Open);
            // serializer 
            XmlSerializer xmlSerializerFile = new XmlSerializer(typeof(restaurants));
            // use serializer to deserialize data from file stream & turned to restaurants type
            restaurants restaurantsObject = (restaurants)xmlSerializerFile.Deserialize(xmlFileStream);
            // close filestream
            xmlFileStream.Close();
            // return to frontend

            // creating the list to be returned
            List<RestaurantOverviewViewModel> restaurantList = new List<RestaurantOverviewViewModel>();
            int i = 0;
            foreach(restaurantsRestaurant resto in restaurantsObject.restaurant)
            {
                // loop all restaurants and store as temp var resto
                RestaurantOverviewViewModel re = new RestaurantOverviewViewModel();
                re.Id = i++;
                re.Name = resto.generalInfo.name;
                re.FoodType = resto.generalInfo.cuisine;
                re.Rating = resto.generalInfo.rating.Value; // .Value because complex type
                re.Cost = resto.generalInfo.priceRange.Value;
                re.City = resto.generalInfo.address.city;
                re.ProvinceState = resto.generalInfo.address.state.ToString(); // .ToString() because the state is an enumeration
                restaurantList.Add(re); // add everything to the list
            }

            return View(restaurantList);
        }

        // when a request is made to a URL mapped to a controller action method decorated with [HttpGet], the method is invoked to handle the request
        // The action method can perform any necessary logic and return various types of responses, not just views
        // View method is called to return a view to the clien
        [HttpGet] // decorated action method to be invoked when a GET request is made to the corresponding URL
        public IActionResult Edit(int? id)
        {
            string xmlFilePath = Path.GetFullPath("Data/restaurant_reviews.xml");
            FileStream xmlFileStream = new FileStream(xmlFilePath, FileMode.Open);
            XmlSerializer xmlSerializerFile = new XmlSerializer(typeof(restaurants));
            restaurants restaurantsObject = (restaurants)xmlSerializerFile.Deserialize(xmlFileStream);
            xmlFileStream.Close();
            
            RestaurantEditViewModel re = new RestaurantEditViewModel();
            // select specific restaurant
            restaurantsRestaurant specificResto = restaurantsObject.restaurant[(int) id]; // cast id in int (can't be nullable)
            re.Id = (int) id;
            re.Name = specificResto.generalInfo.name;
            re.StreetAddress = specificResto.generalInfo.address.street;
            re.City = specificResto.generalInfo.address.city;
            re.ProvinceState = specificResto.generalInfo.address.state;
            re.PostalZipCode = specificResto.generalInfo.address.postalCode;
            re.Summary = specificResto.review.summary;
            re.Rating = specificResto.generalInfo.rating.Value;


            return View(re);
        }

        // allows you to handle form submissions, API requests, and other POST-based actions in your application
        [HttpPost] // decorated action method that specifies that the action method should respond to HTTP POST requests
        public IActionResult Edit(RestaurantEditViewModel model)
        {
            string xmlFilePath = Path.GetFullPath("Data/restaurant_reviews.xml");
            FileStream xmlFileStream = new FileStream(xmlFilePath, FileMode.Open); // reading
            XmlSerializer xmlSerializerFile = new XmlSerializer(typeof(restaurants));
            restaurants restaurantsObject = (restaurants)xmlSerializerFile.Deserialize(xmlFileStream);
            xmlFileStream.Close();

            restaurantsRestaurant specificResto = restaurantsObject.restaurant[model.Id]; // taking in the model & no need to cast
            specificResto.generalInfo.name = model.Name;
            specificResto.generalInfo.address.street = model.StreetAddress;
            specificResto.generalInfo.address.city = model.City;
            specificResto.generalInfo.address.state = model.ProvinceState;
            specificResto.generalInfo.address.postalCode = model.PostalZipCode;
            specificResto.review.summary = model.Summary;
            specificResto.generalInfo.rating.Value = (byte) model.Rating;

            // serializing/saving/writing
            xmlFileStream = new FileStream(xmlFilePath, FileMode.Create); // reopening & writing
            xmlSerializerFile.Serialize(xmlFileStream, restaurantsObject); // one tied to the id
            xmlFileStream.Close();

            return RedirectToAction("Index");
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