function getNumber(){

  // Prompting user to enter a number
  var choice = prompt("Hello there! Please enter a number between 0 and 100: ");
  var index = 0;

  // While loop condition
  while (index < 100) {
    // Code block
    document.writeln("<br> The value is: " + "" + index);
    console.log("The value is: " + index);
    // Increment
    index += 10;
  }

  // After loop ends
  document.writeln("<br> You entered " + choice + "! :-)");
  console.log("You entered " + choice + "! :-)");

}

getNumber();
