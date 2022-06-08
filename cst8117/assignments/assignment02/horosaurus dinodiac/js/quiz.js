
function startQuiz() {
  hideZodiac();
  // hides start button
  // startButton.classList.add('hide');

  // randomizes question index by giving a positive or negative value at random 
  shuffledQuestions = questions.sort(() => Math.random() - .5);

  currentQuestionIndex = 0;

  // makes questions visible 
  questionContainerElement.classList.remove('hide');

  setNextQuestion()

}

function setNextQuestion() {

  resetState()

  showQuestion(shuffledQuestions[currentQuestionIndex])
}

function resetState() {

  while (answers.firstChild) {
    answers.removeChild(answers.firstChild)
  }

}

function showQuestion(question) {

  questionText.innerText = question.question

  question.answers.map(answer => {
    const button = document.createElement('button')
    button.innerText = answer.text
    button.classList.add('btn-big')
    button.dataset.tally = answer.tallyValue;
    button.addEventListener('click', selectAnswer);
    answers.appendChild(button);
  })
}


function selectAnswer(e) {

  const selectedButton = e.target

  const tally = selectedButton.dataset.tally;

  totalTally.push(tally);

  if (currentQuestionIndex == shuffledQuestions.length - 1) {
    let sign = zSign.value;
    let zodiacElement = finalScore(totalTally);
    questionText.innerText = zodiacElement;

    displayDinodiac(zodiacData, sign, zodiacElement);
    
    changeElementClass(zodiacElement);
    hideQuiz();
  }

}

function finalScore(someArray) {//begin function

  //initialize the correct variable
  var earth = 0;
  var air = 0;
  var water = 0;
  var fire = 0;

  var max = 0;
  var result = "";

  
  for(var i = 0; i < someArray.length; i++ ){//begin for loop

    //if the value equals air
    if(someArray[i] === "air"){

      //increment the correct variable
      air++;

    }
    //if the value equals water
    if(someArray[i] === "water"){

      //increment the correct variable
      water++;

    }
    //if the value equals earth
    if(someArray[i] === "earth"){

      //increment the correct variable
      earth++;

    }
    //if the value equals fire
    if(someArray[i] === "fire"){

      //increment the correct variable
      fire++;

    }

    if (fire > max) {
      result = "fire";
      max = fire;
    }
    if (air > max) {
      result = "air";
      max = air;
    }
    if (water > max) {
      result = "water";
      max = air;
    }
    if (earth > max) {
      result = "earth";
      max = earth;
    }

  }//end for loop

  return result;

} //end function

