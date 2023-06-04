<?php

//include "../Common/header.php";
//include "../Common/footer.php";

// target file
$target_dir = "uploads/";
$target_file = $target_dir . basename($_FILES["fileToUpload"]["name"]);
$uploadOk = 1;
$imageFileType = strtolower(pathinfo($target_file,PATHINFO_EXTENSION));

// Check if image file is a actual image or fake image
if(isset($_POST["submit"])) {
  
    // check image size
    $check = getimagesize($_FILES["fileToUpload"]["tmp_name"]);
    // if file is an image
    if($check !== false)
    {
        echo "File is an image - " . $check["mime"] . ".";
        $uploadOk = 1;
    }
    // if file is not an image
    else
    {
        echo "File is not an image.";
        $uploadOk = 0;
    }
  
    // Check if file already exists
    if (file_exists($target_file))
    {
        echo "Sorry, file already exists.";
        $uploadOk = 0;
    }

    // Check file size in kb
    if ($_FILES["fileToUpload"]["size"] > 50000000)
    {
        echo "Sorry, your file is too large.";
        $uploadOk = 0;
    }

    // Allow certain file formats
    if($imageFileType != "jpg" && $imageFileType != "png" && $imageFileType != "jpeg" && $imageFileType != "gif" )
    {
        echo "Sorry, only JPG, JPEG, PNG & GIF files are allowed.";
        $uploadOk = 0;
    }
    
    
    // Check if $uploadOk is set to 0 by an error
    if ($uploadOk == 0)
    {   echo "Sorry, your file was not uploaded.";  }
    
    // if everything is ok, try to upload file
    else
    {
        // if successful
        if (move_uploaded_file($_FILES["fileToUpload"]["tmp_name"], $target_file))
        {
            $uploadedfile = htmlspecialchars( basename( $_FILES["fileToUpload"]["name"]));
            // echo "The file ". htmlspecialchars( basename( $_FILES["fileToUpload"]["name"])). " has been uploaded.";
            echo "The file $uploadedfile has been uploaded. <br /><br />";
            echo "<img src='./Uploads/$uploadedfile' style='width:130px;height:150px;'>";
            echo "<br /><br /><a href='index.php'>Upload file again</a>";
        
        }
        
        // if there's an error
        else
        {   echo "Sorry, there was an error uploading your file.";  }
    }
}

if (isset($_POST["submit1"]))
{
    // submit multiple files
    $files = array_filter($_FILES['upload']['name']); //Use something similar before processing files.
    //
    // Count the number of uploaded files in array
    $total_count = count($_FILES['upload']['name']);
    
    echo "You have uploaded the following: <br />";
    // Loop through every file
    for( $i=0 ; $i < $total_count ; $i++ )
    {
       //The temp file path is obtained
       $tmpFilePath = $_FILES['upload']['tmp_name'][$i];
       
        //A file path needs to be present
       if ($tmpFilePath != "")
       {
            //Setup our new file path
            $newFilePath = "./uploadFiles/" . $_FILES['upload']['name'][$i];

            //File is uploaded to temp dir
            if(move_uploaded_file($tmpFilePath, $newFilePath))
            {
                //Other code goes here
                $uploadmanyfiles = false; 
                echo "<img src=$newFilePath style='width:130px;height:150px;'> <br /> ";
            }
        }
    }
    echo "<br /><br /><a href='index.php'>Upload file/s again</a>";
    if ($total_count < 1) { $errorMessages = "You must upload at least 1 file."; }
}

?>