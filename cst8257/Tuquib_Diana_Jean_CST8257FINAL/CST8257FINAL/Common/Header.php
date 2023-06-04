<?php
session_start();

$li="";
if(!isset($_SESSION["studentSN"])){
    $li="<li><a href='Login.php'>Log In</a></li>";
}else{
    $li="<li><a href='Logout.php'>Log Out</a></li>";
}
print <<<EOF
<!DOCTYPE html>
<html lang="en" style="position: relative; min-height: 100%;">
<head>
	<title>Online Course Registration</title>
        <meta charset="utf-8"> 
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@3.3.6/dist/css/bootstrap.min.css">
        <link rel="stylesheet" href="./css/$cssFile">
        <script src="./js/jquery-3.6.0.min.js" defer></script>
        <script src="./js/main.js" defer></script>
</head>
<body style="padding-left: 50px; padding-top: 50px; margin-bottom: 60px;">
    <nav class="navbar navbar-default navbar-fixed-top navbar-inverse">
      <div class="container-fluid">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" style="padding: 10px" href="http://www.algonquincollege.com">
              <img src="Common/img/AC.png" 
                   alt="Algonquin College" style="max-width:100%; max-height:100%;"/>
          </a>    
        </div>
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
          <ul class="nav navbar-nav">
            <li class="active"><a href="Index.php">Home</a></li>
            <li><a href="course_select.php">Course Selection</a></li>
            <li><a href="current_registration.php">Current Registration</a></li>
            <li><a href="./Profile/index.php">Profile</a></li>
            $li          
          </ul>
        </div>
      </div>  
    </nav>
EOF;
?>