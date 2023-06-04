<?php
include "./Common/db.php";
$cssFile = "NewUser.css";
include "./Common/header.php";

$StudentIdErr = '';
$NameErr = '';
$PhoneErr = '';
$PasswordErr = '';
$PasswordAgainErr = '';
$StudentId = '';
$Name = '';
$Phone = '';
$Password = '';
$PasswordAgain = '';
if (isset($_POST['_submit'])) {
    extract($_POST);
    if (isBlank($StudentId)) {
        $StudentIdErr = 'Student ID is not blank';
    } else if (isBlank($Name)) {
        $NameErr = 'Name is not blank';
    } else if (isBlank($Phone)) {
        $PhoneErr = 'Phone number is not blank';
    } else if (!isPhoneNumber($Phone)) {
        $PhoneErr = "Incorrect Phone Number";
    } else if (isBlank($Password)) {
        $PasswordErr = 'Password is not blank';
    } else if (!isPassword($Password)) {
        $PasswordErr = 'Password is at least 6 characters long, contains at least one upper case, one lowercase and one digit';
    } else if (isBlank($PasswordAgain)) {
        $PasswordAgainErr = 'Password again is not blank';
    } else if ($Password != $PasswordAgain) {
        $PasswordAgainErr = 'Password again is not the same as Password';
    } else {
        $pdo = connect();
        if ($pdo != null) {
            $students = 0;
            try {
                $sql = "SELECT count(*) FROM Student where StudentId='{$StudentId}'";
                $students = $pdo->query($sql)->fetchColumn();
                if ($students > 0) {
                    $StudentIdErr = 'A Student with this ID has already signed up';
                } else {
                    //$Password=hash("md5",$Password);
                    $Password=password_hash($Password, PASSWORD_DEFAULT); // #9 Replace the hash fucntion with password_hash($Password, PASSWORD_DEFAULT) instead
                    $sql = "INSERT INTO Student (StudentId,Name,Phone,Password) VALUES (?,?,?,?)";
                    $stmt = $pdo->prepare($sql);
                    $stmt->execute([$StudentId,$Name,$Phone,$Password]);
                    $pdo = null;
                    $_SESSION["studentSN"]=$StudentId;
                    $_SESSION["StudentId"]=$StudentId;
                    $_SESSION["studentSN"]=$StudentId;
                    $_SESSION["StudentSet"]=[];
                    $_SESSION["Name"]=$Name;
                    
                    header("Location:course_select.php");
                    exit();
                }
            } catch (PDOException $e) {
                die($e->getMessage());
            }
        }
    }
}


?>

<?php
print <<<HTML
        
    <div class="container">
        <h1>Sign Up</h1>
        <p>All fields are required</p>
         
        <form action="{$_SERVER['PHP_SELF']}" method="post">
            <div class="form-group row">
                <label class="col-sm-2 col-form-label"> Student ID: </label>
                <input class="col-sm-2" type="text" name="StudentId" value="$StudentId"/>
                <span id="studentError" class="col-sm-4" style="color:red">$StudentIdErr</span>

            </div>
            <div class="form-group row">
                <label class="col-sm-2 col-form-label"> Name: </label>
                <input class="col-sm-2"type="text" name="Name" value="$Name"/>
                <span id="nameError" class="col-sm-4" style="color:red">$NameErr</span>
            </div>
            <div class="form-group row">
                <label class="col-sm-2 col-form-label"> Phone Number: </label>
                <input class="col-sm-2" type="text" name="Phone" value="$Phone"/>
                <span id="phoneError" class="col-sm-4" style="color:red">$PhoneErr</span>
            </div>
            <div class="form-group row">
                <label class="col-sm-2 col-form-label"> Password: </label>
                <input class="col-sm-2" type="password" name="Password" value="$Password"/>
                <span id="passwordError" class="col-sm-4" style="color:red">$PasswordErr</span>                
            </div> 
            <div class="form-group row">
                <label class="col-sm-2 col-form-label"> Password Again: </label>
                <input class="col-sm-2" type="password" name="PasswordAgain" value="$PasswordAgain"/>
            </div>             
            
            <hr/>

            <div class="row">
                <div class="col-md-offset-1 col-md-2">
                    <input type="submit" name="_submit" value="Submit" class="btn btn-primary" />
                </div>
                <div class="col-md-offset-1 col-md-2">
                    <input type="reset" name="Clear" value="Clear" class="btn btn-primary" />
                </div>
            </div>        
        </form>
        </div>
HTML;
        ?>

<?php
include "./Common/footer.php";
function isBlank($str)
{
    if (strlen($str) == 0) {
        return true;
    }
    return false;
}

function isPhoneNumber($phone)
{
    $reg = "/^[2-9][0-9]{2}-[2-9]{3}-[0-9]{4}$/i";
    if (preg_match($reg, $phone) == 0) {
        return false;
    }
    return true;
}

function isPassword($passwd)
{
    $reg = "/^(?=.*[0-9])(?=.*[A-Z])(?=.*[a-z]).{6,}$/";
    if (preg_match($reg, $passwd) == 0) {
        return false;
    }
    return true;
}

?>