<?php
// put your code here
include("./common/header.php");
error_reporting (E_ALL ^ E_NOTICE); 
session_start();
extract($_POST);

/* REDIRECT *******************************************************************/
// redirect if agreement not yet checked
if (!$_SESSION["TermsAndConditions"])
{
    header("Location: TermsAndConditions.php");
    exit();
}

// redirect if customer info is not yet filled
if (!$_SESSION["CustomerInformation"])
{
    header("Location: CustomerInformation.php");
}

/* VARIABLES ******************************************************************/
// variables
$principalError;
$rateError;
$yearsError;
$calculationValidity;

// for calculation
$balance;
$yearlyInterest;


/* BUTTONS ********************************************************************/
// previous button from customer information
if (isset($_POST["previous"]))
{
    $_SESSION["CustomerInformation"] = true;
    header("Location: CustomerInformation.php");
    exit();
}

// calculate button to populate table
if (isset($calculate))
{
    $_SESSION["principal"] = $principal;
    $_SESSION["rate"] = $rate;
    $_SESSION["years"] = $years;
    $_SESSION["balance"] = $balance;
    $_SESSION["yearlyInterest"] = $yearlyInterest;
    $_SESSION["calculationValidity"] = $calculationValidity;

    // call validation functions
    $principalError = checkPrincipal($principal);
    $rateError = checkRate($rate);
    $yearsError = checkYears($years);
    
    if (!$principalError && !$rateError && !$yearsError)
    // if form is valid
    { $calculationValidity = true; $_SESSION["DepositCalculator"] = true; }
}

// complete button
if (isset($complete))
{
    header("Location: Complete.php");
    exit();
}

// if form is valid save to sessions ####
if ($_SESSION["DepositCalculator"])
{
    $principal = $_SESSION["principal"];
    $rate = $_SESSION["rate"];
    $years = $_SESSION["years"];
    $balance = $_SESSION["balance"];
    $yearlyInterest = $_SESSION["yearlyInterest"];
    $calculationValidity = true;

    // for calculation
    $balance;
    $yearlyInterest;
}

/* POPULATE FORM **************************************************************/
print <<<EOS
<form method="post" action="DepositCalculator.php">
    <div class="container mt-3 w-50 form">

    <h2>Lab 3 - Deposit Calculator</h2><br/>

    <!-- PRINCIPAL -->
    <div class="form-group row">
        <label for="principal" class="col-sm-2 col-form-label">Principal Amount:</label>
        <input type="text" class="form-control col-sm-3" id="principal" name="principal" value="$principal"/>
        <p class="errorMessages"> &nbsp;&nbsp; $principalError </p>
    </div>

    <!-- RATE -->
    <div class="form-group row">
        <label for="rate" class="col-sm-2 col-form-label">Interest Rate(%):</label>
        <input type="text" class="form-control col-sm-3" id="interestRate" name="rate" value="$rate" />
        <p class="errorMessages"> &nbsp;&nbsp; $rateError </p>
    </div>

    <!-- YEARS -->
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

    <!-- CALCULATE -->
    <div class="d-grid gap-2">
        <button class="btn btn-primary" type="submit" name="previous">Previous</button>
        <button class="btn btn-primary" type="submit" name="calculate">Calculate</button>
        <button class="btn btn-primary" type="submit" name="complete">Complete</button>
    </div>
EOS;

// show table
if ($calculationValidity == true)
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
    /*echo "<br>
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
    }*/


    // table head
    echo '
        <br><br>
        <h4>The following is the result of the calculation:</h4>
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

    echo '</table> <br/>';

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
        
/******************************************************************************/
print <<<EOS
</div>   
</form>
EOS;
include('./common/footer.php');