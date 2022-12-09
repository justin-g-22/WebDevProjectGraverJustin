function homeDisplay() {
    var s = document.getElementById("curiousCheck");
    if (s.checked == true) {
        document.getElementById("stuff").style.display = "block";
    }
    else {
        document.getElementById("stuff").style.display = "none";
    }
}

function displayIllness() {
    var a = document.getElementsByName("patientAge");
    var s = document.getElementById("symptom");
    var age, value, result;
    for (i = 0; i < a.length; i++) {
        if (a[i].value == "children")
            age = "5 to 20 ";
        else if (a[i].value == "adults")
            age = "25 to 40 ";
        else if (a[i].value == "older adults")
            age = "40 to 60 ";
        else
            age = "65 and older ";
        if (a[i].checked) {
            value = a[i].value;
            break;
        }
    }
        if (s.value == "joint pain" && value == "seniors") {
            result = "gout."
        }
        else if (s.value == "joint pain" && value == "children") {
            result = "arthritis."
        }
        else if (s.value == "joint pain" && value == "adults") {
            result = "osteoarthritis."
        }
    else if (s.value == "joint pain" && value == "older adults") {
            result = "osteoarthritis."
        }
        else if (s.value == "sore throat" && value == "children") {
            result = "step throat."
        }
        else if (s.value == "sore throat" && value == "adults") {
            result = "common cold."
        }
        else if (s.value == "sore throat" && value == "older adults") {
            result = "common cold."
        }
        else if (s.value == "sore throat" && value == "seniors") {
            result = "common cold."
        }
        else if (s.value == "skin rash" && value == "adults") {
            result = "smallpox."
        }
        else if (s.value == "skin rash" && value == "older adults") {
            result = "smallpox."
        }
        else if (s.value == "skin rash" && value == "seniors") {
            result = "smallpox."
        }
        else if (s.value == "skin rash" && value == "children") {
            result = "smallpox."
        }
        else if (s.value == "chronic coughing" && value == "children") {
            result = "common cold."
        }
        else if (s.value == "chronic coughing" && value == "adults") {
            result = "bronchitis."
        }
        else if (s.value == "chronic coughing" && value == "older adults") {
            result = "bronchitis."
        }
        else if (s.value == "chronic coughing" && value == "seniors") {
            result = "bronchitis."
        }
        else if (s.value == "fatigue" && value == "older adults") {
            result = "fever."
        }
        else if (s.value == "fatigue" && value == "seniors") {
            result = "fever."
        }
        else if (s.value == "fatigue" && value == "children") {
            result = "fever."
        }
        else if (s.value == "fatigue" && value == "adults") {
            result = "fever."
        }
    document.getElementById("diag").style.display = "block";
    document.getElementById("PD").innerHTML = "Based on the details you provided, the paient is diagnosed with " + result + " It is common in ages " + age + "and characterized  by " +s.value + ".";
}