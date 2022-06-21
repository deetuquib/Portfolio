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

/* ERROR MESSAGES *************************************************************/
$nameError;
$codeError;
$phoneError;
$emailError;
$preferredContactError;
$callTimeError;
    
/* SUBMIT/NEXT BUTTON **********************************************************/
if(isset($submit))
    {
        // saving sessions
        $_SESSION["name"] = $name;
        $_SESSION["code"] = $code;
        $_SESSION["phone"] = $phone;
        $_SESSION["email"] = $email;
        $_SESSION["contact"] = $preferredContact;
        $_SESSION["callTime"] = $callTime;
        $_SESSION["contactMorning"] = $contactMorning;
        $_SESSION["contactAfternoon"] = $contactAfternoon;
        $_SESSION["contactEvening"] = $contactEvening;

        // call validation functions
        $nameError = checkName($name);
        $codeError = checkCode($code);
        $phoneError = checkPHone($phone);
        $emailError = checkEmail($email);
        $preferredContactError = checkContact($preferredContact);
        if ($preferredContact == "phone") { $callTimeError = checkCallTime($callTime); }

        // display page
        if (!$nameError && !$codeError && !$phoneError && !$emailError && !$preferredContactError && !$callTimeError)
        // if customer info form is valid
        { $valid = true; $_SESSION["CustomerInformation"] = true; }

        if ($valid == true)
        {
            header("Location: DepositCalculator.php");
            exit();
        }
    }

// if form is valid save to sessions
if ($_SESSION["CustomerInformation"] == true)
{
    // sessions
    $name = $_SESSION["name"];
    $code = $_SESSION["code"];
    $phone = $_SESSION["phone"];
    $email = $_SESSION["email"];
    $preferredContact = $_SESSION["contact"];
    $callTime = $_SESSION["callTime"];
    $contactEvening = $_SESSION["contactEvening"];
    $contactAfternoon = $_SESSION["contactAfternoon"];
    $contactMorning = $_SESSION["contactMorning"];
}
/******************************************************************************/

print <<<EOS
    
<form action="CustomerInformation.php" method="post">

 <div class="container mt-3 w-50 form">
     <h1>Customer Information</h1>

     <!-- NAME -->
     <div class="form-group row">
         <label for="name" class="col-sm-2 col-form-label">Name:</label>
         <input type="text" class="form-control col-md-3" id="name" name="name" value="$name"/>
         <p class="errorMessages"> &nbsp;&nbsp; $nameError </p>
     </div>

     <!-- POSTAL CODE -->
     <div class="form-group row">
         <label for="code" class="col-sm-2 col-form-label">Postal Code:</label>
         <input type="text" class="form-control col-md-3" id="code" name="code" value="$code"/>
         <p class="errorMessages"> &nbsp;&nbsp; $codeError </p>
     </div>

     <!-- PHONE NUMBER -->
     <div class="form-group row">
         <label for="phone" class="col-sm-2 col-form-label">Phone Number:</label>
         <input type="text" class="form-control col-md-3" id="phone" name="phone" value="$phone"/>
         <p class="errorMessages"> &nbsp;&nbsp; $phoneError </p>
     </div>

     <!-- EMAIL ADDRESS -->
     <div class="form-group row">
         <label for="email" class="col-sm-2 col-form-label">Email:</label>
         <input type="text" class="form-control col-md-3" id="email" name="email" value="$email"/>
         <p class="errorMessages"> &nbsp;&nbsp; $emailError </p>
     </div>

EOS;

     // preferred contact
     $contactPhone = ($preferredContact == "phone") ? "checked" : "";
     $contactEmail = ($preferredContact == "email") ? "checked" : "";

     print <<<EOS

     <!-- CONTACT METHOD -->
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

     EOS;
     // contact method
     $contactMorning = (in_array("morning", (array)$callTime)) ? "checked" : "";
     $contactAfternoon = (in_array("afternoon", (array)$callTime)) ? "checked" : "";
     $contactEvening = (in_array("evening", (array)$callTime)) ? "checked" : "";

     print <<<EOS

     <!-- CALL TIME -->
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

     <!-- SUBMIT -->
     <div class="d-grid gap-2">
         <button class="btn btn-primary" type="submit" name="submit">Next</button>
     </div>

 </div>
 </form>
        
EOS;
include('./common/footer.php');




/* FUNCTIONS ******************************************************************/
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










