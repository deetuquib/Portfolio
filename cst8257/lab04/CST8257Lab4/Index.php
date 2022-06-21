<?php
// put your code here
session_start();
include("./common/header.php");
print <<<EOS
    <div class="container mt-3">
        <h1>Welcome to Algonquin Bank!</h1>
        <h6>
            Algonquin Bank is Algonquin College Students' most loved bank. We provide a set of tools for Algonquin College students to manage their finances.
        </h6>
        <br />
        <a href="DepositCalculator.php"><h5>Deposit Calculator</h5></a>
    </div>
EOS;
include('./common/footer.php');
