<?php
// put your code here
include("./common/header.php");
error_reporting (E_ALL ^ E_NOTICE); 
session_start();
extract($_POST);

// sessions
$name = $_SESSION["name"];
$code = $_SESSION["code"];
$phone = $_SESSION["phone"];
$email = $_SESSION["email"];
$preferredContact = $_SESSION["contact"];
$callTime = $_SESSION["callTime"];

// redirect if agreement not yet checked
if (!$_SESSION["TermsAndConditions"])
{
    header("Location: TermsAndConditions.php");
}

// redirect if customer info is not yet filled
if (!$_SESSION["CustomerInformation"])
{
    header("Location: CustomerInformation.php");
}

// redirect if customer info is not yet filled
if (!$_SESSION["DepositCalculator"])
{
    header("Location: DepositCalculator.php");
}

print <<<EOS
    <div class="container mt-3">
        <h1>Success!</h1>
        <h5>
            Thank you, $name, for using our deposit calculation tool!
        <br> Our customer service department will 
EOS;
        if ($preferredContact == "phone" && $error == false)
            {
                echo "call you tomorrow ";
                echo implode(" or ", $callTime)." at $phone.</p>";
            } else if ($preferredContact == "email")
            {
                echo "email you tomorrow at $email.</p>";
            }
print <<<EOS
   
        </h5>
    </div>
EOS;

$_POST = array();
include('./common/footer.php');
session_destroy();
