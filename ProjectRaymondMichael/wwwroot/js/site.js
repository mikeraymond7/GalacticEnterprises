function checkAge() {
    var age = document.getElementById("age").value;
    if (age < 18) {
        alert("Unforunately, you are too young to venture any farther")
    }
    else {
        alert("Fantastic! Let us begin...");
        $('#prelim').hide();
        $('#main').show();
    }
}

function getItems() {
    var budget = document.getElementById("budget").value;
    if (budget < 1) {
        budget = 0;
    }
    alert(budget);
}

