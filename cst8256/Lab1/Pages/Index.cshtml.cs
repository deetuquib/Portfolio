using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        // binding properties
        [BindProperty]
        public string FirstNumber {get; set;}
        [BindProperty]
        public string SecondNumber {get; set;}
        [BindProperty]
        public string ThirdNumber { get; set; }

        // create new list
        public List<double> Numbers { get; set; }
        
        // other variables
        double firstNum, secondNum, thirdNum;
        public double Min { get; set; }
        public double Max { get; set; }
        public double Sum { get; set; }
        public double Average { get; set; }
        public bool Validity { get; set; }
        public bool IsPostBack { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            // #TODO: ask prof why it's necessary to put list under IndexModel
            Numbers = new List<double>();
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            IsPostBack = true;
            Validity = true;

            // if input is blank, convert to 0
            if (FirstNumber == null) { FirstNumber = "0"; }
            if (SecondNumber == null) { SecondNumber = "0"; }
            if (ThirdNumber == null) { ThirdNumber = "0"; }

            // if input is invalid, show error message
            if (Double.TryParse(FirstNumber, out firstNum)) { Numbers.Add(firstNum); } else { Validity = false; }
            if (Double.TryParse(SecondNumber, out secondNum)) { Numbers.Add(secondNum); } else { Validity = false; }
            if (Double.TryParse(ThirdNumber, out thirdNum)) { Numbers.Add(thirdNum); } else { Validity = false; }

            // if count > 0
            if (Numbers.Count > 0)
            {
                // get minimum number
                Min = Numbers.Min();
                // get maximum number
                Max = Numbers.Max();
                // get sum
                Sum = Numbers.Sum();
                // get average
                Average = Numbers.Average();
            } else
            {
                Validity = false;
            }

        }
    }
}
