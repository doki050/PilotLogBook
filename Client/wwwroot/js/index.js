$(document).ready(function () {
    const token = localStorage.getItem('token');
    const firstName = localStorage.getItem('firstName');
    const lastName = localStorage.getItem('lastName');

    if (!token) {
        alert('You need to log in to access this page.');
        window.location.href = "landing.html";
    } else if (firstName && lastName) {
        $('#user-name').text(`${firstName} ${lastName}`);
    } else {
        console.error('First name or last name not found in localStorage');
    }
});