<!DOCTYPE html>
<!-- Lab 3 -->
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
        <style>
            .errorMessages
            {
                color: red;
                font-style: italic;
                font-size: 14px;
            }
        </style>
        <title>Lab 3 - Deposit Calculator</title>
    </head>
    <body>
        <?php
        // put your code here
        error_reporting (E_ALL ^ E_NOTICE); 
        session_start();
        extract($_POST);
        
        
        /* ERROR MESSAGES *****************************************************/
        //$errorList = [];
        $valid = false;
        $principalError;
        $rateError;
        $yearsError;
        $nameError;
        $codeError;
        $phoneError;
        $emailError;
        $preferredContactError;
        $callTimeError;
        
        
        // for calculation
        $balance;
        $yearlyInterest;

        
        /* SUBMIT BUTTON ******************************************************/
        
        if(isset($submit))
        {
            // call validation functions
            $principalError = checkPrincipal($principal);
            $rateError = checkRate($rate);
            $yearsError = checkYears($years);
            $nameError = checkName($name);
            $codeError = checkCode($code);
            $phoneError = checkPHone($phone);
            $emailError = checkEmail($email);
            $preferredContactError = checkContact($preferredContact);
            if ($preferredContact == "phone") { $callTimeError = checkCallTime($callTime); }
            
            // display page
            if (!$principalError && !$rateError && !$yearsError && !$nameError && !$codeError && !$phoneError && !$emailError && !$preferredContactError && !$callTimeError)
            { $valid = true; }           
        }
        
        else if (($reset))
        {
            session_destroy();
            $_POST = array();
            header("Location: DepositCalculator.php");
            $form.reset();
            /*/exit();
            $principalError = "";
            $rateError = "";
            $yearsError = "";
            $nameError = "";
            $codeError = "";
            $phoneError = "";
            $emailError = "";
            $preferredContactError = "";
            $callTimeError = "";
            exit();*/
            if (isset($_POST['aaa'])){
            echo '
            <script type="text/javascript">
            location.reload();
            </script>';
            }
        }
        
        /*$amountValue = $amount ?? "";
        $rateValue = $rate ?? "";
        $nameValue = $name ?? "";
        $postcodeValue = $postcode ?? "";
        $phoneValue = $phone ?? "";
        $emailValue = $email ?? "";
        $yearValue = $year ?? "1";
        $contact = $contact ?? "phone";
        $time = $time ?? "";*/
        
        /* IF INVALID**********************************************************/
        
        if (!$valid)
        {
            print <<< EOS
            
                <form action='DepositCalculator.php' method="post">

                <div class="container mt-3 w-50 form">

                    <h2>Lab 3 - Deposit Calculator</h2><br/>

                    <!-- Amount -->
                    <div class="form-group row">
                        <label for="principal" class="col-sm-2 col-form-label">Principal Amount:</label>
                        <input type="text" class="form-control col-sm-3" id="principal" name="principal" value="$principal"/>
                        <p class="errorMessages"> &nbsp;&nbsp; $principalError </p>
                    </div>

                    <div class="form-group row">
                        <label for="rate" class="col-sm-2 col-form-label">Interest Rate(%):</label>
                        <input type="text" class="form-control col-sm-3" id="interestRate" name="rate" value="$rate" />
                        <p class="errorMessages"> &nbsp;&nbsp; $rateError </p>
                    </div>

                    <div class="form-group row">
                        <label for="years" class="col-sm-2 col-form-label">Years to Deposit:</label>
                        <select id="years" name="years" class="form-select col-sm-3" >
                            <option value="" disabled selected>Select years . . .</option>
            EOS;
                            for ($i = 1; $i <= 20; $i++)
                            {
                                echo "<option value='$i'", ($years == $i) ? "selected>" : ">", $i, "</option>";
                            }            
            print <<<EOS
                        </select>
                        <p class="errorMessages"> &nbsp;&nbsp; $yearsError </p>
                    </div>

                    <br/>
                    <hr class="col-sm-5" align="left"/>
                    <br/>
 
                    <!-- User Info -->
                    <div class="form-group row">
                        <label for="name" class="col-sm-2 col-form-label">Name:</label>
                        <input type="text" class="form-control col-md-3" id="name" name="name" value="$name"/>
                        <p class="errorMessages"> &nbsp;&nbsp; $nameError </p>
                    </div>

                    <div class="form-group row">
                        <label for="code" class="col-sm-2 col-form-label">Postal Code:</label>
                        <input type="text" class="form-control col-md-3" id="code" name="code" value="$code"/>
                        <p class="errorMessages"> &nbsp;&nbsp; $codeError </p>
                    </div>

                    <div class="form-group row">
                        <label for="phone" class="col-sm-2 col-form-label">Phone Number:</label>
                        <input type="text" class="form-control col-md-3" id="phone" name="phone" value="$phone"/>
                        <p class="errorMessages"> &nbsp;&nbsp; $phoneError </p>
                    </div>

                    <div class="form-group row">
                        <label for="email" class="col-sm-2 col-form-label">Email:</label>
                        <input type="text" class="form-control col-md-3" id="email" name="email" value="$email"/>
                        <p class="errorMessages"> &nbsp;&nbsp; $emailError </p>
                    </div>

                    <br/>
                    <hr class="col-sm-5" align="left"/>
                    <br/>

            EOS;
                    // preferred contact
                    $contactPhone = ($preferredContact == "phone") ? "checked" : "";
                    $contactEmail = ($preferredContact == "email") ? "checked" : "";
            
            print <<<EOS

                    <!-- Contact Information -->
                    <div class="mb-3 mt-3">
                        <label>Preferred contact method: </label><br/>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="radio" name="preferredContact" id="phoneRadio" value="phone"/ $contactPhone>
                                <label class="form-check-label" for="phoneRadio">Phone</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="radio" name="preferredContact" id="emailRadio" value="email" $contactEmail>
                                <label class="form-check-label" for="emailRadio">Email</label>
                            </div>
                        <br />
                        <p class="errorMessages"> $preferredContactError </p>
                    </div>
                    <br/>
                    
            EOS;
                    // contact method
                    $contactMorning = (in_array("morning", (array)$callTime)) ? "checked" : "";
                    $contactAfternoon = (in_array("afternoon", (array)$callTime)) ? "checked" : "";
                    $contactEvening = (in_array("evening", (array)$callTime)) ? "checked" : "";
            
            print <<<EOS
                    
                    <div class="mb-3 mt-3">
                        <label for="contactTime">If phone is selected, please choose the best time to call: </label><br/>
                            <div id="contactTime" class="form-check form-check-inline">
                                <input class="form-check-input" type="checkbox" name="callTime[ ]" value="morning" $contactMorning/>
                                <label class="form-check-label" for="morning">Morning</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="checkbox" name="callTime[ ]" value="afternoon" $contactAfternoon/>
                                <label class="form-check-label" for="afternoon">Afternoon</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="checkbox"  name="callTime[ ]" value="evening" $contactEvening/>
                                <label class="form-check-label" for="evening">Evening</label>
                            </div>
                        <br />
                        <p class="errorMessages"> $callTimeError </p>
                    </div>
                    <br/>

                    <!-- Submit -->
                    <div class="d-grid gap-2">
                        <button class="btn btn-primary" type="submit" name="submit">Calculate</button>
                        <button class="btn btn-primary" type="submit" name="reset">Clear</button>
                    </div>

                </div>
            </form>
            
            EOS; 
        }
        
        /* IF VALID ***********************************************************/
        else
        {
            echo '<div class="container mt-3">';
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
            <p>Our customer service will 
            ";

            // phone or email
            if ($preferredContact == "phone" && $error == false)
            {
                echo "call you tomorrow ";
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

            echo '</table> <a href="DepositCalculator.php">Start over</a>';
            
        }
        
        
        
        /* FUNCTIONS **********************************************************/
        function checkPrincipal($principal): string
        {
            if (empty(trim($principal)))
            {
                return "Must not be empty!";
            } else if (!is_numeric($principal))
            {
                return "Must be numeric!";
            } else if ($principal <= 0)
            {
                return "Must be greater than 0!";
            } else
            {
                return false;
            }
        }
        
        function checkRate($rate): string
        {
            if (empty($rate))
            {
                return "Must not be empty!";
            } else if (!is_numeric($rate))
            {
                return "Must be numeric!";
            } else if ($rate <= 0)
            {
                return "Must be greater than 0";
            } else
            {
                return false;
            }
        }
        
        function checkYears($years): string
        {
            if (empty($years))
            {
                return "Must select number of years!";
            } else
            {
                return false;
            }
        }
            
        function checkName($name): string
        {
            if (empty($name))
            {
                return "Must not be empty!";
            } else
            {
                return false;
            }
        }

        function checkCode($code)
        {
            $regex = "/[a-zA-Z][0-9][a-zA-Z]\s*[0-9][a-zA-Z][0-9]/i";
            if (empty($code))
            {
                return "Must not be empty!";
            } else if (!preg_match ($regex, $code))
            {
                return "Must be a valid postal code!";
            } else
            {
                return false;
            }
        }

        function checkPhone($phone)
        {
            $regex = "/^([2-9]\d{2})-([2-9]{3})-(\d{4})$/";
            if (empty($phone))
            {
                return "Must not be empty!";
            } else if (!preg_match($regex, $phone))
            {
                return "Must be a valid phone number!";
            } else
            {
                return false;
            }
        }
        
        function checkEmail($email)
        {
            $regex = "/\b[a-z0-9._%+-]+@(([a-z0-9-]+)\.)+[a-z]{2,4}\b/i";
            if (empty($email))
            {
                return "Must not be empty!";
            } else if (!preg_match($regex, $email))
            {
                return "Must be a valid email address!";
            } else
            {
                return false;
            }
        }

        function checkContact($preferredContact)
        {
            if (empty($preferredContact))
            {
                return "Please select a preferred contact method!";
            } else
            {
                return false;
            }
        }
        
        function checkCallTime($callTime)
        {
            if (empty($callTime))
            {
                return "Please select a preferred time!";
            } else
            {
                return false;
            }
        }
        
        ?>
        
    </body>
</html>