$(document).ready(function () {
    // Ensure the user is authenticated
    const token = localStorage.getItem('token');
    if (!token) {
        alert('You need to log in to access this page.');
        window.location.href = 'landing.html'; // Redirect to login page
        return;
    }

    $('#logbookForm').submit(function (event) {
        event.preventDefault(); // Prevent form from submitting the default way

        const logbookData = {
            date: $('#date').val(),
            departure: $('#departure').val(),
            departureTime: $('#departureTime').val(),
            arrival: $('#arrival').val(),
            arrivalTime: $('#arrivalTime').val(),
            airplaneType: $('#airplaneType').val(),
            callSign: $('#callSign').val(),
            totalFlightTime: $('#totalFlightTime').val(),
            pilotName: $('#pilotName').val(),
            vfrTakeoff: parseInt($('#vfrTakeoff').val()),
            vfrLanding: parseInt($('#vfrLanding').val()),
            nightTakeoff: parseInt($('#nightTakeoff').val() || 0),
            nightLanding: parseInt($('#nightLanding').val() || 0),
            picTime: $('#picTime').val(),
            dualTime: $('#dualTime').val() || "00:00",
            instructorTime: $('#instructorTime').val() || "00:00",
            description: $('#description').val()
        };

        // AJAX call to POST the logbook entry
        $.ajax({
            url: 'https://localhost:5000/api/logbook', // Adjust the API URL as needed
            type: 'POST',
            contentType: 'application/json',
            headers: {
                'Authorization': 'Bearer ' + token // Include the JWT token for authentication
            },
            data: JSON.stringify(logbookData),
            success: function (response) {
                alert('LogBook entry created successfully!');
                window.location.href = 'list.html'; // Redirect to the list page after success
            },
            error: function (error) {
                alert('Error creating logbook entry: ' + error.responseText);
            }
        });
    });
});
