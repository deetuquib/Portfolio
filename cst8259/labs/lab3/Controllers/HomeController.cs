using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;

namespace Lab2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet] // asking for data
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost] // sending data
        public IActionResult Index(XMLandSchemaFileUpload dataFile)
        {
            // set up files
            IFormFile xmlFile = dataFile.XmlFile; // from XMLandSchemaFileUpload.cs
            IFormFile xsdFile = dataFile.SchemaFile;

            if (ModelState.IsValid)
            {
                // connect schema file with backend
                // schema -converting
                XmlReader schemaReader = XmlReader.Create(xsdFile.OpenReadStream());
                XmlSchemaSet schemaSet = new XmlSchemaSet();
                // add reader to set
                schemaSet.Add(null, schemaReader);

                // set up setting for schema
                XmlReaderSettings settings = new XmlReaderSettings();
                // set up settings
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas = schemaSet;
                // schema is in the backend by then

                // event handler - create the errors
                List<XmlValidationError> errors = new List<XmlValidationError>();
                settings.ValidationEventHandler +=
                    (s, e) => errors.Add(new XmlValidationError // event handler for errors
                    {
                        Element = ((XmlReader)s).Name, // need to cast converts s to XmlReader type - auto convert to string
                        ErrorType = e.Severity.ToString(), // e.Severity
                        Line = e.Exception.LineNumber,
                        Column = e.Exception.LinePosition,
                        Message = e.Message
                    });

                // xml
                XmlReader xmlReader = XmlReader.Create(xmlFile.OpenReadStream(), settings);
                // importing xml and validating using the schema
                while (xmlReader.Read()) { } // trigger the event handler for error
                ViewBag.XmlFileName = xmlFile.FileName;
                ViewBag.XsdFileName = xsdFile.FileName;
                return View("ValidationResult", errors);
            }

            return View();
        }

        // [HttpPut] - there's data and you want to update

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