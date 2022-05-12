```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab8.Models;

namespace Lab8
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize list
            List<Student> students = new List<Student>();


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

            // PostBack
            if (IsPostBack)
            {

            }
        }

        // Select Student
        protected void SelectStudentName(object sender, EventArgs e)
        {
            // hide potential error messages
            errorMessage.Visible = false;

            // Initialize student list
            List<Student> students = new List<Student>();
            if (Session["students"] != null)
            {
                students = Session["students"] as List<Student>;
            }

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
            Student selectedStudent = new FulltimeStudent("");
            foreach (Student student in students)
            {
                if (student.Id == Int32.Parse(studentList.SelectedValue))
                {
                    selectedStudent = student;
                }
            }

            // Update student info
            enrollmentSummary.Text = $"{selectedStudent.Name} has registered {selectedStudent.RegisteredCourses.Count} course(s), {selectedStudent.TotalWeeklyHours()} hours weekly";

            // Check course boxes
            List<string> courseCodes = new List<string>();
            foreach (Course c in selectedStudent.RegisteredCourses)
            {
                courseCodes.Add(c.Code);
            }

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
            // Get Students
            List<Student> students = new List<Student>();
            if (Session["students"] != null)
            {
                students = Session["students"] as List<Student>;
            }

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
            Student selectedStudent;
            foreach (Student student in students)
            {
                if (student.Id == Int32.Parse(studentList.SelectedValue))
                {
                    selectedStudent = student;
                    break;
                }
            }
            if (selectedStudent != null)
            {
                // Update courses
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
            } 


            // Update student info
            enrollmentSummary.Text = $"{selectedStudent.Name} has registered {selectedStudent.RegisteredCourses.Count} course(s), {selectedStudent.TotalWeeklyHours()} hours per week";
        }
    }
}

```

```asp
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab6.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <!-- Title -->
         <title>Algonquin: Course Registration</title>

        <%-- Use Bootstrap to style the page --%>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
    
        <%-- Jquery required by Bootstrap  --%>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    
        <%-- Bootstrap's Javascript library --%>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

        <!-- Style Sheet -->
        <link href="App_Themes/SiteStyles.css" rel="stylesheet" type="text/css" />
    </head>

    <body>
        <form id="form1" runat="server">
            <!-- Header -->
            <h1>Algonquin College Course Registration</h1>
            <hr />

            <!-- Student Info -->
            <div>
                Student Name:
                <asp:TextBox runat="server" ID="studentName"></asp:TextBox>
                <asp:RadioButtonList runat="server" ID="studentStatus" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Full Time" Value="fulltime" />
                    <asp:ListItem Text="Part Time" Value="parttime" />
                    <asp:ListItem Text="Co-op" Value="coop" />
                </asp:RadioButtonList>
            </div>

            <!-- Input Panel -->
            <asp:Panel runat="server" ID="inputPanel">
                <!-- Error Message -->
                <div>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="studentName" ID="studentNameValidator">Please enter student name!</asp:RequiredFieldValidator>&nbsp;&nbsp;
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Status">Please select student status!</asp:RequiredFieldValidator>
                </div>

                <!-- Courses Checkbox-->
                <p>The following courses are available for registration:</p>
                <asp:CheckBoxList runat="server" ID="coursesList"></asp:CheckBoxList>

                <!-- Submit Button -->
                <asp:Button runat="server" ID="submitButton" Text="Submit" />
            </asp:Panel>



            <!-- Results Panel -->
            <asp:Panel runat="server" ID="resultsPanel">
                <!-- Student has enrolled in the followin courses -->
                <p id="enrollmentLabel"></p>

                <!-- Table -->
                <asp:Table runat="server" CssClass="table">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell CssClass="distinct">Course Code</asp:TableHeaderCell>
                        <asp:TableHeaderCell CssClass="distinct">Title</asp:TableHeaderCell>
                        <asp:TableHeaderCell CssClass="distinct">Weekly Hours</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </asp:Panel>

        </form>
    </body>
</html>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab6.Models
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (Course course in Helper.GetAvailableCourses())
                {
                    coursesList.Items.Add(new ListItem($"{course.Title} - {course.WeeklyHours}", $"{course.Code}"));
                }

                studentName.Text = "hellow";
            }

        }
    }
}

```

# Web.config

Add to Web.config file's <configuration> for usin ASP.NET validation controls

```html
<appSettings>
	<add key="ValidationSettings:UnobtrusiveValidationMode" value="None"/>
</appSettings>
```

# Head

```html
    <head runat="server">
        <!-- Title -->
         <title>Algonquin: Course Registration</title>

        <!-- Use Bootstrap to style the page -->
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
        <!-- Jquery required by Bootstrap  -->
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <!-- Bootstrap's Javascript library -->
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
        <!-- Style Sheet -->
        <link href="App_Themes/SiteStyles.css" rel="stylesheet" type="text/css" />
    </head>
```

# Submit Button

```html
<asp:Button runat="server" ID="" CssClass="button" Text="" OnClick=""></asp:Button>
```

# Models

```c#
using filename.Models;
```

Master Page

```html
<asp:ContentPlaceHolder ID="head" runat="server"></asp:ContentPlaceHolder>

<asp:ContentPlaceHolder ID="ContentPlaceHolder1" runat="server"></asp:ContentPlaceHolder>
```

```html
<%@ Page Title="" Language="C#" MasterPageFile="~/AlgonquinCollege.Master" AutoEventWireup="true" CodeBehind="FirstPage.aspx.cs" Inherits="Lab3SolutionSAT.FirstPage"
%>
```

