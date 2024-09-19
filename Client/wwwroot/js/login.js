        $('#loginForm').submit(function (event) {
            event.preventDefault();
            const loginData = {
                username: $('#username').val(),
                password: $('#password').val()
            };

            $.ajax({
                url: 'https://172.205.148.14/api/auth/login',
                type: 'POST',
                timeout: 60000,  // 60 seconds
                contentType: 'application/json',
                data: JSON.stringify(loginData),
                success: function (response) {
                    console.log('Login response:', response);

                    if (response.firstName && response.lastName) {
                        localStorage.setItem('token', response.token); 
                        localStorage.setItem('firstName', response.firstName);
                        localStorage.setItem('lastName', response.lastName);
                    } else {
                        console.error('First name or last name missing from the login response');
                    }

                    $('#loginAlert').text('Login successful! Redirecting...').css('color', 'green');
                    setTimeout(() => window.location.href = 'index.html', 2000);
                },
                error: function (error) {
                    $('#loginAlert').text('Error during login: ' + error.responseText);
                }
            });
        });