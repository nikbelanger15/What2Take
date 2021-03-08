// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function checkEmpty(id) {
    var inputControl = document.getElementById(id);
    var code = inputControl.value;

    if (code == "") {
        inputControl.style.borderColor = "red";
        document.getElementById("label_"+id).innerHTML = "Required";
        return false;
    } else if (code == "Select") {
        inputControl.style.borderColor = "red";
        document.getElementById("label_"+id).innerHTML = "Required";
        return false;
    } else {
        inputControl.style.borderColor = "white";
        document.getElementById("label_"+id).innerHTML = "";
        return true;

    }
}

function validateInput(id) {
    var inputControl = document.getElementById(id);
    var code = inputControl.value;
    var pattern = new RegExp(/^[A-Z]{3}[0-9]{4}$/);


    if (id == "courseCode") {
        if (!pattern.test(code)) {
            inputControl.style.borderColor = "red";
            document.getElementById("label_"+id).innerHTML = "Course Code must be 3 capital letters followed by 4 numbers.";
            return false;
        } else {
            inputControl.style.borderColor = "white";
            document.getElementById("label_"+id).innerHTML = "";
            return true;
        } 
    } else if (id == "grade") {
        var initialAmount = inputControl.value;
        if (initialAmount <= 0 || initialAmount > 100) {
            inputControl.style.borderColor = "red";
            document.getElementById("label_"+id).innerHTML = "Grade must be a positive number between 0 and 100.";
            return false;
        } else {
            inputControl.style.borderColor = "white";
            document.getElementById("label_"+id).innerHTML = "";
            return true;
        }
    }
}

function validateFields() {
    if ((checkEmpty("courseCode") && checkEmpty("department") && checkEmpty("grade") && checkEmpty("comments") && validateInput("courseCode") && validateInput("grade")) === false) {
        document.getElementById("submit").innerHTML = "Please correct the highlighted fields.";
        return false;
    } else {
        return true;
    }
}

// slider function
var slider = document.getElementById("difficulty");
var output = document.getElementById("message");
output.innerHTML = "1: Easy A+";

slider.oninput = function() {
    if (slider.value == 1) {
        output.innerHTML = "1: Easy A"
    } else if (slider.value == 2) {
        output.innerHTML = "2: A+ if you attend lectures"
    } else if (slider.value == 3) {
        output.innerHTML = "3: Might need to study a bit"
    } else if (slider.value == 4) {
        output.innerHTML = "4: Lots of work"
    } else if (slider.value == 5) {
        output.innerHTML = "5: Super difficult"
    }
}

// Let user know of submission

// function submitted() {
//     thanks = document.getElementById("thanks");
//     thanks.innerHTML = "Thanks for your submission."

// }


function accordion() {
    var acc = document.getElementsByClassName("accordion");
    var i;

    for (i = 0; i < acc.length; i++) {
        acc[i].addEventListener("click", function() {
          this.classList.toggle("active");
          var panel = this.nextElementSibling;
          if (panel.style.maxHeight) {
            panel.style.maxHeight = null;
          } else {
            panel.style.maxHeight = panel.scrollHeight + "px";
          }
        });
    }
}