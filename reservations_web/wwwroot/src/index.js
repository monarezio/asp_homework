const $ = require("jquery");
require('jquery-ui/ui/widgets/datepicker');
require("popper.js");
require("jquery-validation");
require("jquery-validation-unobtrusive");

$(document).ready(() => {
   $(".datepicker").datepicker({ dateFormat: 'dd.mm.yy' });
   
   radioGroup = $(".radio-group");
   firstLoadMessage = $(".invalid-date");
   noReservation = $(".no-reservation");
   nextButton = $(".btn-primary");
   
   radioGroup.hide();
   firstLoadMessage.show();
   noReservation.hide();
   nextButton.attr("disabled", true);

   toggleTimes($(".datepicker").val());
   
   $("input[type=radio]").on('change', function() {
      if($("input[type=radio]:checked").length)
         nextButton.removeAttr("disabled")
   });
   
   $("#datepicker").on('change', function() {
      toggleTimes($(this).val()); 
   });
});

function toggleTimes(date) {
   firstLoadMessage.hide();
   noReservation.hide();
   radioGroup.show();

   const val = date;
   
   if(val === "") {
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
   
   isoFormat = `${splitDate[2]}-${splitDate[1]}-${splitDate[0]}`;
   
   $.get(`/api/rooms/${roomId}`, {date: isoFormat}, (data) => {
      data.reservations.forEach((i) => {
         let date = new Date(i.from);
         let h = date.getHours();
         $(`#${h}+label`).hide();
      });

      if($("input[type=radio]+label:visible").length === 0) {
         noReservation.show();
         radioGroup.hide();
      }
   })
}