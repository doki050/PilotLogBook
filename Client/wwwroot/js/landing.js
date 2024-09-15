$(document).ready(function () {
    // Check if user is already logged in (token exists)
    const token = localStorage.getItem('token');
    if (token) {
        // If token exists, redirect to index.html
        window.location.href = "index.html";
    }

    // Navigate to the Register page
    $('#goToRegister').click(function () {
        window.location.href = 'register.html';
    });

    // Navigate to the Login page
    $('#goToLogin').click(function () {
        window.location.href = 'login.html';
    });
});
