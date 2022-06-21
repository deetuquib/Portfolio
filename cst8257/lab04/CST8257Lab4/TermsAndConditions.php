<?php
// put your code here
include("./common/header.php");
error_reporting (E_ALL ^ E_NOTICE); 
session_start();
extract($_POST);

// variables
$valid;
$termsCheckbox;
$termsError;

// sessions
$_SESSION["termsCheckbox"] = $termsCheckbox;
/*$_SESSION["name"] = $name;
$_SESSION["code"] = $code;
$_SESSION["phone"] = $phone;
$_SESSION["email"] = $email;
$_SESSION["contact"] = $preferredContact;
$_SESSION["callTime"] = $callTime;*/


/* CLICKING SUBMIT BUTTON (btn-agree) *****************************************/
if(isset($agreeButton))
{
    $termsError = checkTerms($termsCheckbox);
    
    //if agreed
    if (!$termsError)
    {
        $_SESSION["TermsAndConditions"] = true;
        $_SESSION["disclaimerAgreement"] = "checked";
        $_SESSION["termsError"] = $termsError;
        header("Location: CustomerInformation.php");
        exit();
    }
}

// if form is valid save to sessions
if ($_SESSION["TermsAndConditions"] == true)
{
    $disclaimerAgreement = $_SESSION["disclaimerAgreement"];
    $termsError = $_SESSION["termsError"];
    //for debugging: echo "agreed!!!!";
    
}

/******************************************************************************/
print <<<EOS

    <form method="post" action="TermsAndConditions.php"> 
        <div class="container mt-3">
            <h1>Terms and Condition</h1>

            <p>
                I agree to abide by the Bank's Terms and Conditions and rules in force and the changes thereto in Terms and Conditionsn from time to time relating to my account as communicated and made available on the Bank's website.
            </p>

            <p>
                I agree that the bank, before opening any deposit account will carry out due diligence as required under Know Your Customer guidelines of the bank. I would be requested to submit necessary documents or proofs, such as identity, address, photograph, and any such information. I agree to submit the above documents again at periodic intervals, as may  be required by the Bank.
            </p>

            <p>
                I agree that the Bank can at its sole discretion, amend any of the services/facilities given in my account, either wholly or partially at any time by giving me at least 30 days notice and/or provide an option for me to switch to other services/facilities.
            </p>


            <div class="form-check form-check-inline">
                <input type="checkbox" class="form-check-input" name="termsCheckbox[ ]" value="agreed" $disclaimerAgreement/>
                <label class="form-check-label" for="agreed"> I have read and agreed with the terms and conditions.</label>
                <br/>
            </div>
            <div class="errorMessages">$termsError</div> 
            <button type="submit" name="agreeButton" class="btn btn-primary"/>SUBMIT</button>
        </div>
    </form>
EOS;
include('./common/footer.php');

/* FUNCTIONS ******************************************************************/

// check if terms is agreed
function checkTerms($termsCheckbox)
{
    if (empty($termsCheckbox))
    {
        return "You must agree to the terms and conditions!";
    }
    else
    {
        return false;
    }
}