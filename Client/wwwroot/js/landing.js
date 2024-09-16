$(document).ready(function () {
    const token = localStorage.getItem('token');
    if (token) {
        window.location.href = "index.html";
    }

    $('#goToRegister').click(function () {
        window.location.href = 'register.html';
    });

    $('#goToLogin').click(function () {
        window.location.href = 'login.html';
    });
});
