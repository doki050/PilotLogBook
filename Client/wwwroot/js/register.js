$('#registerForm').submit(function (event) {
    event.preventDefault();
    const userData = {
        username: $('#username').val(),
        email: $('#email').val(),
        password: $('#password').val(),
        firstName: $('#firstName').val(),
        lastName: $('#lastName').val()
    };

    $.ajax({
        url: 'https://172.205.148.14:5000/api/auth/register',
        type: 'POST',
        timeout: 60000,  // 60 seconds
        contentType: 'application/json',
        data: JSON.stringify(userData),
        success: function (response) {
            $('#registerAlert').text('User registered successfully! Redirecting to login...')
                .removeClass('text-danger').addClass('text-success');
            setTimeout(() => window.location.href = 'login.html', 2000);
        },
        error: function (error) {
            $('#registerAlert').text('Error during registration: ' + error.responseText);
        }
    });
});