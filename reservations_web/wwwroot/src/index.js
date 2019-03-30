const $ = require("jquery");
require('jquery-ui/ui/widgets/datepicker');
require("popper.js");
require("jquery-validation");
require("jquery-validation-unobtrusive");

$(document).ready(() => {
   $(".datepicker").datepicker({ dateFormat: 'dd.mm.yy' }); 
});