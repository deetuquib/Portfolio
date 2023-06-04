<?php
function connect(){
    $dbConnection=parse_ini_file("./config/Final.ini");
    extract($dbConnection);
    
    try {
        //$dsn = "mysql:host=$servername;port=$port;dbname=$dbname; charset=UTF8;";
        $options = [PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION];
        return new PDO($dsn, $user, $password, $options);
    } catch (PDOException $e) {
        die ("Connection failed: " . $e->getMessage());
    }
    return null;
}
