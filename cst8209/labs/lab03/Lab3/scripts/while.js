// Prompting user to enter a number
var choice = prompt("Hello there! Please enter a number between 0 and 100: ");
var index = 0;

// While loop condition
while (index < choice) {
  // Code block
  document.writeln("The value is: " + index + "</br>");
  console.log("The value is: " + index);
  // Increment
  index += 10;
}

// After loop ends
document.writeln("</br> You entered " + choice + "! :-)");
console.log("You entered " + choice + "! :-)");
