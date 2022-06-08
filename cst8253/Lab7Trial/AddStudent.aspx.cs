using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab7Trial.Models;

namespace Lab7Trial
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void AddStudent_Click(object sender, EventArgs e)
        {
            // declare and initialize students list
            List<Student> students = new List<Student>();
            // add students to session if list is not empty
            if (Session["students"] != null)
            { students = Session["students"] as List<Student>; }

            // fulltime student
            if (studentStatus.Text == "Full Time")
            {
                // add studentName as Student FulltimeStudent instance
                Student student = new FulltimeStudent (studentName.Text);
                // add student to students list
                students.Add (student);
            } else if (studentStatus.Text == "Part Time")
            {
                // add studentName as Student ParttimeStudent instance
                Student student = new ParttimeStudent(studentName.Text);
                // add student to students list
                students.Add(student);
            } else
            {
                // add studentName as Student CoopStudent instance
                Student student = new CoopStudent(studentName.Text);
                // add student to students list
                students.Add(student);
            }

            // add students to session
            Session["students"] = students;



            if (students.Count != 0)
            {
                // add students to studentTable
                foreach (Student student in students)
                {
                    // add new row
                    TableRow tableRow = new TableRow();
                    studentTable.Rows.Add(tableRow);
                    // add Id to cell
                    TableCell cell = new TableCell();
                    tableRow.Cells.Add(cell);
                    cell.Text = student.Id.ToString();
                    // add Name to cell
                    cell = new TableCell();
                    tableRow.Cells.Add(cell);
                    cell.Text = student.Name;
                }
            }

            // clear textbox and dropdown selection
            studentName.Text = "";
            studentStatus.SelectedValue = "0";
        }
    }
}
