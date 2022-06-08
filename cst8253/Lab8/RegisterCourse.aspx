<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab8.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
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
        <div class="container">
            <form id="form1" runat="server">

                <!-- Title -->
                <h1>Course Registration</h1>
                <hr />

                <!-- Student Info -->
                <div class="row form-group">

                    <!-- Student Label -->
                    <asp:Label ID="studentDropLabel" runat="server" Text="Student: " Style="padding: 5px;"></asp:Label>
                    <!-- Student Name DropDown List -->
                    <asp:DropDownList ID="studentList" runat="server" OnSelectedIndexChanged="SelectStudentName" AutoPostBack="true">
                        <asp:ListItem Text="Select..." Value="" />
                    </asp:DropDownList>
                    <!-- Student DropDown List Validator -->
                    <asp:RequiredFieldvalidator ID="studentNameValidator" runat="server" ControlToValidate="studentList" ForeColor="Red" ToolTip="Please enter a name" Display="Dynamic">Required!</asp:RequiredFieldvalidator>
                </div>

                <!-- Enrollment Summary -->
                <p><asp:Label ID="enrollmentSummary" runat="server" Text="" CssClass="emphasis showcase"></asp:Label></p>

                <!-- Error message -->
                <p><asp:Label ID="errorMessage" runat="server" Text="" CssClass="emphsis error"></asp:Label></p>

                <!-- Course Selection -->
                <div>
                    <h4>The following courses are currently available for registration</h4>
                    <!-- Courses -->
                    <asp:CheckBoxList ID="coursesList" runat="server" />
                </div>

                <!-- Button -->
                <div id="btnContainer" class="row form-group">
                    <div class="col-md-1">
                        <asp:Button ID="submitBtn" runat="server" CssClass="button" OnClick="Save_Click" Text="Save"/>
                    </div>
                </div>

                <!-- Add Student -->
                <p><a href="AddStudent.aspx">Add Student</a></p>

            </form>
        </div>
    </body>
</html>
