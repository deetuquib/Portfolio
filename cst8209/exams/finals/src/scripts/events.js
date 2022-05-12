/** OBTAINING THE JSON */

const header = document.querySelector("header");
const section = document.querySelector("section");

/**
 * 1
 * store the URL of the JSON we want to retrieve in a variable */
let requestURL = "data.json";

/**
 * 2
 * create a new request object instance from the XMLHttpRequest constructor, using the new keyword
 */
let request = new XMLHttpRequest();

/**
 * 3
 * open the request using the open() method
 */
request.open("GET", requestURL);

/**
 * 4
 * set the responseType to JSON, so that XHR knows that the server will be returning JSON
 * this should be converted behind the scenes into a JavaScript object
 * send the request with the send() method
 */
request.responseType = "json";
request.send();

/**
 * 5
 * wait for the response to return from the server, then deal with it
 */
request.onload = function () {
    const dataJSON = request.response;
    populateHeader(dataJSON);
    showFruits(dataJSON);
    console.log(dataJSON);

    var fruitGrid = document.querySelectorAll(".grid-item");
    for (let i = 0; i < dataJSON["fruits"].length; i++) {
        var fruitIndex = fruitGrid[i*5];
        var fruitImg = document.createElement("img");
        fruitImg.src = `${dataJSON["fruits"][i]["image"]}`
        fruitIndex.appendChild(fruitImg);

        var costIndex = fruitGrid[i*5+1];
        costIndex.innerText = `$${dataJSON["fruits"][i]["price"]}`

        var quantity = fruitGrid[i*5+2];
        quantity.innerText = "0"

        var subtotal = fruitGrid[i*5+4];
        subtotal.innerText = "$0"
    }
};



/** -------------------------------------------------------------------- */
/** POPULATING THE HEADER */

function populateHeader(obj) {
  const myH1 = document.createElement("h1");
  myH1.textContent = obj["storeName"];
  header.appendChild(myH1);

  const myPara = document.createElement("h5");
  myPara.textContent = "Address: " + obj["city"] + ", " + obj["province"];
  header.appendChild(myPara);
}

/** CREATING THE WIZARD INFORMATION CARDS */

function showFruits(obj) {
  const fruits = obj["fruits"];

  for (let i = 0; i < fruits.length; i++) {
    const myArticle = document.createElement("article");
    const myH2 = document.createElement("h2");
    const img = document.createElement("img");
    const myPara1 = document.createElement("p");
    const myPara2 = document.createElement("p");
    const myPara3 = document.createElement("p");
    const myList = document.createElement("ul");

    myH2.textContent = fruits[i].name;
    img.src = fruits[i].image;
    myPara1.textContent = "Price per Piece: CA$" + fruits[i].price;
    myPara2.textContent = "Imported From: " + fruits[i].importedFrom;
    myPara3.textContent = "Benefits: ";

    const benefits = fruits[i].benefits;
    for (let j = 0; j < benefits.length; j++) {
      const listItem = document.createElement("li");
      listItem.textContent = benefits[j];
      myList.appendChild(listItem);
    }

    myArticle.appendChild(myH2);
    myArticle.appendChild(img);
    myArticle.appendChild(myPara1);
    myArticle.appendChild(myPara2);
    myArticle.appendChild(myPara3);
    myArticle.appendChild(myList);

    section.appendChild(myArticle);
  }
}


/** ----------------------------------------------------------------------- */
/** CHECK CONNECTION */
httpRequest = new XMLHttpRequest();
httpRequest.onreadystatechange = function () {
  // Process the server response here.
  if (httpRequest.readyState === XMLHttpRequest.DONE) {
    if (httpRequest.status === 200) {
      console.log("Successful.");
    } else {
      console.log("There was a problem with the request. ");
    }
  } else {
    console.log("Not ready yet.");
  }
};

httpRequest.open("GET", "data.json", true);
httpRequest.send();

/** ----------------------------------------------------------------------- */
// ADD OR SUBTRACT QUANTITY


// bananaSubtotal = 2.45 * bananaQuantity
// appleSubtotal = 2.45 * Quantity
// watermelonSubtotal = 2.45 * Quantity
// grapesSubtotal = 2.45 * Quantity

// let clickImage = plusFruit[i].querySelector("img");
// clickImage.addEventListener("click", function() {
//     let itemAmount = parseInt(clickImage[i*2+2].textContent);
//     let itemPrice = data["fruits"][i]["price"];
//     let itemSubtotal =
// });

// class CalculateFruit {
//     constructor(price, plus, minus, subtotal) {
//         this.price = price;
//         this.plus = plus;
//         this.minus = minus;
//         this.subtotal = subtotal;
//     }

//     displayTotal() {
//         let price_line = data["fruits"][i]["price"];
//         let subtotal_line = this.subtotal + price_line;
//         return subtotal_line
//     }
// }

//     addFruit() {
//         this.fruitSubtotal = "";
//         this.operation = undefined;
//     }

//     subtractFruit() {
//         this.fruitSubtotal = "";
//         this.operation = undefined;
//     }

//     appendNumber(number) {
//         this.fruitSubtotal
//     }

// let bananaCost = document.querySelector("bananaCost");
// let subTotal;
// let addFruit = subTotal + bananaCost;
// let subtractFruit = subTotal - bananaCost;

// function updateCartTotal() {
//     var cartItemContainer = document.getElementsByClassName('cart-items')[0]
//     var cartRows = cartItemContainer.getElementsByClassName('cart-row')
//     var total = 0
//     for (var i = 0; i < cartRows.length; i++) {
//         var cartRow = cartRows[i]
//         var priceElement = cartRow.getElementsByClassName('cart-price')[0]
//         var quantityElement = cartRow.getElementsByClassName('cart-quantity-input')[0]
//         var price = parseFloat(priceElement.innerText.replace('$', ''))
//         var quantity = quantityElement.value
//         total = total + (price * quantity)
//     }
//     total = Math.round(total * 100) / 100
//     document.getElementsByClassName('cart-total-price')[0].innerText = '$' + total
// }














































/** ----------------------------------------------------------------------- */
/** VALIDATE INPUT */

// Add an event to the form on submit to validate input
document.profile.addEventListener("submit", validate);

// Add an event to the form to reset
document.profile.addEventListener('reset', resetForm);
function resetForm(e) {
    e.target.reset();
    nameError.textContent = "";
    address1Error.textContent = "";
    provinceError.textContent = "";
    phoneNumberError.textContent = "";
    preferredDeliveryDateError.textContent = "";
    contactModeError.textContent = "";
};

/** VALIDATE MODULE */

function validate(e){

    e.preventDefault();

    var valid=true;

    //display warning if firstName is not entered
    if(profile.name.value === ""){
    document.querySelector('#nameError').textContent="*Please enter your First Name*";
        valid = false;
    }

    //display warning if Address is not entered
    if(profile.address1.value == ""){
        document.querySelector('#address1Error').textContent="*Please enter your address*";
        valid=false;
    }

    //display warning if Province is not selected
    if(profile.province.value === ""){
        valid = false;
        document.querySelector('#provinceError').textContent="*Please select your Province*";
    }

    //display warning if phoneNumber is not entered
    if(profile.phoneNumber.value === ""){
        document.querySelector('#phoneNumberError').textContent="*Please enter your Phone Number*";
            valid = false;
        }

    //display warning if phoneNumber is not entered
    if(profile.preferredDeliveryDate.value === ""){
        document.querySelector('#preferredDeliveryDateError').textContent="*Please enter your Preferred Delivery Date*";
            valid = false;
        }

    //display warning if contactMode is not selected
    if(profile.contactMode[1].checked == false && profile.contactMode[2].checked == false && profile.contactMode[3].checked == false) {
        valid = false;
        document.querySelector('#contactModeError').textContent="*Please select how you want us to contact you.*";
    }

    if(valid){
        alert("Thank you!");
        e.target.reset();
        nameError.textContent = "";
        address1Error.textContent = "";
        provinceError.textContent = "";
        phoneNumberError.textContent = "";
        preferredDeliveryDateError.textContent = "";
        contactModeError.textContent = "";
    }
    return valid;
};


/** ----------------------------------------------------------------------- */
/** REMOVE WARNING ON INPUT */
//form element events

//remove warning if firstName has input
document.querySelector("#name").addEventListener("blur", function () {
    if (this.value !== "") {
        nameError.textContent = "";
    }
});

//remove warning if Address has input
document.querySelector("#address1").addEventListener("blur", function () {
    if (this.value !== "") {
        address1Error.textContent = "";
    }
});

//remove warning if Province is selected
document.querySelector("#province").addEventListener("click", function () {
    if (profile.province.options.selectedIndex !== 0) {
        provinceError.textContent = "";
    }
});

//remove warning if Phone Number has input
document.querySelector("#phoneNumber").addEventListener("blur", function () {
    if (this.value !== "") {
        phoneNumberError.textContent = "";
    }
});

//remove warning if Preferred Delivery Date has input
document.querySelector("#preferredDeliveryDate").addEventListener("blur", function () {
    if (this.value !== "") {
        preferredDeliveryDateError.textContent = "";
    }
});


// Add an event to the form on submit to validate input
document.profile.addEventListener("submit", validate);

// Add an event to the form to reset
document.profile.addEventListener("reset", resetForm);
function resetForm(e) {
    e.target.reset();
    nameError.textContent = "";
    address1Error.textContent = "";
    provinceError.textContent = "";
    phoneNumberError.textContent = "";
    preferredDeliveryDateError.textContent = "";
    contactModeError.textContent = "";
}





// (function () {
//     // TODO: For reference only. Please delete before submitting.
//     // firstName
//     // lastName
//     // firstNameError
//     // lastNameError
//     // address1
//     // address1Error
//     // address2
//     // postalCode
//     // postalCodeError
//     // city
//     // cityError
//     // province
//     // provinceError
//     // phoneNumber
//     // preferredDeliveryDate
//     // contactMode1
//     // contactMode2
//     // contactMode3
//     // subscribeMailingList
//     // deliveryInstructions
//     // btnSubmit
//     // btnReset

//     $(() => {
//         const validate = (e) => {
//             e.preventDefault();

//             alert("Hello");
//         };
//     });
// })();
