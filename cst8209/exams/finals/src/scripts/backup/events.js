//form element events

//remove warning if firstName has input
document.querySelector("#fName").addEventListener("blur", function () {
    if (this.value !== "") {
        fNameError.textContent = "";
    }
});

//remove warning if lastName has input
document.querySelector("#lName").addEventListener("blur", function () {
    if (this.value !== "") {
        lNameError.textContent = "";
    }
});

//remove warning if Address has input
document.querySelector("#address1").addEventListener("blur", function () {
    if (this.value !== "") {
        address1Error.textContent = "";
    }
});

//remove warning if City has input
document.querySelector("#city").addEventListener("blur", function () {
    if (this.value !== "") {
        cityError.textContent = "";
    }
});

//remove warning if Province is selected
document.querySelector("#province").addEventListener("click", function () {
    if (profile.province.options.selectedIndex !== 0) {
        provinceError.textContent = "";
    }
});

// //remove warning if Country is selected
// document.querySelector('#country').addEventListener("click", function(){
//     if(profile.country.options.selectedIndex !== 0){
//         countryError.textContent = "";
//     }
// });

// Add an event to the form on submit to validate input
document.profile.addEventListener("submit", validate);

// Add an event to the form to reset
document.profile.addEventListener("reset", resetForm);
function resetForm(e) {
    e.target.reset();
    fNameError.textContent = "";
    lNameError.textContent = "";
    address1Error.textContent = "";
    cityError.textContent = "";
    provinceError.textContent = "";
    countryError.textContent = "";
}
