function ShowPassword() {
    var x = document.getElementById("password");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}

function editPhoto() {
    var x = document.getElementById("ProfileImage");
    var y = document.getElementById("button");
    y.setAttribute("hidden", "hidden");
    x.type = "file";
}