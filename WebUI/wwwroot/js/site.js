window.onload = function () {
    $('.selectpicker').selectpicker();

    var date = new Date();
    date.setDate(date.getDate());
    var formattedDate = date.toLocaleDateString('tr-TR', { year: 'numeric', month: 'numeric', day: 'numeric' });
    $("#dateSelect").val(formattedDate);


    $("#dateSelect").datepicker({
        format: 'dd-MM-yyyy',
        autoclose: true,
        todayHighlight: true
    });

    $('.btn-secondary').click(function () {
        var today = new Date();
        var formattedDate = today.toLocaleDateString('tr-TR', { year: 'numeric', month: 'numeric', day: 'numeric' });
        $("#dateSelect").val(formattedDate);
    });

    $('.btn-light').click(function () {
        var tomorrow = new Date();
        tomorrow.setDate(tomorrow.getDate() + 1);
        var formattedDate = tomorrow.toLocaleDateString('tr-TR', { year: 'numeric', month: 'numeric', day: 'numeric' });
        $("#dateSelect").val(formattedDate);
    });
}

function swapLocations() {
    var originSelect = $("#originSelect");
    var destinationSelect = $("#destinationSelect");

    var tempValue = originSelect.val();
    originSelect.val(destinationSelect.val());
    destinationSelect.val(tempValue);

    originSelect.selectpicker("refresh");
    destinationSelect.selectpicker("refresh");
}

const sessionId = sessionStorage.getItem('sessionId');

function saveJourneyData(origion, destination, date) {
    const userKey = `journey-${sessionId}`;
    const journeyData = { origion, destination, date };
    localStorage.setItem(userKey, JSON.stringify(journeyData));
}

function getJourneyData() {
    const sessionId = sessionStorage.getItem('sessionId');
    const userKey = `journey-${sessionId}`;
    const journeyData = localStorage.getItem(userKey);

    if (journeyData) {
        return JSON.parse(journeyData);
    } else {
        return null;
    }
}

function clearJourneyData() {
    const sessionId = sessionStorage.getItem('sessionId');
    const userKey = `journey-${sessionId}`;
    localStorage.removeItem(userKey);
}

window.onload = function () {
    if (!sessionStorage.getItem('sessionId')) {
        const newSessionId = generateSessionId();
        sessionStorage.setItem('sessionId', newSessionId);
    }

    const sessionId = sessionStorage.getItem('sessionId');
    const userKey = `journey-${sessionId}`;
    const storedJourneyData = localStorage.getItem(userKey);

    if (storedJourneyData) {
        const journeyData = JSON.parse(storedJourneyData);

        var originSelect = $("#originSelect");
        var destinationSelect = $("#destinationSelect");
        var dateSelect = $("#dateSelect");

        originSelect.val(journeyData.origion);
        destinationSelect.val(journeyData.destination);
        dateSelect.val(journeyData.date);

        originSelect.selectpicker("refresh");
        destinationSelect.selectpicker("refresh");
    }
};

function generateSessionId() {
    return 'session-' + Math.random().toString(36).substr(2, 9);
}

$('#journeyForm').submit(function (event) {
    const origion = $('#originSelect').val();
    const destination = $('#destinationSelect').val();
    const date = $('#dateSelect').val();
    const sessionId = sessionStorage.getItem('sessionId');
    const userKey = `journey-${sessionId}`;
    const journeyData = { origion, destination, date };

    localStorage.setItem(userKey, JSON.stringify(journeyData));
});

