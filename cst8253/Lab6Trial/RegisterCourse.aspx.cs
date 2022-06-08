using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab6Trial.Models;

namespace Lab6Trial
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate all courses in checkbox
                foreach (Course course in Helper.GetAvailableCourses())
                {
                    coursesList.Items.Add(new ListItem($"{course.Title} - {course.WeeklyHours}", $"{course.Code}"));
                }
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            // Declare variables
            int totalCourses = 0;
            int totalHours = 0;
            bool containsError = false;
            // Create list of selectedCourses
            List<Course> selectedCourses = new List<Course>();


            // Get all items in the checkbox
            foreach (ListItem c in coursesList.Items)
            {
                // Calculate total weekly hours and total number of courses
                if (c.Selected)
                {
                    // Get course
                    Course getCourse = Helper.GetCourseByCode(c.Value);
                    // Add to list of selectedCourses
                    selectedCourses.Add(getCourse);
                    // Increment number of courses
                    totalCourses++;
                    // Total of weekly hours
                    totalHours += getCourse.WeeklyHours;
                }
            }

            // Error for fulltime: 16 weekly hours
            if (totalHours > 16 && studentStatus.SelectedValue == "fulltime")
            {
                errorMessage.Visible = true;
                errorMessage.Text = "ERROR! Your selection exceeds the maximum: 16 hours per week";
                containsError = true;
            }

            // Error for parttime: 3 courses
            if (totalCourses > 3 && studentStatus.SelectedValue == "parttime")
            {
                errorMessage.Visible = true;
                errorMessage.Text = "ERROR! Your selection exceeds the maximum: 3 courses";
                containsError = true;
            }

            // Error for coop: 2 courses
            if (totalCourses > 2 && studentStatus.SelectedValue == "coop")
            {
                errorMessage.Visible = true;
                errorMessage.Text = "ERROR! Your selection exceeds the maximum: 2 courses";
                containsError = true;
            }

            // Error for coop: 4 weekly hours
            if (totalHours > 4 && studentStatus.SelectedValue == "coop")
            {
                errorMessage.Visible = true;
                errorMessage.Text = "ERROR! Your selection exceeds the maximum: 4 hours per week";
                containsError = true;
            }


            // Error for no course selected
            if (selectedCourses == null)
            {
                errorMessage.Visible = true;
                errorMessage.Text = "ERROR! You have not selected any course yet";
                containsError = true;

            }

            if (!containsError)
            {
                // Change visibility
                studentName.Enabled = false;
                studentStatus.Enabled = false;
                inputPanel.Visible = false;
                resultsPanel.Visible = true;

                foreach (Course course in selectedCourses)
                {
                    // Row
                    TableRow row = new TableRow();
                    courseTable.Rows.Add(row);

                    // Cell - code
                    TableCell cell = new TableCell();
                    row.Cells.Add(cell);
                    cell.Text = course.Code.ToString();

                    // Cell - title
                    cell = new TableCell();
                    row.Cells.Add(cell);
                    cell.Text = course.Title.ToString();

                    // Cell - weekly hours
                    cell = new TableCell();
                    row.Cells.Add(cell);
                    cell.Text = course.WeeklyHours.ToString();
                }
            }
        }
    }
}
