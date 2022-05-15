<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="Lab6Statistics.Statistics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <title>Statistics Calculator</title>

        <%-- Use Bootstrap to style the page --%>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
    
        <%-- Jquery required by Bootstrap  --%>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    
        <%-- Bootstrap's Javascript library --%>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    </head>

    <body class="bg-secondary">
        <div class="container bg-light mt-5">
            <h1>Statistics Calculator</h1>
            <form id="form1" runat="server">

                    <!-- User input -->
                    <h4>Enter three numbers and click Submit to generate the statistics.</h4>

                    <h5><div class="row justify-content-start">

                        <!-- First number -->
                        <div class="col-3 text-right mt-2">
                                First Number:
                        </div> <div class="col-9 mt-2">
                                <asp:TextBox ID="firstNum" name="firstNum" runat="server"></asp:TextBox>
                        </div>

                        <!-- Second number -->
                        <div class="col-3 text-right mt-2">
                                Second Number:
                        </div> <div class="col-9 mt-2">
                            <asp:TextBox ID="secondNum" name="secondNum" runat="server"></asp:TextBox>
                        </div>

                        <!-- Third number -->
                        <div class="col-3 text-right mt-2">
                            Third Number:
                        </div> <div class="col-9 mt-2">
                            <asp:TextBox ID="thirdNum" name="thirdNum" runat="server"></asp:TextBox>
                        </div>

                        <!-- Submit -->
                        <div class="col-3 text-right mt-2">
                                <!-- Error message here -->
                            <asp:Button Text="Submit" class="btn btn-primary mt-2" runat="server" />
                        </div>
                        <div class="col-9 mt-2">
                            <asp:Label ID="errorMessage" runat="server" Visible="false" CssClass="text-danger"/>
                        </div>

                    </div></h5>

                    <!-- Results -->
                    <h4>Statistics Results</h4>

                    <h5><div class="row justify-content-start">
                        <div class="col-3 text-right mt-2">
                            Maximum:
                        </div> <div class="col-9 mt-2">
                                <asp:Label runat="server" ID="max" name="max"></asp:Label>
                        </div>
                        <div class="col-3 text-right mt-2">
                            Minimum:
                        </div> <div class="col-9 mt-2">
                            <asp:Label runat="server" ID="min" name="min"></asp:Label>
                        </div>
                        <div class="col-3 text-right mt-2">
                            Average:
                        </div> <div class="col-9 mt-2">
                            <asp:Label runat="server" ID="ave" name="ave"></asp:Label>
                        </div>
                        <div class="col-3 text-right mt-2">
                            Total:
                        </div> <div class="col-9 mt-2 mb-5">
                            <asp:Label runat="server" ID="total" name="total"></asp:Label>
                        </div>
                    </div></h5>

            </form>

        </div>

    </body>

</html>
