// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function CancelOrder(orderId) {
    this.request = new XMLHttpRequest();
    this.request.open("POST", "https://localhost:44389/Order/Cancel");
    this.request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");

    this.request.onreadystatechange = function () {
        if (request.readyState == 4 && request.status == 200)
            document.getElementById(orderId).innerHTML = "YES";
        document.getElementById(orderId).style.color = "red";
        document.getElementById(orderId).style.fontWeight = "600";
    }
    request.send("Id=" + orderId); 
}

