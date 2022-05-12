function setForLoopValues() {

  var min = Number(prompt("Please enter the minimum value: "));
  var max = Number(prompt("Please enter the maximum value: "));
  var increase = Number(prompt("Please enter the incremental value: "));

  for (var i = min; i < max; i+=increase) {
    document.writeln("<br>" + "The value is: " + i);
    console.log("The value is: " + i);
  }

  document.writeln("<br><br>" + "The end. Bye now!");
  console.log();
  console.log("The end. Bye now!");

}

setForLoopValues();
