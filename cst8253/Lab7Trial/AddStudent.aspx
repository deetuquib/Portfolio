<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab7Trial.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <!-- Title -->
         <title>Algonquin: Student Registration</title>
        <!-- Use Bootstrap to style the page -->
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
        <!-- Jquery required by Bootstrap  -->
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <!-- Bootstrap's Javascript library -->
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
        <!-- Style Sheet -->
        <link href="App_Themes/SiteStyles.css" rel="stylesheet" type="text/css" />
    </head>

    <body class="container">
        <form id="form1" runat="server">

            <!-- -->

            <!-- Student Info-->
            <div class="row">
                <!-- Name -->
                <div class="col-3 text-right mt-2">Name:</div>
                <div class="col-9 mt-2"><asp:TextBox runat="server" ID="studentName" CssClass="input" Width="250px"></asp:TextBox></div>

                <!-- Status -->
                <div class="col-3 text-right mt-2">Status</div>
                <div class="col-9 mt-2"><asp:DropDownList runat="server" ID="studentStatus" width="250px">
                    <asp:ListItem Value="0">Select status...</asp:ListItem>
                    <asp:ListItem>Full Time</asp:ListItem>
                    <asp:ListItem>Part Time</asp:ListItem>
                    <asp:ListItem>Coop</asp:ListItem>
                </asp:DropDownList></div>

                <!-- Button -->
                <div class="col-3 mt-2 text-right"><asp:Button runat="server" ID="addButton" CssClass="button" OnClick="AddStudent_Click" Text="Add"/></div>

                <!-- Error -->
                <div class="col-9 mt-2">
                    <asp:RequiredFieldValidator runat="server" CssClass="error" ControlToValidate="studentName">Please enter student name.</asp:RequiredFieldValidator> &nbsp;
                    <asp:CompareValidator runat="server" CssClass="error" ControlToValidate="studentStatus" Display="Dynamic" Operator="NotEqual" ValueToCompare="0">Please enter student status.</asp:CompareValidator> &nbsp;
                    <asp:Label runat="server" ID="errorMessage" CssClass="error" Visible="false" />
                </div>

            </div>

            <!-- Table -->
            <asp:Table runat="server" ID="studentTable" CssClass="table">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>

        </form>
    </body>
</html>
