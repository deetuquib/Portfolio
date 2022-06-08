<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab6Trial.RegisterCourse" %>

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
            <div class="container">
                <!-- Header -->
                <h1>Algonquin College Course Registration</h1>
                <hr />

                <!-- Student Info -->
                <div class="row">
                    Student Name:
                    <asp:TextBox runat="server" ID="studentName" CssClass="col-3 right-marg"></asp:TextBox>
                    <div class="col-3 right-marg"><asp:RadioButtonList runat="server" ID="studentStatus" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Full Time" Value="fulltime" />
                        <asp:ListItem Text="Part Time" Value="parttime" />
                        <asp:ListItem Text="Co-op" Value="coop" />
                    </asp:RadioButtonList></div>
                </div><br />

                <!-- Input Panel -->
                <asp:Panel runat="server" ID="inputPanel">
                    <!-- Error Message -->
                    <div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="studentName" ID="studentNameValidator" Class="error">Please enter student name!</asp:RequiredFieldValidator>&nbsp;&nbsp;
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="studentStatus" Class="error">Please select student status!</asp:RequiredFieldValidator>
                        <asp:Label runat="server" ID="errorMessage" Visible="false" CssClass="error"></asp:Label>
                    </div>

                    <!-- Courses Checkbox-->
                    <p>The following courses are available for registration:</p>
                    <asp:CheckBoxList runat="server" ID="coursesList"></asp:CheckBoxList>

                    <!-- Submit Button -->
                    <asp:Button runat="server" ID="submitButton" Text="Submit" OnClick="submitButton_Click"/>
                </asp:Panel>



                <!-- Results Panel -->
                <asp:Panel runat="server" ID="resultsPanel" Visible="false">
                    <!-- Student has enrolled in the followin courses -->
                    <p id="enrollmentLabel"></p>

                    <!-- Table -->
                    <asp:Table runat="server" CssClass="table" ID="courseTable">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell CssClass="distinct">Course Code</asp:TableHeaderCell>
                            <asp:TableHeaderCell CssClass="distinct">Title</asp:TableHeaderCell>
                            <asp:TableHeaderCell CssClass="distinct">Weekly Hours</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </asp:Panel>

            </div>
        </form>
    </body>
</html>
