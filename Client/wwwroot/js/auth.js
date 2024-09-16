$(document).ready(function () {
    const token = localStorage.getItem('token');

    if (!token) {
        alert('You need to log in to access this page.');
        window.location.href = "landing.html";
    }
});
