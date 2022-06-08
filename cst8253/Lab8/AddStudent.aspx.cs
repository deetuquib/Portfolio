using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab8.Models;

namespace Lab8
{
    public partial class AddStudent : System.Web.UI.Page
    {
        // Initialize
        List<Student> students = new List<Student>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // No student yet
                if (Session["students"] == null)
                {
                    TableRow row = new TableRow();
                    studentTable.Rows.Add(row);

                    TableCell cell = new TableCell();
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    row.Cells.Add(cell);
                    cell.Text = "No student yet";
                    cell.Style.Add("color", "red");
                }

                // Populate exiting data, if available
                else
                {
                    // Clear the no student yet
                    //studentTable.Rows.Clear();
                    //studentTable.Rows.Remove(studentTable.Rows[1]);

                    students = Session["students"] as List<Student>;

                    // Add all students to table
                    foreach (Student student in students)
                    {
                        TableRow row = new TableRow();
                        studentTable.Rows.Add(row);

                        TableCell cell = new TableCell();
                        row.Cells.Add(cell);
                        cell.Text = student.Id.ToString();

                        cell = new TableCell();
                        row.Cells.Add(cell);
                        cell.Text = student.Name;
                        cell.Style.Add("color", "#666699");
                    }
                }
            }
        }

        // click Submit Button
        protected void addStudent_Click(object sender, EventArgs e)
        {
            

            // Populate existing list of students, if available
            if (Session["students"] != null)
            {
                students = Session["students"] as List<Student>;

                // Add all students to table
                foreach (Student student in students)
                {
                    TableRow row = new TableRow();
                    studentTable.Rows.Add(row);

                    TableCell cell = new TableCell();
                    row.Cells.Add(cell);
                    cell.Text = student.Id.ToString();

                    cell = new TableCell();
                    row.Cells.Add(cell);
                    cell.Text = student.Name;
                }
            }

            // Add student
            if (IsPostBack)
            {

                // Initialize student in scope
                Student student = new FulltimeStudent("");

                // Student status
                switch (studentStatus.SelectedValue)
                {
                    case "FullTime":
                        student = new FulltimeStudent(studentName.Text);
                        break;
                    case "PartTime":
                        student = new ParttimeStudent(studentName.Text);
                        break;
                    case "Coop":
                        student = new CoopStudent(studentName.Text);
                        break;
                }

                // Add row
                TableRow row = new TableRow();
                studentTable.Rows.Add(row);

                // Add student information to row
                TableCell cell = new TableCell();
                row.Cells.Add(cell);
                cell.Text = student.Id.ToString();

                cell = new TableCell();
                row.Cells.Add(cell);
                cell.Text = student.Name;
                cell.Style.Add("color", "#666699");

                // Add new student to session
                students.Add(student);
                Session["students"] = students;

                // Clear student name and status
                studentName.Text = "";
                studentStatus.SelectedValue = "";
            }
        }
    }
}
