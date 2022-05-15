using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab6Statistics
{
    public partial class Statistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // error message initial visibility
            errorMessage.Visible = false;

            if (IsPostBack)
            {
                try
                {
                    // link variables to form textbox
                    int firstNumber = Int32.Parse(firstNum.Text);
                    int secondNumber = Int32.Parse(secondNum.Text);
                    int thirdNumber = Int32.Parse(thirdNum.Text);

                    // create array
                    int[] array = new int[3] { firstNumber, secondNumber, thirdNumber };

                    // get minimum number
                    int minimum = array.Min();

                    // get maximum number
                    int maximum = array.Max();

                    // get sum
                    int sum = array.Sum();

                    // get average
                    double average = array.Average();

                    // populate results
                    max.Text = maximum.ToString();
                    min.Text = minimum.ToString();
                    ave.Text = average.ToString();
                    total.Text = sum.ToString();

                }
                catch (Exception ex)
                {
                    errorMessage.Visible = true;
                    errorMessage.Text = "Error: " + ex.Message;
                    max.Text = "";
                    min.Text = "";
                    ave.Text = "";
                    total.Text = "";
                }
            }
        }
    }
}
