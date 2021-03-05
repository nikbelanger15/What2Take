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
    var pattern = new RegExp(/[A-Z]{3}[0-9]{4}/);


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
    hello = (checkEmpty("courseCode") && checkEmpty("department") && checkEmpty("difficulty") && checkEmpty("grade") && checkEmpty("comments") && validateInput("courseCode") && validateInput("grade"))
    console.log(hello);
    if ((checkEmpty("courseCode") && checkEmpty("department") && checkEmpty("difficulty") && checkEmpty("grade") && checkEmpty("comments") && validateInput("courseCode") && validateInput("grade")) === false) {
        document.getElementById("submit").innerHTML = "Please correct the highlighted fields.";
        return false;
    } else {
        return true;
    }
}

