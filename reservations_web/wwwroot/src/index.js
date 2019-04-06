require("popper.js");
require("jquery-validation");
require("jquery-validation-unobtrusive");
require('./js/range-picker');

const $ = require("jquery");
require("bootstrap/js/dist/tooltip");
require("bootstrap/js/dist/alert");
$(document).ready(() => {
    $('.alert').alert();
    $('[data-toggle="tooltip"]').tooltip();
});