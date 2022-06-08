const splashCard = document.querySelector('.welcome'); // main page section
const enterButton = document.querySelector('.js-btn-enter'); // main page enter button

const getInfo = document.querySelector('.get-info'); // form submit section

const zodiac = document.querySelector('.zodiac'); // zodiac section
const zodiacContent = document.querySelector('.zodiac-info'); // zodiac section

const dinodiacSection = document.querySelector('.dinodiac');
const dinodiacContent = document.querySelector('.dinodiac > .card-content');
const noButton = document.querySelector('.js-btn-no');

const zSign = document.querySelector('.zodiac-sign');
const quiz = document.querySelector('.quiz-pad');
const questionContainerElement = document.querySelector('.quiz-container'); // quiz element
const startButton = document.querySelector('.js-btn-start-quiz'); // start quiz button
const questionText = document.querySelector('.questionText'); // text for the question
const answers = document.querySelector('.answer-buttons'); // the answer buttons
const restartButton = document.querySelector('.js-btn-restart-quiz');

const dinoTypes = document.querySelector('.dino-types');
const dinoButtonsContainer = document.querySelectorAll('.dino-item');

const dinoDesc = document.querySelectorAll('.about-dinosaur');

const restartPage = document.querySelectorAll('.restart-page')

// GLOBAL VARIABLES

// quiz
let shuffledQuestions, currentQuestionIndex
let totalTally = [];

// handle submit
function handleSubmit(e) {
  let zodiacInfo = [];
  let zodiDate = [];
  e.preventDefault();

  console.log('submitted');

  setCookies(e);
  let birthday = e.currentTarget.userbirthday.value;
  let realDate = new Date(birthday);

  let zodiacDate = getZodiacDate(realDate);
  console.log(zodiacDate);
  zodiDate.push(zodiacDate);
  console.log(zodiDate);
  
  zodiacInfo.push(zodiacDate);
  console.log(zodiacInfo);

  setZodiacSign(zodiDate);
  displayZodiac(zodiacInfo);

  hideInfoForm();
}

function resetForm() {
  userInfo.reset();
}

function setZodiacSign(info) {
  console.log(info);

  let val = info.map(item => item.zodiacSign.name)
  console.log(val[0]);
  zSign.value = val[0];  

}

function setCookies(e) {
  // store name in cookie
  let name = e.currentTarget.username.value;

  document.cookie = 'name=' + name;

  // store birthdate in cookie
  let birthday = e.currentTarget.userbirthday.value;

  document.cookie = 'birthdayType=' + typeof birthday;

  document.cookie = 'birthday=' + birthday;
}

function getZodiacDate(birthDate){

  return zodiacData.find( d => {
    const birthYear = birthDate.getFullYear();
    const startDate = new Date(birthYear, d.basics.startMonth -1, d.basics.startDay);
    const endDate = new Date(birthYear, d.basics.endMonth -1, d.basics.endDay);
    return birthDate >= startDate && birthDate <= endDate;
  });
}

// DOM change functions

function displayZodiac(resArray) {
  let zodHTML = resArray.map((item) => { 
      return `<img src="${item.zodiacSign.imgPath}" class="circle-img">
      <div class="card-content">
          <h2 class="mid-title">${item.zodiacSign.name}</h2>
          <p>${item.zodiacSign.description}</p>
      </div>`
  }).join('');

  zodiacContent.innerHTML = zodHTML;

}


function displayDinodiac(resArray, searchTermA, searchTermB ) {
  console.log(resArray, searchTermA, searchTermB);

  let dinoInfo = resArray.map((item) => {
    
    const dinoElement = item.dinodiac.find(item => item.element.includes(searchTermB));

    return dinoElement;
  });

  let dino = dinoInfo.find(item => item.name.includes(searchTermA));

  console.log(dino.name);
  
  let dinoHtml =  `<img src="${dino.imgPath}" class="circle-img">
    <h2>${dino.name}</h2>
    <p>${dino.description}</p>`;

    dinodiacContent.innerHTML = dinoHtml;
  
}

// change class functions

function hideWelcome(e) {
  splashCard.classList.add('hide');
  getInfo.classList.remove('hide');
}

function hideInfoForm() {
  getInfo.classList.add('hide');
  zodiac.classList.remove('hide');
}

function hideZodiac() {
  zodiac.classList.add('hide');
  quiz.classList.remove('hide');
}

function hideQuiz() {
  quiz.classList.add('hide');
  dinodiacSection.classList.remove('hide');
}

function hideDinodiac(e) {

  console.log(e.currentTarget.classList.value.includes('restart-quiz'));
  if (e.currentTarget.classList.value.includes('restart-quiz')) {
    dinodiacSection.classList.add('hide');
    startQuiz();
  } else {
    dinodiacSection.classList.add('hide');
    dinoTypes.classList.remove('hide');
  }

}

function  changeElementClass(zodiacElement) {

  let section = document.querySelectorAll(".main-card");

  if (zodiacElement === "fire") {
    $(".main-card").addClass("fire");
    
    // section.classList.add('fire');
    // section.classList.remove('hide');

  }
  if (zodiacElement === "air") {
    $(".main-card").addClass("air");

    // section.classList.add('air');
    // section.classList.remove('hide');

  }
  if (zodiacElement === "earth") {
    $(".main-card").addClass("earth");

    // section.classList.add('earth');
    // section.classList.remove('hide');

  }
  if (zodiacElement === "water") {
    $(".main-card").addClass("water");

    // section.classList.add('water');
    // section.classList.remove('hide');

  }

}

function hideDinoTypes(e) {
  let dinoClasses = ['trex', 'titan', 'mosa', 'quetz'];
  let classSnip = e.currentTarget.classList.value;

  dinoClasses.forEach((dino) => {
    if (classSnip.includes(dino)) {
      dinoDesc.forEach(desc => {
        if (desc.classList.value.includes(dino)) {
          dinoTypes.classList.add('hide');
          desc.classList.remove('hide');
        }
      });
    } 
  });
}

// event listeners
enterButton.addEventListener('click', hideWelcome);
document.userInfo.addEventListener("submit", handleSubmit);
noButton.addEventListener('click', hideDinodiac);
dinoButtonsContainer.forEach((btn) => btn.addEventListener('click', hideDinoTypes));
restartPage.forEach((link) => link.addEventListener('click', (e) => {
  e.preventDefault();
  dinoDesc.forEach((desc) => {
    desc.classList.add('hide');
    splashCard.classList.remove('hide');
    resetForm();
  });
  console.log('clicked')
}));

// quiz listeners
startButton.addEventListener('click', startQuiz);
restartButton.addEventListener('click', hideDinodiac);

answers.addEventListener('click', () => {
  currentQuestionIndex++;
  setNextQuestion();
});