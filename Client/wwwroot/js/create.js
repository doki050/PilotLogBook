$(document).ready(function () {
    const token = localStorage.getItem('token');
    if (!token) {
        alert('You need to log in to access this page.');
        window.location.href = 'landing.html';
        return;
    }

    $('#logbookForm').submit(function (event) {
        event.preventDefault();

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

        $.ajax({
            url: 'https://20.71.230.146/api/logbook',
            timeout: 60000,  // 60 seconds
            type: 'POST',
            contentType: 'application/json',
            headers: {
                'Authorization': 'Bearer ' + token
            },
            data: JSON.stringify(logbookData),
            success: function (response) {
                alert('LogBook entry created successfully!');
                window.location.href = 'list.html';
            },
            error: function (error) {
                alert('Error creating logbook entry: ' + error.responseText);
            }
        });
    });
});
