// wwwroot/js/auth.js
$(document).ready(function () {
    const token = localStorage.getItem('token');

    if (!token) {
        // Redirect to the login page if no token is found
        alert('You need to log in to access this page.');
        window.location.href = "landing.html";
    }
});
