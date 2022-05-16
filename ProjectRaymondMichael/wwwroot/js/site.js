function checkAge() {
    var age = document.getElementById("age").value;
    if (age < 18) {
        alert("Unforunately, you are too young to venture any farther")
    }
    else {
        alert("Fantastic! Let us begin...");
        $('#prelim').hide();
        $('#main').show();
        $('header').show();
        $('footer').show();
    }
}

function displayInfo() {
    var age = document.getElementById("age").value;
    var name = document.getElementById("name").value;
    var planet = document.getElementById("planet").value;
    document.getElementById("disp").innerHTML = "You are "+age + " years old!<br>" + "Your name is "+ name + "? Strange name...<br> and you're from " + planet + "!<br>That's crazy!";
    $('#dispDiv').show();
}

function clearData() {
    document.getElementById("age").value = "";
    document.getElementById("name").value = "";
    document.getElementById("planet").value = "";
    $('#main').hide();
    $('#dispDiv').hide();
    $('#prelim').show();
    $('header').hide();
    $('footer').hide();
}