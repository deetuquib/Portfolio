<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab8.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <title>Student Registration</title>
    
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
        <form id="form1" runat="server"><br />

            <div class="container">
                <!-- Header -->
                <h1>Student Registration</h1>
                <hr />

                <!-- Form input -->

                <!-- Student Name -->
                <div class="row form-group">
                    <div class="col-2 text-right mt-2"><asp:Label ID="studentNameLabel" runat="server" Text="Student Name: " style="padding: 5px;"></asp:Label></div>
                    <div class="col-2 text-left mt-2"><asp:TextBox ID="studentName" runat="server" CssClass="input" Width="150px"></asp:TextBox></div>
                    <div class="col-8 text-left mt-2"><asp:RequiredFieldValidator ID="studentNameValidator" runat="server" ControlToValidate="studentName" ForeColor="Red" ToolTip="Please enter a name" Display="Dynamic">Required!</asp:RequiredFieldValidator></div>
                </div>

                <!-- Student Type -->
                <div class="row form-group">
                    <div class="col-2 text-right mt-2"><asp:Label ID="studentStatusLabel" runat="server" Text="Student Type: " Style="padding: 5px;"></asp:Label></div>
                    <div class="col-2 text-left mt-2"><asp:DropDownList ID="studentStatus" runat="server" Width="150px" >
                        <asp:ListItem Text="Select..." Value="" />
                        <asp:ListItem Value="FullTime">Full Time</asp:ListItem>
                        <asp:ListItem Value="PartTime">Part Time</asp:ListItem>
                        <asp:ListItem Value="Coop">Coop</asp:ListItem>
                    </asp:DropDownList></div>
                    <div class="col-2 text-left mt-2"><asp:RequiredFieldValidator ID="studentTypeValidator" runat="server" ControlToValidate="studentStatus" ForeColor="Red" ToolTip="Please enter a type" Display="Dynamic">Must select one!</asp:RequiredFieldValidator></div>
                </div>

                <!-- Button-->
                <div id="buttonContainer" class="row form-group">
                    <div class="col-2 text-right mt-2">
                        <asp:Button ID="submitButton" runat="server" Text="Add Student" CssClass="button" OnClick="addStudent_Click"/>
                    </div>
                </div>

                <!-- Table -->
                <div id="tableContainer">
                    <asp:Table runat="server" ID="studentTable" CssClass="table">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>

                    </div>
                    <p><a href="RegisterCourse.aspx">Register Courses</a></p>
            </div>

        </form>
    </body>
</html>
