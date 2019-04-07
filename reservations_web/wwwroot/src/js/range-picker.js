const $ = require("jquery");
require('jquery-ui/ui/widgets/datepicker');

$(document).ready(() => {
    const datepicker = $("#preparation .datepicker");
    if (datepicker.length > 0) {
        radioGroup = $("#preparation  .radio-group");
        firstLoadMessage = $("#preparation  .invalid-date");
        noReservation = $("#preparation  .no-reservation");
        nextButton = $("#preparation #next-button");
        toInput = $("#preparation #input-to");
        fromInput = $("#preparation #input-from");

        datepicker.datepicker({dateFormat: 'dd.mm.yy'});

        radioGroup.hide();
        firstLoadMessage.show();
        noReservation.hide();
        nextButton.attr("disabled", true);

        toggleTimes(datepicker.val());

        $("input[type=radio]").on('change', function () {
            let checkedRadio = $("input[type=radio]:checked");
            if (checkedRadio.length) {
                nextButton.removeAttr("disabled");
                let currentTime = checkedRadio.val().split(':');
                let dateText = datepicker.val();

                let toTime = `${(1 + parseInt(currentTime[0])).toString().padStart(2, "0")}:${currentTime[1]}:${currentTime[2]}`;
                let fromTime = `${parseInt(currentTime[0]).toString().padStart(2, "0")}:${currentTime[1]}:${currentTime[2]}`;

                let date = dateText.split(".");

                toInput.val(`${date[2]}-${date[1]}-${date[0]} ${toTime}`);
                fromInput.val(`${date[2]}-${date[1]}-${date[0]} ${fromTime}`);
            }
        });

        $("#datepicker").on('change', function () {
            toggleTimes($(this).val());
        });
    }
});

function toggleTimes(date) {
    firstLoadMessage.hide();
    noReservation.hide();
    radioGroup.show();

    const val = date;

    if (val === "") {
        firstLoadMessage.show();
        noReservation.hide();
        radioGroup.hide();
        return;
    }

    $("input[type=radio]+label").show();
    $("input[type=radio]").prop("checked", false);
    nextButton.attr("disabled", true);

    const roomId = $("#room-id").text();

    let splitDate = val.split(".");

    let isoFormat = `${splitDate[2]}-${splitDate[1]}-${splitDate[0]}`;
    
    ///ISO Format is universal, therefor I don't have to worry about the localization
    $.get(`/api/rooms/${roomId}`, {date: isoFormat}, (data) => {
        data.reservations.forEach((i) => {
            let date = new Date(i.from);
            let h = date.getHours();
            $(`#${h}+label`).hide();
        });

        if ($("input[type=radio]+label:visible").length === 0) {
            noReservation.show();
            radioGroup.hide();
        }
    })
}