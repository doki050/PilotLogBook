$(document).ready(function () {
    const token = localStorage.getItem('token');

    if (!token) {
        alert('You need to log in to view logbook entries.');
        window.location.href = "landing.html";
        return;
    }

    $.ajax({
        url: 'https://172.205.148.14/api/logbook',
        type: 'GET',
        timeout: 60000,  // 60 seconds
        headers: {
            'Authorization': 'Bearer ' + token
        },
        success: function (response) {
            let logbookHtml = '';
            const logbooks = response.content;

            logbooks.forEach(function (logbook, index) {
                const collapsibleId = `logbookContent${index}`;

                logbookHtml += `
                    <div class="logbook-row">
                        <div class="logbook-header">
                            <span>${logbook.date} ${logbook.departureTime} - ${logbook.arrivalTime} ${logbook.pilotName} ${logbook.departure} -> ${logbook.arrival} </span>
                            <button class="toggle-content" data-target="#${collapsibleId}">Tartalom</button>
                        </div>
                        <div id="${collapsibleId}" class="logbook-content">
                            <p>Dátum: ${logbook.date}</p>
                            <p>Indulás Hely: ${logbook.departure}</p>
                            <p>Indulás Idő: ${logbook.departureTime}</p>
                            <p>Érkezés Hely: ${logbook.arrival}</p>
                            <p>Érkezés Idő: ${logbook.arrivalTime}</p>
                            <p>Repülőeszköz: ${logbook.airplaneType}</p>
                            <p>Azonosító: ${logbook.callSign}</p>
                            <p>Teljes Repült idő: ${logbook.totalFlightTime}</p>
                            <p>Pilóta neve PIC: ${logbook.pilotName}</p>
                            <p>VFR felszállás: ${logbook.vfrTakeoff}</p>
                            <p>VFR leszállás: ${logbook.vfrLanding}</p>
                            <p>Éjjel felszállás: ${logbook.nightTakeoff}</p>
                            <p>Éjjel leszállás: ${logbook.nightLanding}</p>
                            <p>Parancsnok PIC idő: ${logbook.picTime}</p>
                            <p>Kétkormányos DUAL idő: ${logbook.dualTime}</p>
                            <p>Oktató idő: ${logbook.instructorTime}</p>
                            <p>Megjegyzés: ${logbook.description}</p>
                        </div>
                    </div>
                `;
            });

            $('#logbookContainer').html(logbookHtml);

            $('.toggle-content').click(function () {
                const targetId = $(this).data('target');
                $(targetId).toggleClass('active');
            });
        },
        error: function (error) {
            alert('Error fetching logbook entries: ' + error.responseText);
        }
    });
});
