<?php
    session_start();
    
    // unset($_SESSION["studentSN"]);
    session_destroy(); // #8 destroy session
    
    header("Location:Login.php");
     
?>