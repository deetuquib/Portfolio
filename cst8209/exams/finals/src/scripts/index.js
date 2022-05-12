// $.getJSON("http://127.0.0.1:8080/data.json", (data) => {
//     let items = [];
//     $.each(data.fruits, (index, fruit) => {
//         // items.push("<li id='" + key + "'>" + fruit.name + "</li>");
//         items.push(`<li id='${index}'>${fruit.name}</li>`);
//         console.log(fruit);
//     });

//     $("<ul/>", {
//         class: "my-new-list",
//         html: items.join(""),
//     }).appendTo("body");
// });


/** Below is a class named Testimonial. It contains 4 properties:
 * customer (string)
 * year (number)
 * testimonial (string)
 * newcust (boolean)
 */
class Testimonial {
    constructor(message, customer, year, newcust) {
        // instances
        this.message = message;
        this.customer = customer;
        this.year = year;
        this.newcust = newcust;
    }

    // render -  method that returns the testimonial details
    render() {
        return `<div class="customerTestimonials">
        <strong>Message: </strong> "${this.message}"
        <strong>Customer Name: </strong> ${this.customer}
        <strong>Customer since: </strong> ${this.year}
        <strong>New Customer? </strong> ${this.newcust ? "Yes" : "No"}
        </div>`;
    }
}

/** Testimonial class instances */
const testimonials = [
    new Testimonial(
        "A great place! We buy all our fruits and vegetables from this market because it is almost always local and reasonably priced!",
        "Captain Ray Holt",
        1993,
        false
    ),

    new Testimonial(
        "I'm so thankful my friend referred this place to me. The produce is so fresh and tasty that I don't think we can ever go back to store bought!",
        "Gina Linetti",
        2021,
        true
    ),

    new Testimonial(
        "Excellent customer service!",
        "Amy Santiago",
        2000,
        true
    )
];

/** Populate results */
function renderAllResults(testimonialList) {
    // code block
    const allResultsDiv = document.querySelector("#testimonial");
    allResultsDiv.innerHTML = "";

    // for (let i = 0; i < testimonials.length; i++) {
    //     const allMessage = document.createElement("div");
    //     const allCustomer = document.createElement("h6");
    //     const allYear = document.createElement("h6");
    //     const allBool = document.createElement("h6");

    //     myH2.textContent = testimonials[i].name;
    //     allMessage = "Price per Piece: CA$" + fruits[i].price;
    //     allCustomer.textContent = "Price per Piece: CA$" + fruits[i].price;
    //     allYear.textContent = "Imported From: " + fruits[i].importedFrom;
    //     allBool.textContent = "Benefits: ";

    for(let i = 0; i < testimonials.length; i++) {
        const testimonialDiv = document.createElement("div");
        testimonialDiv.innerHTML = testimonialList[i].render();

        allResultsDiv.appendChild(testimonialDiv)
    }
}

renderAllResults(testimonials);




