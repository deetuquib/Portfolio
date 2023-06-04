<?php

//errors
error_reporting (E_ALL ^ E_NOTICE); 

// include header and footer
include("upload.php");
?>


<!DOCTYPE html>
<html>
<body>

<form action="upload.php" method="post" enctype="multipart/form-data">
  Select image to upload:
  <input type="file" name="fileToUpload" id="fileToUpload">
  <input type="submit" value="Upload Image" name="submit">
  <?php $errorMessage ?>
  
  <br /><br /><br />
  
  <!-- submit multiple files -->
  Submit multiple files:
  <input name="upload[]" type="file" multiple="multiple" />
  <input type="submit" value="Upload Image" name="submit1">
  <?php $errorMessages ?>
  
</form>

</body>
</html>
