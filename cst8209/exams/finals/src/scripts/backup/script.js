const header = document.querySelector("header");
const section = document.querySelector("section");

/** OBTAINING THE JSON */

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
    const timeJSON = request.response;
    populateHeader(timeJSON);
    showFruits(timeJSON);
    console.log(timeJSON);
};

/** POPULATING THE HEADER */

function populateHeader(obj) {
    const myH1 = document.createElement("h1");
    myH1.textContent = obj["storeName"];
    header.appendChild(myH1);

    const myPara = document.createElement("p");
    myPara.textContent = "Address: " + obj["city"] + ", " + obj["province"];
    header.appendChild(myPara);
}

/** CREATING THE WIZARD INFORMATION CARDS */

function showFruits(obj) {
    const fruits = obj["fruits"];

    for (let i = 0; i < fruits.length; i++) {
        const myArticle = document.createElement("article");
        const myH2 = document.createElement("h2");
        const myPara1 = document.createElement("div");
        const myPara2 = document.createElement("p");
        const myPara3 = document.createElement("p");
        const myList = document.createElement("ul");

        myH2.textContent = fruits[i].name;
        myPara1.textContent = '<img src="' + fruits[i].image + '">';
        myPara2.textContent = "Imported From; " + fruits[i].importedFrom;
        myPara3.textContent = "Benefits: ";

        const benefits = fruits[i].benefits;
        for (let j = 0; j < benefits.length; j++) {
            const listItem = document.createElement("li");
            listItem.textContent = benefits[j];
            myList.appendChild(listItem);
        }

        myArticle.appendChild(myH2);
        myArticle.appendChild(myPara1);
        myArticle.appendChild(myPara2);
        myArticle.appendChild(myPara3);
        myArticle.appendChild(myList);

        section.appendChild(myArticle);
    }
}

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
