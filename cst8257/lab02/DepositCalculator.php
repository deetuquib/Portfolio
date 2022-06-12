<!DOCTYPE html>
<!--
To change this license header, choose License Headers in Project Properties.
To change this template file, choose Tools | Templates
and open the template in the editor.
-->
<html>
    <head>
        <meta charset="UTF-8">
        <!-- Use Bootstrap to style the page -->
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
        <!-- Bootstrap's JavaScript library -->
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <title>Lab 2 - Deposit Calculator Access Form Data</title>
    </head>
    <body class="container form mt-3">
        <?php error_reporting (E_ALL ^ E_NOTICE);
        // put your code here
        
        // link variables
        $principal = $_POST["principal"];
        $rate = $_POST["rate"];
        $years = $_POST["years"];
        $name = $_POST["name"];
        $code = $_POST["code"];
        $phone = $_POST["phone"];
        $email = $_POST["email"];
        $preferredContact = $_POST["preferredContact"];
        $callTime = $_POST["callTime"];
        
        $balance;
        $yearlyInterest;
        
        // error messages
        $errorList = [];
        $principalError;
        $rateError;
        $yearsError;
        $nameError;
        $codeError;
        $phoneError;
        $emailError;
        $preferredContactError;
        $callTimeError;
        $error = false;
        
        
        // ---------------------------------------------------------------------
        // principal -----------------------------------------------------------
        if (empty($principal))
        {
            $error = true;
            $principalError = "PRINCIPAL AMOUNT: required";
            array_push($errorList, $principalError);
        } else if (!is_numeric($principal))
        {
            $error = true;
            $principalError = "PRINCIPAL AMOUNT: must be numeric";
            array_push($errorList, $principalError);
        } else if ($principal <= 0)
        {
            $error = true;
            $principalError = "PRINCIPAL AMOUNT: must be greater than 0";
            array_push($errorList, $principalError);
        }
                
        // interest rate -------------------------------------------------------
        if (empty($rate))
        {
            $error = true;
            $rateError = "INTEREST RATE: required";
            array_push($errorList, $rateError);
        } else if (!is_numeric($rate))
        {
            $error = true;
            $rateError = "INTEREST RATE: must be numeric";
            array_push($errorList, $rateError);
        } else if ($rate <= 0)
        {
            $error = true;
            $rateError = "INTEREST RATE: must be greater than 0";
            array_push($errorList, $rateError);
        }
       
        // years to deposit ----------------------------------------------------
        if (empty($years))
        {
            $error = true;
            $yearsError = "YEARS TO DEPOSIT: required";
            array_push($errorList, $yearsError);
        }
        
        // name ----------------------------------------------------------------
        if (empty($name))
        {
            $error = true;
            $nameError = "NAME: required";
            array_push($errorList, $nameError);
        }
        
        // postal code ---------------------------------------------------------
        if (empty($code))
        {
            $error = true;
            $codeError = "POSTAL: required";
            array_push($errorList, $codeError);
        }
        
        // phone ---------------------------------------------------------------
        if (empty($name))
        {
            $error = true;
            $phoneError = "PHONE NUMBER: required";
            array_push($errorList, $phoneError);
        }
        
        // email ---------------------------------------------------------------
        if (empty($email))
        {
            $error = true;
            $emailError = "EMAIL: required";
            array_push($errorList, $emailError);
        }
        
        // preferred contact ---------------------------------------------------
        if (empty($preferredContact))
        {
            $error = true;
            $preferredContactError = "CONTACT METHOD: required";
            array_push($errorList, $preferredContactError);
        }
        
        // if phone is selected ------------------------------------------------
        if ($preferredContact == "phone")
        {
            // if call method is empty
            if (empty($callTime))
            {
                $error = true;
                $callTimeError = "CALL TIME: required";
                array_push($errorList, $callTimeError);
            }
        }


        // ---------------------------------------------------------------------
        // display page
            if ($error)
            {
                echo '<div> <h1>Thank you, $name!</h1>';
                echo "<p>ERROR! Unfortunately, we're unable to process your request because of the following:</p>";
                foreach ($errorList as $errorMessage)
                {
                    echo "<ul>- $errorMessage</ul>";
                }
            } else
            {
                // deposit calculation
                floatval($principal);
                floatval($rate);
                $rate = $rate/100;
                $balance = $principal;
                $yearlyInterest = $balance * $rate;
                //$balanceFloat = number_format($balance, 2);
                //$yearlyInterestFloat = number_format($yearlyInterest, 2);
                              
                // greetings
                echo "
                <h1>Thank you, $name, for using our deposit calculator!</h1>
                <p>Our customer service will call you tomorrow
                ";
                
                // phone or email
                if ($preferredContact == "phone" && $error == false)
                {
                    
                    echo implode(" or ", $callTime)." at $phone.</p>";
                } else if ($preferredContact == "email")
                {
                    echo "email you tomorrow at $email.</p>";
                }
                              
                
                // table head
                echo '
                    <p>The following is the result of the calculation:</p>
                    <table class="table">
                    <thead><tr>
                        <th scope="col">Year</th>
                        <th scope="col">Principal at Year Start</th>
                        <th scope="col">Interest for the Year</th>
                    </tr></thead>
                 ';
                
                // table body
                for ($i = 1; $i <= $years; $i++)
                {                  
                    echo "
                    <tr>
                        <td>$i</td>
                        <td>".number_format($balance, 2)."</td>
                        <td>".number_format($yearlyInterest, 2)."</td>
                    </tr>
                    ";
                    $balance += $yearlyInterest;
                    $yearlyInterest = $balance * $rate;
                }
                
                echo '
                 </table></div>
                 ';
            }
            
            ?>
                        
    </body>
</html>
