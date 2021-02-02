//$(document).ready(function () {

//});


function redirectToDisplay() {
    var currentUrl = (window.location.protocol) + "//" + (window.location.hostname) + (window.location.port != "" ? ":" + window.location.port : "") + "/";
    var usernameValue = document.getElementById("username").value;
    var passwordValue = document.getElementById("password").value;
    var link = currentUrl + "Home/RedirectToDisplay?username=" + usernameValue + "&password=" + passwordValue;


    $.ajax({
        url: link,
        cache: false,
        type: "GET",
        crossdomain: false,
        dataType: "json",
        ContentType: "application/json; charset=utf-8",
        success: function (response) {
         
        },
        error: function (error) {
            console.log(error);
        }
    });
}