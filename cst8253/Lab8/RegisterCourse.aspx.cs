using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab8.Models;
/* FINAL LAB 8*/
namespace Lab8
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        List<Student> students = new List<Student>();
        Student selectedStudent = new FulltimeStudent("");

        protected void Page_Load(object sender, EventArgs e)
        {

            if(Session["students"] != null)
            {
                students = Session["students"] as List<Student>;
            }

            // !PostBack
            if(!IsPostBack)
            {
                // Populate student names to droplist
                foreach(Student student in students)
                {
                    ListItem studentItem = new ListItem();
                    studentItem.Value = (student.Id).ToString();
                    studentItem.Text = student.ToString();
                    studentList.Items.Add(studentItem);
                }

                // Populate courses to checkbox list
                foreach (Course course in Helper.GetAvailableCourses())
                {
                    coursesList.Items.Add(new ListItem($"{course.Title} - {course.WeeklyHours} hours/week", course.Code));
                }
            }
        }

        // Select Student
        protected void SelectStudentName(object sender, EventArgs e)
        {
            // hide potential error messages
            errorMessage.Visible = false;

            // If student is not empty
            if (studentList.SelectedValue == "")
            {
                enrollmentSummary.Visible = false;
                return;
            }
            else
            {
                enrollmentSummary.Visible = true;
            }

            // Get student
            selectedStudent = selectStudent(students);

            // Update student info
            enrollmentSummary.Text = $"{selectedStudent.Name} has registered {selectedStudent.RegisteredCourses.Count} course(s), {selectedStudent.TotalWeeklyHours()} hours weekly";

            // Check course boxes
            List<string> courseCodes = new List<string>();
            foreach (Course c in selectedStudent.RegisteredCourses)
            {
                courseCodes.Add(c.Code);
            }

            // Select courses chosen by student
            foreach (ListItem item in coursesList.Items)
            {
                item.Selected = false;
                if (courseCodes.Any(s => s.Contains(item.Value)))
                {
                    item.Selected = true;
                }
            }
            return;
        }

        // Save changes
        protected void Save_Click(object sender, EventArgs e)
        {

            // Get checkboxlist info
            int amountSelected = 0;
            List<Course> coursesSelected = new List<Course>();
            foreach (ListItem c in coursesList.Items)
            {
                if (c.Selected)
                {
                    amountSelected++;
                    Course currentCourse = Helper.GetCourseByCode(c.Value);
                    coursesSelected.Add(currentCourse);
                }
            }

            // Select at least 1 course
            if (amountSelected == 0)
            {
                errorMessage.Visible = true;
                errorMessage.Text = "You need to select at least one course";
                return;
            }

            // Get student
            selectedStudent = selectStudent(students);

            // Try to update courses
            try
            {
                selectedStudent.RegisterCourse(coursesSelected);
                errorMessage.Visible = false;
            }
            catch (Exception ex)
            {
                errorMessage.Visible = true;
                errorMessage.Text = ex.Message;
                return;
            }

            // Update student info
            enrollmentSummary.Text = $"{selectedStudent.Name} has registered {selectedStudent.RegisteredCourses.Count} course(s), {selectedStudent.TotalWeeklyHours()} hours per week";
        }

        private Student selectStudent(List<Student> students)
        {
            foreach (Student student in students)
            {
                if (student.Id == Int32.Parse(studentList.SelectedValue))
                {
                    selectedStudent = student;
                }
            }
            return selectedStudent;
        }

    }
}
