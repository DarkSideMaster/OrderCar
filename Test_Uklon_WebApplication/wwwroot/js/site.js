// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var request = new XMLHttpRequest();

function CancelChangeStatus(orderId) {

    request.open("POST", "https://localhost:44389/Orders/Cancel");
    request.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');

    request.onreadystatechange = function() {
        if (request.readyState == 4 && request.status == 200)
            document.getElementById(orderId).innerHTML = "YES";
    }

    request.send(orderId);
}


