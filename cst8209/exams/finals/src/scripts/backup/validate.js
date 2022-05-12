//validate module

function validate(e) {
    e.preventDefault();

    var valid = true;

    //display warning if firstName is not entered
    if (profile.firstName.value === "") {
        document.querySelector("#fNameError").textContent =
            "*Please enter your First Name*";
        valid = false;
    }

    //display warning if lastName is not entered
    if (profile.lastName.value == "") {
        document.querySelector("#lNameError").textContent =
            "*Please enter your Last Name*";
        valid = false;
    }

    //display warning if Address is not entered
    if (profile.address1.value == "") {
        document.querySelector("#address1Error").textContent =
            "*Please enter your address*";
        valid = false;
    }

    //display warning if City is not entered
    if (profile.city.value == "") {
        document.querySelector("#cityError").textContent =
            "*Please enter your City*";
        valid = false;
    }

    //display warning if Province is not selected
    if (profile.province.options.selectedIndex === 0) {
        valid = false;
        document.querySelector("#provinceError").textContent =
            "*Select your Province*";
    }

    // //display warning if Country is not selected
    // if(profile.country.options.selectedIndex === 0){
    //     valid = false;
    //     document.querySelector('#countryError').textContent="*Select your Country*";
    // }

    if (valid) {
        alert("Thank you!");
    }

    return valid;
}
