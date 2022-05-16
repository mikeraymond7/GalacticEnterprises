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
    dispLightsaber();
    var age = document.getElementById("age").value;
    var name = document.getElementById("name").value;

    var planet = document.getElementById("planet").value;
    var fav = getJedi();
    var padawan = "";

    var ageStr = "You are " + age + " and ";
    if (age == "") {
        ageStr = ""
    }
    var nameStr = "Hello " + name;
    if (name == "") {
        if (planet != "") {
            nameStr = "You are of planet " + planet;
        }
        else {
            nameStr = "Hello";
        }
    }
    else if (planet != ""){
        nameStr += " of planet "+planet;
    }
   
    if (document.getElementById("padawan").checked) {
        padawan = "Welcome young padawan!<br>";
    }
    document.getElementById("disp").innerHTML = padawan + nameStr + "<br>" + ageStr + fav + " is your favorite Jedi!";
    $('#dispDiv').show();
}

function getJedi() {
    var jedi = document.getElementsByName("jedi");
    var fav = "someone";
    for (var i = 0; i < jedi.length; i++) {
        if (jedi[i].checked) {
            fav = jedi[i].value;
            break;
        }
    }
    return fav;
}

function dispLightsaber() {
    var color = document.getElementById("color").value;
    $('.lightsaber').hide();
    $('#' + color + "lightsaber").show();
}

function clearData() {
    var jedi = document.getElementsByName("jedi");
    for (var i = 0; i < jedi.length; i++) {
        jedi[i].checked = false;
    }

    document.getElementById("padawan").checked = false;
    document.getElementById("age").value = "";
    document.getElementById("name").value = "";
    document.getElementById("planet").value = "";
    $('#main').hide();
    $('#dispDiv').hide();
    $('#prelim').show();
    $('header').hide();
    $('footer').hide();
    $('.lightsaber').hide();
}