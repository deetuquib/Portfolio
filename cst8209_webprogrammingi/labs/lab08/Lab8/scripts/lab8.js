$(document).ready(function () {
    // A.
    // document.querySelector("h1").innerText = "Lab08";
    $("h1").text("Lab08");

    // B.
    // document.querySelector("#header").innerHTML = "<h3>Working with jQuery</h3>";
    $("#header").html("<h3>Working with jQuery</h3>");

    // C.
    // const nodes = document.querySelectorAll("[type='button'");
    // for (let i = 0; i < nodes.length; i++) {
    //     nodes[i].classList.add("btn-background");
    // }
    $("[type='button']").each(function (index) {
        $(this).addClass("btn-background");
    });

    // D.
    // document.querySelector("#buttons").classList.add("red-border");
    $("#buttons").addClass("red-border");

    // E.
    // const nodes = document.querySelectorAll("p");
    // for (let i = 0; i < nodes.length; i++) {
    //     nodes[i].classList.add("blue");
    // }
    $("p").each(function (index) {
        $(this).addClass("blue");
    });

    // F.
    // document.querySelector("#first").addEventListener("click", function () {
    //     document.querySelector("p").classList.add("green-border");
    // });
    $("#first").on("click", function () {
        $("p").first().addClass("green-border");
    });

    // G.
    // document.querySelector("#last").addEventListener("click", function () {
    //     const nodes = document.querySelectorAll("p");
    //     if (nodes.length > 0) {
    //         nodes[nodes.length - 1].classList.add("orange-border");
    //     }
    // });
    $("#last").on("click", function () {
        $("p").last().addClass("orange-border");
    });

    // H.
    // document.querySelector("#prev").addEventListener("click", function () {
    //     document
    //         .querySelector("#para3")
    //         .previousElementSibling.classList.add("purple-border");
    // });
    $("#prev").on("click", function () {
        $("#para3").prev().addClass("purple-border");
    });

    // I.
    // document.querySelector("#next").addEventListener("click", function () {
    //     document
    //         .querySelector("#para2")
    //         .nextElementSibling.classList.add("yellow-border");
    // });
    $("#next").on("click", function () {
        $("#para2").next().addClass("yellow-border");
    });

    // J.
    // document.querySelector("#remove").addEventListener("click", function () {
    //     document.querySelector("#footer").remove();
    // });
    $("#remove").on("click", function () {
        $("#footer").remove();
    });
});
