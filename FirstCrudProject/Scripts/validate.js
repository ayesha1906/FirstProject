function formValidation() {

    var fname = document.getElementById('First_Name');
    var lname = document.getElementById('Last_Name');
    var mname = document.getElementById('Middle_Name');
    var uemail = document.getElementById('Email');
    var uadd = document.getElementById('Address');
    var age = document.getElementById('Age');
    var date = document.getElementById('DoB').value;
    var pass = document.getElementById('Password');

    var format_date = new Date(date);
    var month = format_date.getMonth();
    var day = format_date.getDate();
    var year = format_date.getFullYear();


    if (allLetter(fname) == false) {
        return false;
    }
    else if (middlename(mname) == false) {
        return false;
    }
    else if (allLetter(lname) == false) {
        return false;
    }
    else if (ValidateEmail(uemail) == false) {
        return false;
    }
    else if (CheckPassword(pass) == false) {
        return false;
    }
    else if (validateDate(month, day, year) == false) {
        return false
    }
    else if (allnumeric(age) == false) {
        return false;
    }
    else if (alphanumeric(uadd) == false) {
        return false;
    }
    else
        return true;        
}

function allLetter(uname) {
    var letters = /^[A-Za-z]+$/;
    if (uname.value.match(letters)) {
        return true;
    }
    else {
        alert('User Name must have alphabet characters only');
        uname.focus();
        return false;
    }
}

function middlename(mname) {
    var letters = /^[A-Za-z]+$/;
    if (mname.value.match(letters) || (mname.value) == "") {
        return true;
    }
    else {
        alert('User Name must have alphabet characters only');
        mname.focus();
        return false;
    }
}

function ValidateEmail(uemail) {
    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (uemail.value.match(mailformat)) {
        return true;
    }
    else {
        alert("You have entered an invalid email address!");
        uemail.focus();
        return false;
    }
}

function allnumeric(age) {
    var numbers = /^[0-9]+$/;
    if (age.value.match(numbers)) {
        return true;
    }
    else {
        alert('Please input valid age !');
        age.focus();
        return false;
    }
}

function alphanumeric(uadd) {
    var letters = /^[0-9a-zA-Z]+$/;
    if (uadd.value.match(letters)) {
        return true;
    }
    else {
        alert('User address must have alphanumeric characters only');
        uadd.focus();
        return false;
    }
}



function validateDate(month, day, year) {

    var today = new Date();

    if ((year % 400 == 0) || (year % 4 == 0) &&
        !(year % 100 == 0))
        leap = true;
    else
        leap = false;

    if (year > today.getFullYear()) {
        alert('The year is not valid');
        return false;
    }
    else if ((month < 1) || (month > 12) ||
        (day < 1) || (day > 31))
        return false;

    else if (((month == 4) || (month == 6) ||
        (month == 9) || (month == 11)) && (day == 31)) {
        alert('The date is not valid');
        return false;
    }
    else if (month == 2 && leap && day > 29) {
        alert('The date is not valid');
        return false;
    }
    else if (month == 2 && !leap && day > 28) {
        alert('The date is not valid');
        return false;
    }
    else
        return true;

}

function CheckPassword(pass) {
    var decimal = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,16}$/;
    if (pass.value.match(decimal)) {
        return true;
    }
    else {
        alert('Password must contain atleast 1 uppercase, lowecase , numeric and special character having length 8-16');
        return false;
    }
} 